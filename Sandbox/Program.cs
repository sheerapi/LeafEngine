using System;
using System.IO;
using Leaf;
using Leaf.UI;

namespace Sandbox
{
    class Program
    {
        static Scene scene;

        static GameObject @object;

        static void Main(string[] args)
        {
            ResourceFactory.SaveAsset(new Asset("button", File.ReadAllBytes("Button.png")));
            ResourceFactory.SaveAsset(new Asset("testAudio", File.ReadAllBytes("saoko.ogg")));

            @object = new GameObject(new Script[] { new Button() }, "p");

            GameObject sprite = new GameObject(new Script[] {new AudioPlayer(ResourceFactory.GetAsset("testAudio"))
            {
                pitch = 1.25f
            } }, "s");

            sprite.transform.parent = @object.transform;

            scene = new(new GameObject[] { sprite, @object });
            Application app = new Application(800, 600, "Sandbox", scene);
        }
    }
}
