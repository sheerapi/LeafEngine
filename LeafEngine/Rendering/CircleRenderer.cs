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

        public Color fillColor { get; set; }

        public float outlineRadius { get; set; } = 0.1f;

        public Color outlineFillColor { get; set; }

        protected internal CircleShape shape { get; set; }

        private Shader Shader { get; set; }

        public override void Start()
        {
            shape = new CircleShape(radius);
            Application.Default.SuscribeDrawable(new LDrawable(shape, Shader));
        }

        public override void Update()
        {
            shape.FillColor = new SFML.Graphics.Color((byte)fillColor.r, (byte)fillColor.g, (byte)fillColor.b, (byte)fillColor.a); ;
            shape.OutlineColor = new SFML.Graphics.Color((byte)outlineFillColor.r, (byte)outlineFillColor.g, (byte)outlineFillColor.b, (byte)outlineFillColor.a); ;
            shape.OutlineThickness = outlineRadius;
            shape.Radius = radius;
            shape.Rotation = transform.rotation;
            shape.Position = new SFML.System.Vector2f(transform.position.x * Project.PixelsPerMeter, transform.position.y * Project.PixelsPerMeter);
            shape.Scale = new SFML.System.Vector2f(transform.scale.x, transform.scale.y);
        }

        public void SetShader(Shader shader)
        {
            Shader = shader;
        }
    }
}
