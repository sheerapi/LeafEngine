using System;
using System.IO;
using Leaf;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            ResourceFactory.SaveAsset(new Asset("comfortaFont", File.ReadAllBytes("Comfortaa.ttf")));
            ResourceFactory.SaveAsset(new Asset("testAudio", File.ReadAllBytes("saoko.ogg")));

            PolygonShape renderer = new PolygonShape()
            {
                fillColor = SFML.Graphics.Color.Magenta
            };

            GameObject @object = new GameObject(new Text(ResourceFactory.GetAsset("comfortaFont")), "p");
            GameObject sprite = new GameObject(new AudioPlayer(ResourceFactory.GetAsset("testAudio"))
            {
                pitch = 1.25f
            }, "s");

            Scene scene = new(new GameObject[] { sprite, @object });
            Application app = new Application(800, 600, "Sandbox", scene, () => { }, Update);
        }

        public static void Update()
        {
            GameObject.FindByName("p").GetScript<Text>("Text").text = ((int)(1f / Time.deltaTime)).ToString();
        }
    }
}
