using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using System.Threading.Tasks;

namespace Leaf.UI
{
    public class Button : Script
    {
        private Sprite sprite;

        public Color normalColor { get; set; } = new Color(255, 203, 134, 252);

        public Color hoverColor { get; set; } = new Color(255, 247, 231, 104);

        public float lerpTime { get; set; } = 0.35f;

        private Color color;

        private Shader Shader { get; set; }

        public byte[] source { get; set; } = ResourceFactory.GetAsset("button");

        public override void Start()
        {
            sprite = new Sprite(new Texture(source));

            Application.Default.SuscribeDrawable(new LDrawable(sprite, Shader));

            color = normalColor;
        }

        public override void Update()
        {
            sprite.Rotation = transform.rotation;
            sprite.Color = new SFML.Graphics.Color((byte)color.r, (byte)color.g, (byte)color.b, (byte)color.a);
            sprite.Scale = new SFML.System.Vector2f(transform.scale.x, transform.scale.y);
            sprite.Position = new SFML.System.Vector2f(transform.position.x * Project.PixelsPerMeter, transform.position.y * Project.PixelsPerMeter);

            if (Vector2.InRange(Input.mousePosition, transform.position, new Vector2(sprite.Texture.Size.X, sprite.Texture.Size.Y)))
            {
                color = Color.Lerp(color, hoverColor, lerpTime);
            }
            else
            {
                color = Color.Lerp(color, normalColor, lerpTime);
            }
        }

        public void SetShader(Shader shader)
        {
            Shader = shader;
        }
    }
}
