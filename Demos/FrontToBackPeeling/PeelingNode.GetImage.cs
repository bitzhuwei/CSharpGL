using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace FrontToBackPeeling
{
    partial class PeelingNode
    {
        Bitmap GetImage(Texture texture)
        {
            var bmp = new Bitmap(this.width, this.height);
            var data = bmp.LockBits(new Rectangle(0, 0, this.width, this.height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.Instance.GetTexImage((uint)texture.Target, 0, texture.Storage.internalFormat, GL.GL_FLOAT, data.Scan0);
            bmp.UnlockBits(data);

            return bmp;
        }
    }
}
