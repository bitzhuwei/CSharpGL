using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CSharpGL
{
    public static partial class CameraHelper
    {

        /// <summary>
        /// Get front vector in world space.
        /// </summary>
        /// <returns></returns>
        public static vec3 GetFront(this IViewCamera camera)
        {
            vec3 result = camera.Target - camera.Position;
            return result;
        }

        /// <summary>
        /// Get back vector in world space.
        /// </summary>
        /// <returns></returns>
        public static vec3 GetBack(this IViewCamera camera)
        {
            vec3 result = camera.Position - camera.Target;
            return result;
        }

        /// <summary>
        /// Get left vector in world space.
        /// </summary>
        /// <returns></returns>
        public static vec3 GetLeft(this IViewCamera camera)
        {
            vec3 back = camera.Position - camera.Target;
            vec3 result = back.cross(camera.UpVector);
            return result;
        }

        /// <summary>
        /// Get right vector in world space.
        /// </summary>
        /// <returns></returns>
        public static vec3 GetRight(this IViewCamera camera)
        {
            vec3 back = camera.Position - camera.Target;
            vec3 result = camera.UpVector.cross(back);
            return result;
        }

    }
}
