using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.System;
using System.Threading.Tasks;

namespace Leaf
{
    public class PolygonShape : Script
    {
        public int polygonCount { get; set; } = 3;

        public Color fillColor { get; set; }

        public float outlineRadius { get; set; }

        public Color outlineColor { get; set; }

        protected internal ConvexShape shape { get; set; }

        private Shader Shader { get; set; }

        public override void Start()
        {
            shape = new ConvexShape((uint)polygonCount);
            shape.SetPointCount((uint)polygonCount);
            Application.Default.SuscribeDrawable(new LDrawable(shape, Shader));
        }

        public override void Update()
        {
            shape.SetPoint(0, new Vector2f(2f, -2f));
            shape.SetPoint(1, new Vector2f(90f, 90f));
            shape.SetPoint(2, new Vector2f(-90f, 90f));

            shape.FillColor = new SFML.Graphics.Color((byte)fillColor.r, (byte)fillColor.g, (byte)fillColor.b, (byte)fillColor.a);
            shape.OutlineThickness = outlineRadius;
            shape.OutlineColor = new SFML.Graphics.Color((byte)outlineColor.r, (byte)outlineColor.g, (byte)outlineColor.b, (byte)outlineColor.a);
            shape.SetPointCount((uint)polygonCount);
            shape.Rotation = transform.rotation;
            shape.Position = new Vector2f(transform.position.x, transform.position.y);
            shape.Scale = new Vector2f(transform.scale.x, transform.scale.y);

            // transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal", true), transform.position.y + Input.GetAxis("vertical", true), 0f);
        }

        public void SetPoint(int index, Vector2 point)
        {
            shape.SetPoint((uint)index, new Vector2f(point.x, point.y));
        }

        public void SetShader(Shader shader)
        {
            Shader = shader;
        }
    }
}
