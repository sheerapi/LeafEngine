using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leaf;

namespace Sandbox
{
    public class ParallaxEffect : Script
    {
        public float mouseT = 0.1f;

        public override void Start()
        {
            transform.position = new Vector3(-500f, 500f, 0f);
        }

        public override void Update()
        {
            transform.scale = new Vector2(transform.scale.x * 5, transform.scale.y * 5);
            transform.position = Vector3.Lerp(transform.position, new Vector3(Input.mousePosition.x * mouseT, Input.mousePosition.y * mouseT, 0f), 1f);
        }
    }
}
