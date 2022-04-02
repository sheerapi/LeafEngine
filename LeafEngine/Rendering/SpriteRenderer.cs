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

        public Color color { get; set; } = new Color(255, 255, 255, 255);

        public bool smooth { get; set; } = true;

        public bool fitToScreen { get; set; } = false;

        private Shader Shader { get; set; }

        public SpriteRenderer(byte[] Sprite)
        {
            Texture texture = new Texture(Sprite);
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

            Application.Default.SuscribeDrawable(new LDrawable(sprite, Shader));
        }

        public override void Update()
        {
            if (fitToScreen == true)
            {
                SFML.Window.VideoMode vm = SFML.Window.VideoMode.DesktopMode;
                Vector2 texSize = new Vector2(sprite.TextureRect.Width, sprite.TextureRect.Height);
                transform.scale = new Vector2(vm.Width / texSize.x, vm.Height / texSize.y);
            }

            sprite.Color = new SFML.Graphics.Color((byte)color.r, (byte)color.g, (byte)color.b, (byte)color.a);
            sprite.Scale = new SFML.System.Vector2f(transform.scale.x, transform.scale.y);
            sprite.Rotation = transform.rotation;
            sprite.Position = new SFML.System.Vector2f(transform.position.x * Project.PixelsPerMeter, transform.position.y * Project.PixelsPerMeter);
            sprite.TextureRect = new IntRect(new SFML.System.Vector2i(0, 0), new SFML.System.Vector2i((int)sprite.Texture.Size.X, (int)sprite.Texture.Size.Y));
            sprite.Texture.Smooth = smooth;

            //transform.position = new Vector2(transform.position.x + Input.GetAxis("Horizontal", true), transform.position.y + Input.GetAxis("vertical", true));
        }

        public void SetShader(Shader shader)
        {
            Shader = shader;
        }
    }
}
