using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace Leaf
{
    /// <summary>
    /// Used to manage player settings, or game variables (persistent across sessions)
    /// </summary>
    public class PlayerPrefs
    {
        /// <summary>
        /// Saves an int to the default prefs file, or creates one in case there isn't one
        /// </summary>
        /// <param name="value">The value to write</param>
        /// <param name="name">The name of the value</param>
        public static void SaveInt(int value, string name)
        {
            if (!File.Exists("settings.pref"))
            {
                File.WriteAllText("settings.pref", "");
            }

            List<string> lines = File.ReadAllLines("settings.pref").ToList();
            lines.Add(name + "=" + value.ToString());

            File.WriteAllLines("settings.pref", lines.ToArray());
        }

        /// <summary>
        /// Saves a float to the default prefs file, or creates one in case there isn't one
        /// </summary>
        /// <param name="value">The value to write</param>
        /// <param name="name">The name of the value</param>
        public static void SaveFloat(float value, string name)
        {
            if (!File.Exists("settings.pref"))
            {
                File.WriteAllText("settings.pref", "");
            }

            List<string> lines = File.ReadAllLines("settings.pref").ToList();
            lines.Add(name + "=" + value.ToString());

            File.WriteAllLines("settings.pref", lines.ToArray());
        }

        /// <summary>
        /// Saves a string to the default prefs file, or creates one in case there isn't one
        /// </summary>
        /// <param name="value">The value to write</param>
        /// <param name="name">The name of the value</param>
        public static void SaveString(string value, string name)
        {
            if (!File.Exists("settings.pref"))
            {
                File.WriteAllText("settings.pref", "");
            }

            List<string> lines = File.ReadAllLines("settings.pref").ToList();
            lines.Add(name + "=" + value.ToString());

            File.WriteAllLines("settings.pref", lines.ToArray());
        }

        /// <summary>
        /// Saves a boolean to the default prefs file, or creates one in case there isn't one
        /// </summary>
        /// <param name="value">The value to write</param>
        /// <param name="name">The name of the value</param>
        public static void SaveBool(bool value, string name)
        {
            if (!File.Exists("settings.pref"))
            {
                File.WriteAllText("settings.pref", "");
            }

            List<string> lines = File.ReadAllLines("settings.pref").ToList();
            lines.Add(name + "=" + value.ToString());

            File.WriteAllLines("settings.pref", lines.ToArray());
        }

        /// <summary>
        /// Saves an object (as JSON) to the default prefs file, or creates one in case there isn't one
        /// </summary>
        /// <param name="value">The value to write</param>
        /// <param name="name">The name of the value</param>
        public static void SaveObject(object value, string name)
        {
            if (!File.Exists("settings.pref"))
            {
                File.WriteAllText("settings.pref", "");
            }

            List<string> lines = File.ReadAllLines("settings.pref").ToList();
            lines.Add(name + "=" + JsonConvert.SerializeObject(value));

            File.WriteAllLines("settings.pref", lines.ToArray());
        }
        
        /// <summary>
        /// Gets an int from the prefs file (or returns defaultValue if not found)
        /// </summary>
        /// <param name="name">The name of value to get</param>
        /// <param name="defaultValue">The object to return in case of an error</param>
        /// <returns><see cref="int"/></returns>
        public static int GetInt(string name, int defaultValue)
        {
            if (!File.Exists("settings.pref")) return defaultValue;

            List<string> lines = File.ReadAllLines("settings.pref").ToList();

            foreach (string line in lines)
            {
                if (line.Split("=")[0] == name)
                {
                    return int.Parse(line.Split("=")[1]);
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets a float from the prefs file (or returns defaultValue if not found)
        /// </summary>
        /// <param name="name">The name of value to get</param>
        /// <param name="defaultValue">The object to return in case of an error</param>
        /// <returns><see cref="float"/></returns>
        public static float GetFloat(string name, float defaultValue)
        {
            if (!File.Exists("settings.pref")) return defaultValue;

            List<string> lines = File.ReadAllLines("settings.pref").ToList();

            foreach (string line in lines)
            {
                if (line.Split("=")[0] == name)
                {
                    return float.Parse(line.Split("=")[1]);
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets a string from the prefs file (or returns defaultValue if not found)
        /// </summary>
        /// <param name="name">The name of value to get</param>
        /// <param name="defaultValue">The object to return in case of an error</param>
        /// <returns><see cref="string"/></returns>
        public static string GetString(string name, string defaultValue)
        {
            if (!File.Exists("settings.pref")) return defaultValue;

            List<string> lines = File.ReadAllLines("settings.pref").ToList();

            foreach (string line in lines)
            {
                if (line.Split("=")[0] == name)
                {
                    return line.Split("=")[1];
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets an object (JSON) from the prefs file (or returns defaultValue if not found)
        /// </summary>
        /// <param name="name">The name of value to get</param>
        /// <param name="defaultValue">The object to return in case of an error</param>
        /// <returns><see cref="object"/></returns>
        public static T GetObject<T>(string name, T defaultValue)
        {
            if (!File.Exists("settings.pref")) return defaultValue;

            List<string> lines = File.ReadAllLines("settings.pref").ToList();

            foreach (string line in lines)
            {
                if (line.Split("=")[0] == name)
                {
                    return JsonConvert.DeserializeObject<T>(line.Split("=")[1]);
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets a boolean from the prefs file (or returns defaultValue if not found)
        /// </summary>
        /// <param name="name">The name of value to get</param>
        /// <param name="defaultValue">The object to return in case of an error</param>
        /// <returns><see cref="bool"/></returns>
        public static bool GetBool(string name, bool defaultValue)
        {
            if (!File.Exists("settings.pref")) return defaultValue;

            List<string> lines = File.ReadAllLines("settings.pref").ToList();

            foreach (string line in lines)
            {
                if (line.Split("=")[0] == name)
                {
                    if (line.Split("=")[1] == "true")
                    {
                        return true;
                    }
                    else return false;
                }
            }

            return defaultValue;
        }
    }
}
