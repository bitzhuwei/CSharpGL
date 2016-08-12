using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public partial class LabelRenderer
    {

        /// <summary>
        /// 
        /// </summary>
        protected override void DoInitialize()
        {
            base.DoInitialize();

            //int[] viewport = OpenGL.GetViewport();
            //this.SetUniform("pixelScale", (float)viewport[2]);
            //this.SetUniform("fontHeight", (float)fontResource.FontHeight);
            //this.SetUniform("textColor", new vec3(1, 0, 0));
            this.SetUniform("fontTexture",
                this.fontTexture.TextureObj.ToSamplerValue());
        }

    }
}
