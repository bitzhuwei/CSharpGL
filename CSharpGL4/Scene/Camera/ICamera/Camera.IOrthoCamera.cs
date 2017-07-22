namespace CSharpGL
{
    public partial class Camera
    {
        #region IOrthoCamera 成员

        private UpdatingRecord orthoCameraRecord = new UpdatingRecord(true);
        private double left;

        double IOrthoCamera.Left
        {
            get { return left; }
            set
            {
                if (left != value)
                {
                    left = value;
                    orthoCameraRecord.Mark();
                }
            }
        }

        private double right;

        double IOrthoCamera.Right
        {
            get { return right; }
            set
            {
                if (right != value)
                {
                    right = value;
                    orthoCameraRecord.Mark();
                }
            }
        }

        private double bottom;

        double IOrthoCamera.Bottom
        {
            get { return bottom; }
            set
            {
                if (bottom != value)
                {
                    bottom = value;
                    orthoCameraRecord.Mark();
                }
            }
        }

        private double top;

        double IOrthoCamera.Top
        {
            get { return top; }
            set
            {
                if (top != value)
                {
                    top = value;
                    orthoCameraRecord.Mark();
                }
            }
        }

        private double orthoNear;

        double IOrthoCamera.Near
        {
            get { return orthoNear; }
            set
            {
                if (orthoNear != value)
                {
                    orthoNear = value;
                    orthoCameraRecord.Mark();
                }
            }
        }

        private double orthoFar;

        double IOrthoCamera.Far
        {
            get { return orthoFar; }
            set
            {
                if (orthoFar != value)
                {
                    orthoFar = value;
                    orthoCameraRecord.Mark();
                }
            }
        }

        private mat4 orhtoProjectionMatrix;

        mat4 IOrthoCamera.GetOrthoProjectionMatrix()
        {
            if (orthoCameraRecord.IsMarked())
            {
                var camera = this as IOrthoCamera;
                orhtoProjectionMatrix = glm.ortho(
                    (float)camera.Left, (float)camera.Right,
                    (float)camera.Bottom, (float)camera.Top,
                    (float)camera.Near, (float)camera.Far);
            }

            return this.orhtoProjectionMatrix;
        }

        #endregion IOrthoCamera 成员
    }
}