using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf
{
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

        public static Vector2 operator +(Vector2 a, float b)
        {
            return new Vector2(a.x + b, a.y + b);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        public static Vector2 operator -(Vector2 a, float b)
        {
            return new Vector2(a.x - b, a.y - b);
        }

        public static bool InRange(Vector2 value, Vector2 min, Vector2 max)
        {
            return value.x >= min.x && value.y >= min.y && value.x <= max.x && value.y <= max.y;
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

        public static implicit operator Vector2(Vector3 x)
        {
            return new Vector2(x.y, x.y);
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
            return "[Vector3] X(" + x.ToString("0.00") + ") Y(" + y.ToString("0.00") + ")" + " Z(" + z.ToString("0.00") + ")";
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 operator +(Vector3 a, float b)
        {
            return new Vector3(a.x + b, a.y + b, a.z + b);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3 operator -(Vector3 a, float b)
        {
            return new Vector3(a.x - b, a.y - b, a.z - b);
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

        public static implicit operator Vector3(Vector2 x)
        {
            return new Vector3(x.y, x.y, 0f);
        }
    }
}
