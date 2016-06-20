using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class LabelRenderer
    {

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
