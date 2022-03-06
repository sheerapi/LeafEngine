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

        public override void Start()
        {
            shape = new ConvexShape((uint)polygonCount);
            shape.SetPointCount((uint)polygonCount);
        }

        public override void Update()
        {
            shape.SetPoint(0, new Vector2f(2f, -2f));
            shape.SetPoint(1, new Vector2f(90f, 90f));
            shape.SetPoint(2, new Vector2f(-90f, 90f));

            shape.FillColor = fillColor;
            shape.OutlineThickness = outlineRadius;
            shape.OutlineColor = outlineColor;
            shape.SetPointCount((uint)polygonCount);
            shape.Rotation = transform.rotation;
            shape.Position = new Vector2f(transform.position.x, transform.position.y);
            shape.Scale = new Vector2f(transform.scale.x, transform.scale.y);

            Application.Default.Window.Draw(shape, new RenderStates(BlendMode.Alpha));

            // transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal", true), transform.position.y + Input.GetAxis("vertical", true), 0f);
        }

        public void SetPoint(int index, Vector2 point)
        {
            shape.SetPoint((uint)index, new Vector2f(point.x, point.y));
        }
    }
}
