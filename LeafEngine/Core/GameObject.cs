using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Leaf
{
    /// <summary>
    /// Base class to manage objects, and with a component system
    /// </summary>
    public class GameObject
    {
        public Transform transform { get; set; } = new Transform();

        protected internal Script[] components = Array.Empty<Script>();
        public string name { get; }

        public GameObject(Script[] scripts, string objectName)
        {
            components = scripts;

            foreach (Script component in components)
            {
                component.gameObject = this;
                component.transform = transform;
            }
            name = objectName;
            transform.gameObject = this;
        }

        /// <summary>
        /// Finds a <see cref="GameObject"/> by it's name
        /// </summary>
        /// <param name="name">The object name</param>
        /// <returns></returns>
        public static GameObject FindByName(string name)
        {
            if (Application.Default.scene == null) return null;
            if (Application.Default.scene.objects == null) return null;

            foreach (GameObject gameObject in Application.Default.scene.objects)
            {
                if (gameObject.name.ToLower() == name.ToLower())
                {
                    return gameObject;
                }
            }

            return null;
        }

        public T GetScript<T>(string script)
            where T : Script
        {

            if (components == null || components.Length <= 0)
            {
                Logger.Log("Tried to obtain a Script that doesn't exists in the current object", Logger.LogLevel.Error);
                return null;
            }

            foreach (Script component in components)
            {
                if (component.GetType().Name == script)
                {
                    return (T)component;
                }
            }

            return null;
        }

        public void AddComponent(Script component)
        {
            Array.Resize(ref components, components.Length + 1);
            components[^1] = component;

            component.transform = transform;
            component.gameObject = this;
            component.Start();
        }

        public override string ToString()
        {
            return name + " [" + transform.ToString() + "]" + " [" + components.Length + " components]";
        }
    }

    /// <summary>
    /// Base class to control position, rotation and scale
    /// </summary>
    public class Transform
    {
        public Vector3 position { get; set; }

        public float rotation { get; set; } = 0f;

        public Vector2 scale { get; set; }

        public Transform parent { get; set; }

        public GameObject gameObject { get; set; }

        public Transform()
        {
            position = Vector3.Zero();
            rotation = 0f;
            scale = new Vector2(1f, 1f);
        }

        public override string ToString()
        {
            return position.ToString() + " " + rotation.ToString("0.00") + "° " + scale.ToString();
        }
    }
}
