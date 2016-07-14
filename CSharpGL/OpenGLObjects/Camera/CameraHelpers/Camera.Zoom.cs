using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CSharpGL
{
    /// <summary>
    /// TODO:摄像机的perspective和ortho视角，是否应该同时变化？
    /// </summary>
    public static partial class CameraHelper
    {

        ///// <summary>
        ///// Adjusts camera's settings according to bounding box.
        ///// <para>Use this when bounding box's size or positon is changed.</para>
        ///// </summary>
        ///// <param name="camera"></param>
        ///// <param name="boundingBox"></param>
        //public static void ZoomCamera(this IScientificCamera camera, IBoundingBox boundingBox)
        //{
        //    float sizeX, sizeY, sizeZ;
        //    boundingBox.GetBoundDimensions(out sizeX, out sizeY, out sizeZ);
        //    float size = Math.Max(Math.Max(sizeX, sizeY), sizeZ);

        //    {
        //        float centerX, centerY, centerZ;
        //        boundingBox.GetCenter(out centerX, out centerY, out centerZ);
        //        vec3 target = new vec3(centerX, centerY, centerZ);

        //        vec3 target2Position = camera.Position - camera.Target;
        //        target2Position.Normalize();

        //        vec3 position = target + target2Position * (size * 2 + 1);

        //        camera.Position = position;
        //        camera.Target = target;
        //        //camera.UpVector = new vec3(0f, 1f, 0f);
        //    }

        //    {
        //        int[] viewport = new int[4];
        //        GL.GetInteger(GetTarget.Viewport, viewport);
        //        int width = viewport[2]; int height = viewport[3];

        //        IPerspectiveViewCamera perspectiveViewCamera = camera;
        //        perspectiveViewCamera.FieldOfView = 60;
        //        perspectiveViewCamera.AspectRatio = (double)width / (double)height;
        //        perspectiveViewCamera.Near = 0.01;
        //        perspectiveViewCamera.Far = size * 3 + 1;// double.MaxValue;
        //    }
        //    {
        //        int[] viewport = new int[4];
        //        GL.GetInteger(GetTarget.Viewport, viewport);
        //        int width = viewport[2]; int height = viewport[3];

        //        IOrthoViewCamera orthoViewCamera = camera;
        //        if (width > height)
        //        {
        //            orthoViewCamera.Left = -size * width / height;
        //            orthoViewCamera.Right = size * width / height;
        //            orthoViewCamera.Bottom = -size;
        //            orthoViewCamera.Top = size;
        //        }
        //        else
        //        {
        //            orthoViewCamera.Left = -size;
        //            orthoViewCamera.Right = size;
        //            orthoViewCamera.Bottom = -size * height / width;
        //            orthoViewCamera.Top = size * height / width;
        //        }
        //        orthoViewCamera.Near = 0;
        //        orthoViewCamera.Far = size * 3 + 1;// double.MaxValue;
        //    }
        //}

        /// <summary>
        /// Zoom camera to fit in specified <paramref name="boundingBox"/>.
        /// </summary>
        /// <param name="boundingBox"></param>
        /// <param name="camera"></param>
        public static void ZoomCamera(this IBoundingBox boundingBox, ICamera camera)
        {
            if (boundingBox == null || camera == null) { throw new ArgumentNullException(); }

            switch (camera.CameraType)
            {
                case CameraType.Perspecitive:
                    ((IPerspectiveViewCamera)camera).ZoomCamera(boundingBox);
                    break;
                case CameraType.Ortho:
                    ((IOrthoViewCamera)camera).ZoomCamera(boundingBox);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

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
                case CameraType.Perspecitive:
                    ((IPerspectiveViewCamera)camera).ZoomCamera(boundingBox);
                    break;
                case CameraType.Ortho:
                    ((IOrthoViewCamera)camera).ZoomCamera(boundingBox);
                    break;
                default:
                    throw new NotImplementedException();
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

            {
                int[] viewport = new int[4];
                OpenGL.GetInteger(GetTarget.Viewport, viewport);
                int width = viewport[2]; int height = viewport[3];

                camera.FieldOfView = 60;
                camera.AspectRatio = (double)width / (double)height;
                camera.Near = 0.01;
                camera.Far = size * 3 + 1;// double.MaxValue;
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
                OpenGL.GetInteger(GetTarget.Viewport, viewport);
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
                camera.Near = 0;
                camera.Far = size * 3 + 1;// double.MaxValue;
            }
        }

    }
}
