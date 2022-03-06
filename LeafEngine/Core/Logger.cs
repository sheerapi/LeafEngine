using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string date = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;

            switch (logLevel)
            {
                case LogLevel.Info:
                    Colorful.Console.WriteLine($"[{date}][{logLevel.ToString().ToUpper()}] {msg.ToString()}", Color.Magenta);
                    break;
                case LogLevel.Warning:
                    Colorful.Console.WriteLine($"[{date}][{logLevel.ToString().ToUpper()}] {msg.ToString()}", Color.Yellow);
                    break;
                case LogLevel.Error:
                    Colorful.Console.WriteLine($"[{date}][{logLevel.ToString().ToUpper()}] {msg.ToString()}", Color.Red);
                    break;
                case LogLevel.Fatal:
                    Colorful.Console.WriteLine($"[{date}][{logLevel.ToString().ToUpper()}] {msg.ToString()}", Color.DarkRed);
                    break;
                case LogLevel.Trace:
                    Colorful.Console.WriteLine($"[{date}][{logLevel.ToString().ToUpper()}] {msg.ToString()}", Color.Cyan);
                    break;
            }
        }
    }
}
