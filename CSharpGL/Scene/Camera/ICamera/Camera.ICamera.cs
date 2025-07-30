﻿using System;
using System.ComponentModel;

namespace CSharpGL {
    public partial class Camera {
        #region ICamera 成员

        /// <summary>
        /// camera's perspective type.
        /// </summary>
        public CameraType CameraType { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public mat4 GetProjectionMatrix() {
            mat4 result;

            switch (this.CameraType) {
            case CameraType.Perspective:
            result = ((IPerspectiveCamera)this).GetPerspectiveProjectionMatrix();
            break;

            case CameraType.Ortho:
            result = ((IOrthoCamera)this).GetOrthoProjectionMatrix();
            break;

            default:
            throw new NotDealWithNewEnumItemException(typeof(CameraType));
            }

            return result;
        }

        #endregion ICamera 成员
    }
}