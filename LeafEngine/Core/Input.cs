using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using SFML.System;
using SFML.Window;

namespace Leaf
{
    public class Input
    {
        protected static internal Keyboard.Key PressedKey { get; set; }

        protected static internal bool KeyHold { get; set; }

        protected static internal bool KeyPressed { get; set; }

        protected static internal bool MouseHold { get; set; }

        protected static internal bool MousePressed { get; set; }

        protected static internal Mouse.Button MouseButtonPressed { get; set; }

        private static Dictionary<string, float> Axes { get; set; } = new Dictionary<string, float>()
        {
            { "horizontal", 0f },
            { "vertical", 0f }
        };

        public static Vector2 mousePosition { get; internal set; } = new Vector2(-5f, -5f);

        public static bool IsKeyHold(string key)
        {
            if (KeyHold == true && PressedKey.ToString().ToLower() == key.ToLower())
            {
                return true;
            }

            return false;
        }

        public static bool IsKeyDown(string key)
        {
            if (KeyPressed == true && PressedKey.ToString().ToLower() == key.ToLower())
            {
                return true;
            }

            return false;
        }

        public static bool IsKeyReleased(string key)
        {
            if (KeyHold == false && PressedKey.ToString().ToLower() == key.ToLower())
            {
                return true;
            }

            return false;
        }

        public static bool IsKeyUp(string key)
        {
            if (KeyPressed == false && PressedKey.ToString().ToLower() == key.ToLower())
            {
                return true;
            }

            return false;
        }

        public static float GetAxis(string name, bool resetAfterDetection)
        {
            if (KeyHold == false)
            {
                if (resetAfterDetection == true)
                {
                    return 0f;
                }
                else
                {
                    return Axes[name.ToLower()];
                }
            }
            
            switch (name.ToLower())
            {
                case "horizontal":
                    if (PressedKey == Keyboard.Key.A || PressedKey == Keyboard.Key.Left)
                    {
                        Axes[name.ToLower()] = -1f;
                    }
                    else if (PressedKey == Keyboard.Key.D || PressedKey == Keyboard.Key.Right)
                    {
                        Axes[name.ToLower()] = 1f;
                    }
                    else if (PressedKey != Keyboard.Key.D && PressedKey != Keyboard.Key.Right && PressedKey != Keyboard.Key.A || PressedKey != Keyboard.Key.Left)
                    {
                        if (resetAfterDetection == true)
                        {
                            Axes[name.ToLower()] = 0f;
                        }
                    }
                    break;

                case "vertical":
                    if (PressedKey == Keyboard.Key.W || PressedKey == Keyboard.Key.Up)
                    {
                        Axes[name.ToLower()] = -1f;
                    }
                    else if (PressedKey == Keyboard.Key.S || PressedKey == Keyboard.Key.Down)
                    {
                        Axes[name.ToLower()] = 1f;
                    }
                    else if (PressedKey != Keyboard.Key.S && PressedKey != Keyboard.Key.Down && PressedKey != Keyboard.Key.W && PressedKey != Keyboard.Key.Up)
                    {
                        if (resetAfterDetection == true)
                        {
                            Axes[name.ToLower()] = 0f;
                        }
                    }
                    break;
            }

            return Axes[name.ToLower()];
        }
    }
}
