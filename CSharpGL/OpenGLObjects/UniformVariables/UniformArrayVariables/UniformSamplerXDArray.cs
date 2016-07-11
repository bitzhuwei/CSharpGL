
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform samplerXD variable[10];
    /// </summary>
    public class UniformSamplerArray : UniformArrayVariable<samplerValue>
    {

        /// <summary>
        /// uniform samplerXD variable[10];
        /// </summary>
        /// <param name="varName"></param>
        public UniformSamplerArray(string varName) : base(varName) { }

        static OpenGL.glActiveTexture glActiveTexture = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            if (glActiveTexture == null)
            { glActiveTexture = OpenGL.GetDelegateFor<OpenGL.glActiveTexture>(); }
            for (int i = 0; i < this.Value.Length; i++)
            {
                samplerValue value = this.Value[i];
                glActiveTexture(value.ActiveTextureIndex);
                //OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, this.value[i].TextureId);
                OpenGL.BindTexture(value.target, value.TextureId);
                // TODO: assign the first location or last?
                this.Location = program.SetUniform(VarName, value.activeTextureIndex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
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
