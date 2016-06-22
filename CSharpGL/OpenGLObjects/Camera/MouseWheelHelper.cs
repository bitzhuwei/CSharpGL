using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static class MouseWheelHelper
    {
        /// <summary>
        /// 对摄像机执行一次缩放操作
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="delta"></param>
        public static void MouseWheel(this ICamera camera, int delta)
        {
            //if (camera.CameraType == CameraTypes.Perspecitive)
            {
                var target2Position = camera.Position - camera.Target;
                if (target2Position.length() < 0.01)
                {
                    target2Position = target2Position.normalize();
                    target2Position.x *= 0.01f;
                    target2Position.y *= 0.01f;
                    target2Position.z *= 0.01f;
                }
                var scaledTarget2Position = target2Position * (1 - delta * 0.001f);
                camera.Position = camera.Target + scaledTarget2Position;
                double lengthDiff = scaledTarget2Position.length() - target2Position.length();
                // Increase ortho camera's Near/Far property in case the camera's position changes too much.
                IPerspectiveCamera perspectiveCamera = camera;
                perspectiveCamera.Far += lengthDiff;
                //perspectiveCamera.Near += lengthDiff;
                IOrthoCamera orthoCamera = camera;
                orthoCamera.Far += lengthDiff;
                orthoCamera.Near += lengthDiff;
            }
            //else if (camera.CameraType == CameraTypes.Ortho)
            {
                IOrthoCamera orthoCamera = camera;
                double distanceX = orthoCamera.Right - orthoCamera.Left;
                double distanceY = orthoCamera.Top - orthoCamera.Bottom;
                double centerX = (orthoCamera.Left + orthoCamera.Right) / 2;
                double centerY = (orthoCamera.Bottom + orthoCamera.Top) / 2;
                orthoCamera.Left = centerX - distanceX * (1 - delta * 0.001) / 2;
                orthoCamera.Right = centerX + distanceX * (1 - delta * 0.001) / 2;
                orthoCamera.Bottom = centerY - distanceY * (1 - delta * 0.001) / 2;
                orthoCamera.Top = centerX + distanceY * (1 - delta * 0.001) / 2;
            }
        }

    }
}
