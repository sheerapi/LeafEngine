using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Leaf
{
    public class LDrawable
    {
        public Drawable Drawable { get; set; }

        public Shader Shader { get; set; }

        public BlendMode BlendMode { get; set; } = BlendMode.Alpha;

        public LDrawable(Drawable drawable, Shader shader = null)
        {
            Drawable = drawable;
            Shader = shader;
        }
    }
}
