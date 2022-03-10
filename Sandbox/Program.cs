using System;
using System.IO;
using Leaf;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            PolygonShape renderer = new PolygonShape()
            {
                fillColor = SFML.Graphics.Color.Magenta
            };

            GameObject @object = new GameObject(new Text(File.ReadAllBytes("Comfortaa.ttf")), "p");

            Scene scene = new(new GameObject[] { @object });
            Application app = new Application(800, 600, "Sandbox", scene, () => { }, Update);
        }

        public static void Update()
        {
            
        }
    }
}
