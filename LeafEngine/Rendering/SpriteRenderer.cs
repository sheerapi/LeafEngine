using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Leaf
{
    public class SpriteRenderer : Script
    {
        public Sprite sprite { get; set; }

        public Color color { get; set; } = Color.White;

        public bool smooth { get; set; } = true;

        public bool fitToScreen { get; set; } = true;

        public SpriteRenderer(string fileName)
        {
            Texture texture = new Texture(File.ReadAllBytes(fileName));
            sprite = new Sprite(texture);

            if (sprite == null || texture == null)
            {
                Logger.Log("Error occurred while loading a sprite", Logger.LogLevel.Fatal);
            }
        }

        public override void Start()
        {
            sprite.TextureRect = new IntRect(0, 0, (int)sprite.Texture.Size.X, (int)sprite.Texture.Size.Y);

            sprite.Texture.Update(sprite.Texture.CopyToImage().Pixels);
        }

        public override void Update()
        {
            if (fitToScreen == true)
            {
                SFML.Window.VideoMode vm = SFML.Window.VideoMode.DesktopMode;
                Vector2 texSize = new Vector2(sprite.TextureRect.Width, sprite.TextureRect.Height);
                transform.scale = new Vector2(vm.Width / texSize.x, vm.Height / texSize.y);
            }

            sprite.Color = color;
            sprite.Scale = new SFML.System.Vector2f(transform.scale.x, transform.scale.y);
            sprite.Rotation = transform.rotation;
            sprite.Position = new SFML.System.Vector2f(transform.position.x, transform.position.y);
            sprite.TextureRect = new IntRect(new SFML.System.Vector2i(0, 0), new SFML.System.Vector2i((int)sprite.Texture.Size.X, (int)sprite.Texture.Size.Y));
            sprite.Texture.Smooth = smooth;

            Application.Default.Window.Draw(sprite, new RenderStates(BlendMode.Alpha));

            //transform.position = new Vector2(transform.position.x + Input.GetAxis("Horizontal", true), transform.position.y + Input.GetAxis("vertical", true));
        }
    }
}
