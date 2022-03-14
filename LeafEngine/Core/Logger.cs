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
            Color col = Color.AliceBlue;
            StackFrame methodBase = new StackFrame(2, true);

            MemberTypes methodType = methodBase.GetMethod().MemberType;
            string methodStr = methodType != MemberTypes.Constructor ? methodBase.GetMethod().Name : methodBase.GetMethod().DeclaringType.Name;


            string debugStr = ""; // methodBase.GetFileName().Split(@"\").Last() + "(" + methodBase.GetFileLineNumber() + ", " + methodStr + "())";

            switch (logLevel)
            {
                case LogLevel.Info:
                    col = Color.FromArgb(120, 255, 71);
                    break;
                case LogLevel.Warning:
                    col = Color.FromArgb(255, 246, 71);
                    break;
                case LogLevel.Trace:
                    col = Color.FromArgb(96, 247, 227);
                    break;
                case LogLevel.Error:
                    col = Color.FromArgb(255, 112, 99);
                    break;
                case LogLevel.Fatal:
                    col = Color.FromArgb(222, 65, 51);
                    break;
            }

            Colorful.Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] [{logLevel.ToString().ToUpper()}] [{debugStr}] {msg.ToString()}", col);
        }
    }
}
