using System;

namespace CSharpGL
{
    /// <summary>
    /// Get information about timing.
    /// </summary>
    public static class Time
    {
        private static DateTime lastTime;
        private static TimeSpan deltaTime;

        /// <summary>
        /// Time interval betwwen two contiguous <see cref="SceneObject"/>
        /// </summary>
        public static TimeSpan DeltaTime { get { return deltaTime; } }

        internal static void Set()
        {
            lastTime = DateTime.Now;
        }

        internal static void Update()
        {
            DateTime now = DateTime.Now;
            deltaTime = now.Subtract(lastTime);
            lastTime = now;
        }
    }
}