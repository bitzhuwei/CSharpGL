using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// </summary>
    public static partial class OpenGL
    {
        /// <summary>
        /// Gets or sets OpenGL's clear color.
        /// </summary>
        public static Color ClearColor
        {
            get
            {
                var color = new float[4];
                OpenGL.GetFloat(GetTarget.ColorClearValue, color);
                return (new vec4(color[0], color[1], color[2], color[3])).ToColor();
            }
            set
            {
                vec4 color = value.ToVec4();
                OpenGL.ClearColor(color.x, color.y, color.z, color.w);
            }
        }
    }
}