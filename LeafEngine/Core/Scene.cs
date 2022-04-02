using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, this.GetType(), Formatting.Indented, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public override string ToString()
        {
            string hierarchy = "\n";

            foreach (GameObject gameObject in objects)
            {
                string objectIndicator = gameObject.transform.parent == null ? "- " : " - ";

                hierarchy += objectIndicator + gameObject.ToString() + (gameObject.transform.parent == null ? "" : $" [Child of {gameObject.transform.parent.gameObject.name}]") + "\n";
            }

            return hierarchy;
        }
    }
}
