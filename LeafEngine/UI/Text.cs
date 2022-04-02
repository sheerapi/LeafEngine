using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Leaf.UI
{
    public class Text : Script
    {
        private Font font { get; set; }

        private SFML.Graphics.Text sfmlText { get; set; }

        public string text { get; set; } = "Sample Text";

        public Color color { get; set; }

        public int fontSize { get; set; } = 18;

        public TextStyle textStyle { get; set; } = TextStyle.None;

        public Color outlineColor { get; set; }

        public float outlineRadius { get; set; }

        public float letterSpacing { get; set; } = 0.15f;

        public float lineSpacing { get; set; }

        private Shader Shader { get; set; }

        public enum TextStyle
        {
            Bold,
            Italic,
            None,
            Strikethrough,
            Underline
        }

        public Text(byte[] fontBytes)
        {
            font = new Font(fontBytes);
        }

        public override void Start()
        {
            sfmlText = new SFML.Graphics.Text(text, font, (uint)fontSize);

            Application.Default.SuscribeDrawable(new LDrawable(sfmlText, Shader));
        }

        public override void Update()
        {
            sfmlText.CharacterSize = (uint)fontSize;
            sfmlText.FillColor = new SFML.Graphics.Color((byte)color.r, (byte)color.g, (byte)color.b, (byte)color.a);
            sfmlText.DisplayedString = text;
            sfmlText.Font = font;
            sfmlText.Position = new SFML.System.Vector2f(transform.position.x, transform.position.y);
            sfmlText.Rotation = transform.rotation;
            sfmlText.Scale = new SFML.System.Vector2f(transform.scale.x, transform.scale.y);

            switch (textStyle)
            {
                case TextStyle.Bold:
                    sfmlText.Style = SFML.Graphics.Text.Styles.Bold;
                    break;
                case TextStyle.Italic:
                    sfmlText.Style = SFML.Graphics.Text.Styles.Italic;
                    break;
                case TextStyle.None:
                    sfmlText.Style = SFML.Graphics.Text.Styles.Regular;
                    break;
                case TextStyle.Strikethrough:
                    sfmlText.Style = SFML.Graphics.Text.Styles.StrikeThrough;
                    break;
                case TextStyle.Underline:
                    sfmlText.Style = SFML.Graphics.Text.Styles.Underlined;
                    break;
            }

            sfmlText.OutlineColor = new SFML.Graphics.Color((byte)outlineColor.r, (byte)outlineColor.g, (byte)outlineColor.b, (byte)outlineColor.a); ;
            sfmlText.OutlineThickness = outlineRadius;
            sfmlText.LetterSpacing = letterSpacing;
            sfmlText.LineSpacing = lineSpacing;
        }

        public void SetShader(Shader shader)
        {
            Shader = shader;
        }
    }
}
