using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf
{
    public static class Project
    {
        public static float TimeScale { get; set; } = 1f;

        public static Vector2 Gravity { get; set; } = new Vector2(0f, 9.31f);

        public static float PixelsPerMeter { get; set; } = 100f;

        public static bool LogTrace { get; set; }
    }
}
