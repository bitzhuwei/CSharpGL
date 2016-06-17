using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static class Camera2Matrix
    {

        /// <summary>
        /// 根据摄像机的类型获取其投影矩阵
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static mat4 GetProjectionMat4(this ICamera camera)
        {
            mat4 result;

            switch (camera.CameraType)
            {
                case CameraType.Perspecitive:
                    result = ((IPerspectiveCamera)camera).GetProjectionMat4();
                    break;
                case CameraType.Ortho:
                    result = ((IOrthoCamera)camera).GetProjectionMat4();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        /// <summary>
        /// Extension method for <see cref="IPerspectiveCamera"/> to get projection matrix.
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static mat4 GetProjectionMat4(this IPerspectiveCamera camera)
        {
            mat4 perspective = glm.perspective(
                (float)(camera.FieldOfView * Math.PI / 180.0f),
                (float)camera.AspectRatio, (float)camera.Near, (float)camera.Far);
            return perspective;
        }

        /// <summary>
        /// Extension method for <see cref="IOrthoCamera"/> to get projection matrix.
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static mat4 GetProjectionMat4(this IOrthoCamera camera)
        {
            mat4 ortho = glm.ortho(
                (float)camera.Left, (float)camera.Right,
                (float)camera.Bottom, (float)camera.Top,
                (float)camera.Near, (float)camera.Far);
            return ortho;
        }

        /// <summary>
        /// Extension method for <see cref="IViewCamera"/> to get view matrix.
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static mat4 GetViewMat4(this IViewCamera camera)
        {
            mat4 lookAt = glm.lookAt(camera.Position, camera.Target, camera.UpVector);
            return lookAt;
        }

    }
}
