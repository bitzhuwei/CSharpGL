using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    partial class SimplexNoiseRenderer
    {
        private uint[] permTextureID = new uint[1];
        private uint[] simplexTextureID = new uint[1];
        private uint[] gradTextureID = new uint[1];

        DateTime lastTime;

        protected override void DoInitialize()
        {
            base.DoInitialize();

            initPermTexture(this.permTextureID);
            initSimplexTexture(this.simplexTextureID);
            initGradTexture(this.gradTextureID);

            lastTime = DateTime.Now;
            this.SetUniform("permTexture", new samplerValue(
                BindTextureTarget.Texture2D, permTextureID[0], OpenGL.GL_TEXTURE0));
            this.SetUniform("simplexTexture", new samplerValue(
                BindTextureTarget.Texture1D, simplexTextureID[0], OpenGL.GL_TEXTURE1));
            this.SetUniform("gradTexture", new samplerValue(
                BindTextureTarget.Texture2D, gradTextureID[0], OpenGL.GL_TEXTURE2));

        }

    }
}
