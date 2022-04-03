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
        [JsonProperty]
        protected internal GameObject[] objects;

        public void Push(GameObject gameObject)
        {
            Array.Resize(ref objects, objects.Length + 1);
            objects[objects.Length - 1] = gameObject;
        }

        public Scene(GameObject[] gameObjects)
        {
            objects = gameObjects;
        }

        /// <summary>
        /// Returns a JSON string that represents the current object
        /// </summary>
        /// <returns><see cref="string"/></returns>
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
                hierarchy += "- " + gameObject.ToString() + "\n";
            }

            return hierarchy;
        }
    }
}
