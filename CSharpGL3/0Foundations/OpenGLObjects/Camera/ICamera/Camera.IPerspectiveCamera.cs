using System;

namespace CSharpGL
{
    public partial class Camera
    {
        #region IPerspectiveCamera 成员

        private UpdatingRecord perspectiveCameraRecord = new UpdatingRecord(true);
        private double fieldOfView;

        double IPerspectiveCamera.FieldOfView
        {
            get { return fieldOfView; }
            set
            {
                if (fieldOfView != value)
                {
                    fieldOfView = value;
                    perspectiveCameraRecord.Mark();
                }
            }
        }

        private double aspectRatio;

        double IPerspectiveCamera.AspectRatio
        {
            get { return aspectRatio; }
            set
            {
                if (aspectRatio != value)
                {
                    aspectRatio = value;
                    perspectiveCameraRecord.Mark();
                }
            }
        }

        private double perspectiveNear;

        double IPerspectiveCamera.Near
        {
            get { return perspectiveNear; }
            set
            {
                if (perspectiveNear != value)
                {
                    perspectiveNear = value;
                    perspectiveCameraRecord.Mark();
                }
            }
        }

        private double perspectiveFar;

        double IPerspectiveCamera.Far
        {
            get { return perspectiveFar; }
            set
            {
                if (perspectiveFar != value)
                {
                    perspectiveFar = value;
                    perspectiveCameraRecord.Mark();
                }
            }
        }

        private mat4 perspectiveProjectionMatrix;

        mat4 IPerspectiveCamera.GetPerspectiveProjectionMatrix()
        {
            if (perspectiveCameraRecord.IsMarked())
            {
                var camera = this as IPerspectiveCamera;
                perspectiveProjectionMatrix = glm.perspective(
                    (float)(camera.FieldOfView * Math.PI / 180.0f),
                    (float)camera.AspectRatio, (float)camera.Near, (float)camera.Far);
                perspectiveCameraRecord.CancelMark();
            }

            return perspectiveProjectionMatrix;
        }

        #endregion IPerspectiveCamera 成员
    }
}