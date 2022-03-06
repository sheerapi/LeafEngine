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
        private static Dictionary<string, float> Axes { get; set; } = new Dictionary<string, float>()
        {
            { "horizontal", 0f },
            { "vertical", 0f }
        };

        public static Vector2 mousePosition { get; internal set; }

        public static bool IsKeyHold(Keyboard.Key key)
        {
            if (KeyHold == true && PressedKey == key)
            {
                return true;
            }

            return false;
        }

        public static bool IsKeyReleased(Keyboard.Key key)
        {
            if (KeyHold == false && PressedKey == key)
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
