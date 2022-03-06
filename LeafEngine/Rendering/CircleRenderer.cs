using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using System.Threading.Tasks;

namespace Leaf
{
    public class CircleRenderer : Script
    {
        public float radius { get; set; } = 10f;

        public Color fillColor { get; set; } = Color.Cyan;

        public float outlineRadius { get; set; } = 0.1f;

        public Color outlineFillColor { get; set; } = Color.Green;

        protected internal CircleShape shape { get; set; }

        public override void Start()
        {
            shape = new CircleShape(radius);
        }

        public override void Update()
        {
            shape.FillColor = fillColor;
            shape.OutlineColor = outlineFillColor;
            shape.OutlineThickness = outlineRadius;
            shape.Radius = radius;
            shape.Rotation = transform.rotation;
            shape.Position = new SFML.System.Vector2f(transform.position.x, transform.position.y);
            shape.Scale = new SFML.System.Vector2f(transform.scale.x, transform.scale.y);

            Application.Default.Window.Draw(shape, new RenderStates(BlendMode.Alpha));

            // c
        }
    }
}
