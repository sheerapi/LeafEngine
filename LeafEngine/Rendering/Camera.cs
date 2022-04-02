using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Leaf
{
    /// <summary>
    /// Simple component to manage and view objects
    /// </summary>
    public class Camera : Script
    {
        public static Camera main { get; internal set; }

        public Color backgroundColor { get; set; } = Color.Black;

        public float zoomFactor { get; set; } = 1f;

        protected internal View view { get; set; }

        public int cameraWidth { get; set; } = 1920;

        public int cameraHeight { get; set; } = 1080;

        public bool adjustSizeToWindow { get; set; } = true;

        public Camera()
        {
            main = this;
        }

        public override void Update()
        {
            if (adjustSizeToWindow == true)
            {
                cameraWidth = Application.Default.Width;
                cameraHeight = Application.Default.Height;
            }

            view = new View(new FloatRect(0, 0, cameraWidth, cameraHeight));

            view.Rotation = transform.rotation;
            view.Zoom(zoomFactor);
            view.Move(new Vector2f(transform.position.x, transform.position.y));
            view.Viewport = new FloatRect(0, 0, transform.scale.x, transform.scale.y);

            Application.Default.Window.SetView(view);

            // zoomFactor += Input.GetAxis("Vertical", true) / 5f;
        }

        public Vector3 ScreenToWorldPosition(Vector3 screenPos)
        {
            return screenPos / Project.PixelsPerMeter;
        }

        public Vector3 WorldToScreenPosition(Vector3 worldPos)
        {
            return worldPos * Project.PixelsPerMeter;
        }
    }
}
