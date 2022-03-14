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

        public GameObject(Script component, string objectName)
        {
            Array.Resize(ref components, components.Length + 1);
            components[^1] = component;

            component.gameObject = this;
            component.transform = transform;
            name = objectName;
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
    }

    /// <summary>
    /// Base class to control position, rotation and scale
    /// </summary>
    public class Transform
    {
        public Vector3 position { get; set; }

        public float rotation { get; set; } = 0f;

        public Vector2 scale { get; set; }

        public Transform()
        {
            position = Vector3.Zero();
            rotation = 0f;
            scale = new Vector2(1f, 1f);
        }
    }

    /// <summary>
    /// Representation of 2D vectors and points
    /// </summary>
    public struct Vector2
    {
        public float x { get; set; }
        public float y { get; set; }

        /// <summary>
        /// Creates a new vector with the given properties
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public Vector2(float X, float Y)
        {
            x = X;
            y = Y;
        }

        public static Vector2 Zero() { return new Vector2(0f, 0f); }

        public override string ToString()
        {
            return "[Vector2] X(" + x.ToString("0.00") + ") Y(" + y.ToString("0.00") + ")";
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }

        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a.x * b, a.y * b);
        }

        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x / b.x, a.y / b.y);
        }

        public static Vector2 operator /(Vector2 a, float b)
        {
            return new Vector2(a.x / b, a.y / b);
        }
    }

    /// <summary>
    /// Representation of 3D vectors and points
    /// </summary>
    public struct Vector3
    {
        public float x { get; set; }
        public float y { get; set; }

        public float z { get; set; }

        /// <summary>
        /// Creates a new vector with the given properties
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public Vector3(float X, float Y, float Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        public static Vector3 Zero() { return new Vector3(0f, 0f, 0f); }

        public override string ToString()
        {
            return "[Vector2] X(" + x.ToString("0.00") + ") Y(" + y.ToString("0.00") + ")" + "Z(" + z.ToString("0.00") + ")";
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        public static Vector3 operator *(Vector3 a, float b)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }

        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
        }

        public static Vector3 operator /(Vector3 a, float b)
        {
            return new Vector3(a.x / b, a.y / b, a.z / b);
        }

        public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
            return new Vector3(MathL.Lerp(a.x, b.x, t), MathL.Lerp(a.y, b.y, t), MathL.Lerp(a.z, b.z, t));
        }
    }
}
