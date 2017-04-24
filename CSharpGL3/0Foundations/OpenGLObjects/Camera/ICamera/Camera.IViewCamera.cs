using System.ComponentModel;

namespace CSharpGL
{
    public partial class Camera
    {
        #region IViewCamera

        private UpdatingRecord viewMatrixRecord = new UpdatingRecord(true);

        private vec3 target;

        /// <summary>
        /// Gets or sets world coordinate of the camera's target.
        /// </summary>
        [Description("world coordinate of the camera's target(the point it's looking at).")]
        [Category(strCamera)]
        public vec3 Target
        {
            get { return target; }
            set
            {
                if (target != value)
                {
                    target = value;
                    viewMatrixRecord.Mark();
                }
            }
        }

        private vec3 upVector = new vec3(0, 1, 0);

        /// <summary>
        /// Gets or sets world coordinate of the camera's up vector.
        /// </summary>
        /// <value>
        /// Up vector.
        /// </value>
        [Description("world coordinate of the camera's up vector.")]
        [Category(strCamera)]
        public vec3 UpVector
        {
            get { return upVector; }
            set
            {
                if (upVector != value)
                {
                    upVector = value;
                    viewMatrixRecord.Mark();
                }
            }
        }

        private vec3 position = new vec3(1, 1, 1);

        /// <summary>
        /// Gets or sets world coordinate of the camera 's position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        [Description("world coordinate of the camera 's position.")]
        [Category(strCamera)]
        public vec3 Position
        {
            get { return position; }
            set
            {
                if (position != value)
                {
                    position = value;
                    viewMatrixRecord.Mark();
                }
            }
        }

        private mat4 viewMatrix;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public mat4 GetViewMatrix()
        {
            if (this.viewMatrixRecord.IsMarked())
            {
                this.viewMatrix = glm.lookAt(this.position, this.target, this.upVector);
                this.viewMatrixRecord.CancelMark();
            }

            return this.viewMatrix;
        }

        #endregion IViewCamera
    }
}