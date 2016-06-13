using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Drawing
{
    /// <summary>
    /// Helper class for array.
    /// </summary>
    public static class ColorHelper
    {

        public static vec3 ToVec3(this Color color)
        {
            return new vec3(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);
        }

        public static vec4 ToVec4(this Color color)
        {
            return new vec4(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f, color.A / 255.0f);
        }

    }
}
