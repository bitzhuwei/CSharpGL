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
        ///
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static vec3 Abs(this vec3 item)
        {
            vec3 result = new vec3(item.x, item.y, item.z);
            if (result.x < 0) { result.x = -result.x; }
            if (result.y < 0) { result.y = -result.y; }
            if (result.z < 0) { result.z = -result.z; }

            return result;
        }

        /// <summary>
        /// update maximum values.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="currentMax"></param>
        public static void UpdateMax(this vec3 item, ref vec3 currentMax)
        {
            if (currentMax.x < item.x) { currentMax.x = item.x; }
            if (currentMax.y < item.y) { currentMax.y = item.y; }
            if (currentMax.z < item.z) { currentMax.z = item.z; }
        }

        /// <summary>
        /// update minimum values.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="currentMax"></param>
        public static void UpdateMax(this ivec3 item, ref ivec3 currentMax)
        {
            if (currentMax.x < item.x) { currentMax.x = item.x; }
            if (currentMax.y < item.y) { currentMax.y = item.y; }
            if (currentMax.z < item.z) { currentMax.z = item.z; }
        }

        /// <summary>
        /// update minimum values.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="currentMax"></param>
        public static void UpdateMax(this uvec3 item, ref uvec3 currentMax)
        {
            if (currentMax.x < item.x) { currentMax.x = item.x; }
            if (currentMax.y < item.y) { currentMax.y = item.y; }
            if (currentMax.z < item.z) { currentMax.z = item.z; }
        }

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
        /// <param name="currentMin"></param>
        public static void UpdateMin(this ivec3 item, ref ivec3 currentMin)
        {
            if (item.x < currentMin.x) { currentMin.x = item.x; }
            if (item.y < currentMin.y) { currentMin.y = item.y; }
            if (item.z < currentMin.z) { currentMin.z = item.z; }
        }
        /// <summary>
        /// update minimum values.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="currentMin"></param>
        public static void UpdateMin(this uvec3 item, ref uvec3 currentMin)
        {
            if (item.x < currentMin.x) { currentMin.x = item.x; }
            if (item.y < currentMin.y) { currentMin.y = item.y; }
            if (item.z < currentMin.z) { currentMin.z = item.z; }
        }
    }
}