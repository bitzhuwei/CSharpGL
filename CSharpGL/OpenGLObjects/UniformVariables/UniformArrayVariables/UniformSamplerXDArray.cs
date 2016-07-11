
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
    public class UniformSamplerArray : UniformArrayVariable
    {

        private samplerValue[] value;
        /// <summary>
        /// 
        /// </summary>
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
            for (int i = 0; i < this.value.Length; i++)
            {
                glActiveTexture(this.value[i].ActiveTextureIndex);
                //OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, this.value[i].TextureId);
                OpenGL.BindTexture(this.value[i].target, this.value[i].TextureId);
                // TODO: assign the first location or last?
                this.Location = program.SetUniform(VarName, this.value[i].activeTextureIndex);
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1}: {2}", this.GetType().Name, this.VarName, this.value.PrintArray(", "));
        }
    }

}
