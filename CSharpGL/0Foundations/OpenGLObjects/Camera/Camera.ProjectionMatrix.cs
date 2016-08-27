using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class Camera
    {

        #region IPerspectiveCamera 成员

        double IPerspectiveCamera.FieldOfView { get; set; }

        double IPerspectiveCamera.AspectRatio { get; set; }

        double IPerspectiveCamera.Near { get; set; }

        double IPerspectiveCamera.Far { get; set; }

        #endregion

        #region IOrthoCamera 成员

        double IOrthoCamera.Left { get; set; }

        double IOrthoCamera.Right { get; set; }

        double IOrthoCamera.Bottom { get; set; }

        double IOrthoCamera.Top { get; set; }

        double IOrthoCamera.Near { get; set; }

        double IOrthoCamera.Far { get; set; }

        #endregion

    }
}
