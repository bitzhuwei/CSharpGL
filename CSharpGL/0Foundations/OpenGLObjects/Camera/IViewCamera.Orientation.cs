namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
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

        /// <summary>
        /// Gets standard up.
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static vec3 GetUp(this IViewCamera camera)
        {
            vec3 back = camera.Position - camera.Target;
            vec3 right = camera.UpVector.cross(back);
            vec3 up = back.cross(right);
            return up;
        }

        /// <summary>
        /// Gets standard down.
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static vec3 GetDown(this IViewCamera camera)
        {
            vec3 back = camera.Position - camera.Target;
            vec3 right = camera.UpVector.cross(back);
            vec3 down = right.cross(back);
            return down;
        }
    }
}