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
            IPerspectiveCamera perspectiveCamera = camera;
            double lastAspectRatio = perspectiveCamera.AspectRatio;

            // update perspective camera.
            {
                perspectiveCamera.AspectRatio = ((double)currentSize.Width) / ((double)currentSize.Height);
            }

            // update ortho camera.
            {
                IOrthoCamera orthoCamera = camera;
                if (lastSize.Width != currentSize.Width)
                {
                    double lastWidth = orthoCamera.Right - orthoCamera.Left;
                    double widthRatio = ((double)currentSize.Width) / ((double)lastSize.Width);
                    double currentWidth = lastWidth * widthRatio;
                    orthoCamera.Left = -currentWidth / 2.0;
                    orthoCamera.Right = currentWidth / 2.0;
                }

                if (lastSize.Height != currentSize.Height)
                {
                    double lastHeight = orthoCamera.Top - orthoCamera.Bottom;
                    double heightRatio = ((double)currentSize.Height) / ((double)lastSize.Height);
                    double currentHeight = lastHeight * heightRatio;
                    orthoCamera.Bottom = -currentHeight / 2.0;
                    orthoCamera.Top = currentHeight / 2.0;
                }
                //if (aspectRatio > lastAspectRatio)
                //{
                //    double top = orthoCamera.Top;
                //    double newRight = top * aspectRatio;
                //    orthoCamera.Left = -newRight;
                //    orthoCamera.Right = newRight;
                //}
                //else if (aspectRatio < lastAspectRatio)
                //{
                //    double right = orthoCamera.Right;
                //    double newTop = right / aspectRatio;
                //    orthoCamera.Bottom = -newTop;
                //    orthoCamera.Top = newTop;
                //}

                //const int factor = 100;
                //if (width / 2 / factor != orthoCamera.Right)
                //{
                //    orthoCamera.Left = -width / 2 / factor;
                //    orthoCamera.Right = width / 2 / factor;
                //}
                //if (height / 2 / factor != orthoCamera.Top)
                //{
                //    orthoCamera.Bottom = -height / 2 / factor;
                //    orthoCamera.Top = height / 2 / factor;
                //}
            }
        }
    }
}