using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Leaf
{
    public class Text : Script
    {
        private Font font { get; set; }

        private SFML.Graphics.Text sfmlText { get; set; }

        public string text { get; set; } = "Sample Text";

        public Color color { get; set; } = Color.White;

        public int fontSize { get; set; } = 18;

        public TextStyle textStyle { get; set; } = TextStyle.None;

        public Color outlineColor { get; set; }

        public float outlineRadius { get; set; }

        public float letterSpacing { get; set; } = 0.15f;

        public float lineSpacing { get; set; }

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
        }

        public override void Update()
        {
            sfmlText.CharacterSize = (uint)fontSize;
            sfmlText.FillColor = color;
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

            sfmlText.OutlineColor = outlineColor;
            sfmlText.OutlineThickness = outlineRadius;
            sfmlText.LetterSpacing = letterSpacing;
            sfmlText.LineSpacing = lineSpacing;

            Application.Default.Window.Draw(sfmlText, new RenderStates(BlendMode.Alpha));
        }
    }
}
