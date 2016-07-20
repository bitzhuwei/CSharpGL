using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Helper class for array.
    /// </summary>
    public static class ColorHelper
    {
        /// <summary>
        /// (x, y, z) equals Color.FromArgb(255, x * 255, y * 255, z * 255);
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color ToColor(this vec3 color)
        {
            return Color.FromArgb(255, (int)(color.x * 255), (int)(color.y * 255), (int)(color.z * 255));
        }

        /// <summary>
        /// (x, y, z, w) equals Color.FromArgb(w * 255, x * 255, y * 255, z * 255);
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color ToColor(this vec4 color)
        {
            return Color.FromArgb((int)(color.w * 255), (int)(color.x * 255), (int)(color.y * 255), (int)(color.z * 255));
        }

        /// <summary>
        /// (x, y, z) equals Color.FromArgb(255, x * 255, y * 255, z * 255);
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static vec3 ToVec3(this Color color)
        {
            return new vec3(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);
        }

        /// <summary>
        /// (x, y, z, w) equals Color.FromArgb(w * 255, x * 255, y * 255, z * 255);
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static vec4 ToVec4(this Color color)
        {
            return new vec4(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f, color.A / 255.0f);
        }

    }
}
