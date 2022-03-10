using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf
{
    /// <summary>
    /// Base class to create and manage scripts, derivate from this class if you want a functional script
    /// </summary>
    public class Script
    {
        public GameObject gameObject { get; internal set; }

        public Transform transform { get; internal set; }

        public bool enabled { get; set; } = true;

        /// <summary>
        /// Called when added to a <see cref="GameObject"/>
        /// </summary>
        public virtual void Start()
        {
            
        }

        /// <summary>
        /// Called every single frame
        /// </summary>
        public virtual void Update()
        {

        }

        public virtual void MouseMove(Vector2 newPos) { }

        public virtual void OnWindowClose() { }

        public virtual void OnWindowResize(Vector2 newSize) { }

        public virtual void JoystickConnect(int joystickIndex) { }

        public virtual void JoystickDisconnect(int joystickIndex) { }

        public virtual void OnFocusChange(bool isFocused) { }
    }
}
