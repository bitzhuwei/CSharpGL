using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class Camera
    {

        #region ICamera 成员

        private const string strCamera = "Camera";

        /// <summary>
        /// camera's perspective type.
        /// </summary>
        [Category(strCamera)]
        public CameraType CameraType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public mat4 GetProjectionMatrix()
        {
            mat4 result;

            switch (this.CameraType)
            {
                case CameraType.Perspecitive:
                    result = ((IPerspectiveCamera)this).GetPerspectiveProjectionMatrix();
                    break;
                case CameraType.Ortho:
                    result = ((IOrthoCamera)this).GetOrthoProjectionMatrix();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        #endregion ICamera

    }
}
