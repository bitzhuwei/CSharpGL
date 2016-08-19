using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// vector's helper.
    /// </summary>
    public static class VectorHelper
    {
        /// <summary>
        /// separator
        /// </summary>
        internal static readonly char[] separator = new char[] { ' ', ',' };

        /// <summary>
        /// update minimum values.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="currentMin"></param>
        public static void UpdateMin(this vec3 item, ref vec3 currentMin)
        {
            if (item.x < currentMin.x) { currentMin.x = item.x; }
            if (item.y < currentMin.y) { currentMin.y = item.y; }
            if (item.z < currentMin.z) { currentMin.z = item.z; }
        }

        /// <summary>
        /// update minimum values.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="currentMax"></param>
        public static void UpdateMax(this vec3 item, ref vec3 currentMax)
        {
            if (currentMax.x < item.x) { currentMax.x = item.x; }
            if (currentMax.y < item.y) { currentMax.y = item.y; }
            if (currentMax.z < item.z) { currentMax.z = item.z; }
        }
    }
}
