﻿using System.ComponentModel;

namespace CSharpGL {
    public partial class Camera {
        #region IViewCamera

        private UpdatingRecord viewMatRecord = new UpdatingRecord(true);

        private vec3 target;

        /// <summary>
        /// Gets or sets world coordinate of the camera's target(the point it's looking at).
        /// </summary>
        public vec3 Target {
            get { return target; }
            set {
                if (target != value) {
                    target = value;
                    viewMatRecord.Mark();
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
        public vec3 UpVector {
            get { return upVector; }
            set {
                if (upVector != value) {
                    upVector = value;
                    viewMatRecord.Mark();
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
        public vec3 Position {
            get { return position; }
            set {
                if (position != value) {
                    position = value;
                    viewMatRecord.Mark();
                }
            }
        }

        private mat4 viewMat;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public mat4 GetViewMatrix() {
            if (this.viewMatRecord.IsMarked()) {
                this.viewMat = glm.lookAt(this.position, this.target, this.upVector);
                this.viewMatRecord.CancelMark();
            }

            return this.viewMat;
        }

        #endregion IViewCamera
    }
}