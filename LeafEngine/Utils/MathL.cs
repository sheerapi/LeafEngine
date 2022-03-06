﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf
{
    public class MathL
    {
        public static float Lerp(float a, float b, float t)
        {
            return a * (1 - t) + b * t;
        }
    }
}
