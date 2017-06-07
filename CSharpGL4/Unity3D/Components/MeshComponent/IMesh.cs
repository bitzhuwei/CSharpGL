using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMeshBase
    {
        /// <summary>
        /// 
        /// </summary>
        vec3[] Positions { get; }

        /// <summary>
        /// 
        /// </summary>
        vec3[] Normals { get; }

        /// <summary>
        /// 
        /// </summary>
        float[][] UVs { get; }

        /// <summary>
        /// 
        /// </summary>
        Bitmap[] Textures { get; }
    }

}
