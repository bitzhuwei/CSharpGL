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
        /// <param name="length"></param>
        public UniformSamplerArray(string varName, int length) : base(varName, length) { }

        private static OpenGL.glActiveTexture activeTexture;

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(ShaderProgram program)
        {
            if (activeTexture == null)
            { activeTexture = OpenGL.GetDelegateFor<OpenGL.glActiveTexture>(); }
            for (int i = 0; i < this.Value.Length; i++)
            {
                samplerValue value = this.Value[i];
                activeTexture(value.activeTextureIndex + OpenGL.GL_TEXTURE0);
                //OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, this.value[i].TextureId);
                OpenGL.BindTexture(value.target, value.TextureId);
                // TODO: assign the first location or last?
                this.Location = program.SetUniform(VarName, value.activeTextureIndex);
            }
        }

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="program"></param>
        //public override void ResetUniform(ShaderProgram program)
        //{
        //    //base.ResetUniform(program);
        //    //if (glActiveTexture == null)
        //    //{ glActiveTexture = OpenGL.GetDelegateFor<OpenGL.glActiveTexture>(); }
        //    //glActiveTexture(value.ActiveTextureIndex);
        //    ////OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
        //    //OpenGL.BindTexture(value.target, 0);
        //}
    }
}