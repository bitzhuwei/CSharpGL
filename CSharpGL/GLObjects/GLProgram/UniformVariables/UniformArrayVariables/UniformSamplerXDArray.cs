namespace CSharpGL {
    /// <summary>
    /// uniform samplerXD variable[10];
    /// </summary>
    public unsafe class UniformSamplerArray : UniformArrayVariable<samplerValue> {
        /// <summary>
        /// uniform samplerXD variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformSamplerArray(string varName, int length)
            : base(varName, length) {
        }

        //private static GLDelegates.void_uint activeTexture;

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(GLProgram program) {
            //if (glActiveTexture == null) { glActiveTexture = gl.glGetDelegateFor("glActiveTexture", GLDelegates.typeof_void_uint) as GLDelegates.void_uint; }
            var gl = GL.current; if (gl == null) { return; }
            for (int i = 0; i < this.Value.Length; i++) {
                samplerValue value = this.Value[i];
                gl.glActiveTexture(value.TextureUnitIndex + GL.GL_TEXTURE0);
                //OpenGL.BindTexture(GL.GL_TEXTURE_2D, this.value[i].TextureId);
                gl.glBindTexture(value.target, value.TextureId);
                // TODO: assign the first location or last? 20171117:maybe I should not create this type.
                this.location = program.glUniform(varName, (int)value.TextureUnitIndex);
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
        //    ////OpenGL.BindTexture(GL.GL_TEXTURE_2D, 0);
        //    //OpenGL.BindTexture(value.target, 0);
        //}
    }
}