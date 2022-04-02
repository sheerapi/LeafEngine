using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.Drawing;

namespace Leaf
{
    /// <summary>
    /// Basic logger including coloring
    /// </summary>
    public class Logger
    {
        public enum LogLevel
        {
            Info,
            Warning,
            Error,
            Fatal,
            Trace
        }

        /// <summary>
        /// Logs something to the console
        /// </summary>
        /// <param name="msg">The message to log</param>
        /// <param name="logLevel">The message severity</param>
        public static void Log(object msg, Logger.LogLevel logLevel)
        {
            System.Drawing.Color col = System.Drawing.Color.AliceBlue;
            StackFrame methodBase = new StackFrame(2, true);

            MemberTypes methodType = methodBase.GetMethod().MemberType;
            string methodStr = methodType != MemberTypes.Constructor ? methodBase.GetMethod().Name : methodBase.GetMethod().DeclaringType.Name;


            string debugStr = methodBase.GetFileName().Split(@"\").Last() + "(" + methodBase.GetFileLineNumber() + ", " + methodStr + "())";

            switch (logLevel)
            {
                case LogLevel.Info:
                    col = System.Drawing.Color.FromArgb(120, 255, 71);
                    break;
                case LogLevel.Warning:
                    col = System.Drawing.Color.FromArgb(255, 246, 71);
                    break;
                case LogLevel.Trace:
                    col = System.Drawing.Color.FromArgb(96, 247, 227);
                    break;
                case LogLevel.Error:
                    col = System.Drawing.Color.FromArgb(255, 112, 99);
                    break;
                case LogLevel.Fatal:
                    col = System.Drawing.Color.FromArgb(222, 65, 51);
                    break;
            }

            if (logLevel == LogLevel.Fatal)
            {
                Colorful.Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] [{logLevel.ToString().ToUpper()}] [{debugStr}] {msg.ToString()}", col);
                Environment.Exit(1);
            }
            else if (logLevel == LogLevel.Trace)
            {
                if (Project.LogTrace)
                {
                    Colorful.Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] [{logLevel.ToString().ToUpper()}] [{debugStr}] {msg.ToString()}", col);
                }
            }
            else
            {
                Colorful.Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] [{logLevel.ToString().ToUpper()}] [{debugStr}] {msg.ToString()}", col);
            }
        }
    }
}
