using System.Drawing;
namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class ICameraHelper
    {
        /// <summary>
        /// opengl控件的大小改变时调整camera.
        /// Adjust camera when OpenGL canvas's size changed.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="lastSize">canvas' last size.</param>
        /// <param name="currentSize">canvas' current size.</param>
        public static void Resize(this ICamera camera, Size lastSize, Size currentSize)
        {
            // update perspective camera.
            {
                IPerspectiveCamera perspectiveCamera = camera;
                perspectiveCamera.AspectRatio = ((double)currentSize.Width) / ((double)currentSize.Height);
            }

            // update ortho camera.
            {
                IOrthoCamera orthoCamera = camera;
                // fit window size.
                if (lastSize.Width != currentSize.Width)
                {
                    double lastWidth = orthoCamera.Right - orthoCamera.Left;
                    double widthRatio = ((double)currentSize.Width) / ((double)lastSize.Width);
                    double currentWidth = lastWidth * widthRatio;
                    double center = (orthoCamera.Left + orthoCamera.Right) / 2.0 * widthRatio;
                    orthoCamera.Left = center - currentWidth / 2.0;
                    orthoCamera.Right = center + currentWidth / 2.0;
                }
                // fit window size.
                if (lastSize.Height != currentSize.Height)
                {
                    double lastHeight = orthoCamera.Top - orthoCamera.Bottom;
                    double heightRatio = ((double)currentSize.Height) / ((double)lastSize.Height);
                    double currentHeight = lastHeight * heightRatio;
                    double center = (orthoCamera.Bottom + orthoCamera.Top) / 2.0 * heightRatio;
                    orthoCamera.Bottom = center - currentHeight / 2.0;
                    orthoCamera.Top = center + currentHeight / 2.0;
                }

                //// scale scene.
                //if (currentSize.Width >= currentSize.Height)
                //{
                //    double ratio1 = (double)currentSize.Width / (double)lastSize.Width;
                //    double ratio2 = (double)lastSize.Height / (double)currentSize.Height;
                //    double currentWidth = orthoCamera.Right - orthoCamera.Left;
                //    double center = (orthoCamera.Right + orthoCamera.Left) / 2.0;
                //    double newWidth = currentWidth * ratio1 * ratio2;
                //    orthoCamera.Left = center - newWidth / 2;
                //    orthoCamera.Right = center + newWidth / 2;
                //}
                //else
                //{
                //    double ratio1 = (double)currentSize.Height / (double)lastSize.Height;
                //    double ratio2 = (double)lastSize.Width / (double)currentSize.Width;
                //    double currentHeight = orthoCamera.Top - orthoCamera.Bottom;
                //    double center = (orthoCamera.Top + orthoCamera.Bottom) / 2;
                //    double newHeight = currentHeight * ratio1 * ratio2;
                //    orthoCamera.Bottom = center - newHeight / 2;
                //    orthoCamera.Top = center + newHeight / 2;
                //}
            }
        }
    }
}