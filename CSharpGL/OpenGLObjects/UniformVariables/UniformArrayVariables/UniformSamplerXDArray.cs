
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{

    public class UniformSamplerArray : UniformArrayVariable
    {

        private samplerValue[] value;

        public samplerValue[] Value
        {
            get { return this.value; }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    this.Updated = true;
                }
            }
        }

        public UniformSamplerArray(string varName) : base(varName) { }

        static OpenGL.glActiveTexture glActiveTexture = null;

        public override void SetUniform(ShaderProgram program)
        {
            if (glActiveTexture == null)
            { glActiveTexture = OpenGL.GetDelegateFor<OpenGL.glActiveTexture>(); }
            for (int i = 0; i < this.value.Length; i++)
            {
                glActiveTexture(this.value[i].ActiveTextureIndex);
                //OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, this.value[i].TextureId);
                OpenGL.BindTexture(this.value[i].target, this.value[i].TextureId);
                program.SetUniform(VarName, this.value[i].activeTextureIndex);
            }
        }

        public override void ResetUniform(ShaderProgram program)
        {
            //base.ResetUniform(program);
            //if (glActiveTexture == null)
            //{ glActiveTexture = OpenGL.GetDelegateFor<OpenGL.glActiveTexture>(); }
            //glActiveTexture(value.ActiveTextureIndex);
            ////OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
            //OpenGL.BindTexture(value.target, 0);
        }

    }

}
