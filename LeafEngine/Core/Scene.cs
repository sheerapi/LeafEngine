using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf
{
    /// <summary>
    /// Simple class to manage all the objects appearing in camera
    /// </summary>
    public class Scene
    {
        public GameObject[] objects;

        public void Push(GameObject gameObject)
        {
            Array.Resize(ref objects, objects.Length + 1);
            objects[objects.Length - 1] = gameObject;
        }

        public Scene(GameObject[] gameObjects)
        {
            objects = gameObjects;
        }
    }
}
