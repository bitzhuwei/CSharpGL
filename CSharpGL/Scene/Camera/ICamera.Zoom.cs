using System;

namespace CSharpGL
{
    public static partial class CameraHelper
    {
        /// <summary>
        /// Zoom camera to fit in specified <paramref name="boundingBox"/>.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="boundingBox"></param>
        public static void ZoomCamera(this ICamera camera, IBoundingBox boundingBox)
        {
            if (boundingBox == null || camera == null) { throw new ArgumentNullException(); }

            switch (camera.CameraType)
            {
                case CameraType.Perspective:
                    ((IPerspectiveViewCamera)camera).ZoomCamera(boundingBox);
                    break;

                case CameraType.Ortho:
                    ((IOrthoViewCamera)camera).ZoomCamera(boundingBox);
                    break;

                default:
                    throw new NotDealWithNewEnumItemException(typeof(CameraType));
            }
        }

        /// <summary>
        /// Adjusts camera's settings according to bounding box.
        /// <para>Use this when bounding box's size or positon is changed.</para>
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="boundingBox"></param>
        public static void ZoomCamera(this IPerspectiveViewCamera camera, IBoundingBox boundingBox)
        {
            vec3 length = boundingBox.MaxPosition - boundingBox.MinPosition;
            float size = Math.Max(Math.Max(length.x, length.y), length.z);

            {
                vec3 target = boundingBox.MaxPosition / 2 + boundingBox.MinPosition / 2;

                vec3 target2Position = (camera.Position - camera.Target).normalize();

                vec3 position = target + target2Position * (size * 2 + 1);

                camera.Position = position;
                camera.Target = target;
                //camera.UpVector = new vec3(0f, 1f, 0f);
            }
        }

        /// <summary>
        /// Adjusts camera's settings according to bounding box.
        /// <para>Use this when bounding box's size or positon is changed.</para>
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="boundingBox"></param>
        public static void ZoomCamera(this IOrthoViewCamera camera, IBoundingBox boundingBox)
        {
            vec3 length = boundingBox.MaxPosition - boundingBox.MinPosition;
            float size = Math.Max(Math.Max(length.x, length.y), length.z);

            {
                vec3 target = boundingBox.MaxPosition / 2 + boundingBox.MinPosition / 2;

                vec3 target2Position = (camera.Position - camera.Target).normalize();

                vec3 position = target + target2Position * (size * 2 + 1);

                camera.Position = position;
                camera.Target = target;
                //camera.UpVector = new vec3(0f, 1f, 0f);
            }

            {
                int[] viewport = new int[4];
                GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
                int width = viewport[2]; int height = viewport[3];

                if (width > height)
                {
                    camera.Left = -size * width / height;
                    camera.Right = size * width / height;
                    camera.Bottom = -size;
                    camera.Top = size;
                }
                else
                {
                    camera.Left = -size;
                    camera.Right = size;
                    camera.Bottom = -size * height / width;
                    camera.Top = size * height / width;
                }
                //camera.Near = 0;
                //camera.Far = size * 3 + 1;// double.MaxValue;
            }
        }
    }
}