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

            this.SetUniform("fontTexture", new samplerValue(
                BindTextureTarget.Texture2D,
                fontResource.FontTextureId,
                OpenGL.GL_TEXTURE0));
        }

    }
}
