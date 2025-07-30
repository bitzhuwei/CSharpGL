namespace CSharpGL {
    /// <summary>
    /// uniform ivec4 variable;
    /// </summary>
    public unsafe class UniformIVec4 : UniformSingleVariable<ivec4> {
        /// <summary>
        /// uniform ivec4 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformIVec4(string varName) : base(varName) { }

        /// <summary>
        /// uniform ivec4 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformIVec4(string varName, ivec4 value) : base(varName, value) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(GLProgram program) {
            this.location = program.glUniform(varName, value.x, value.y, value.z, value.w);
            this.updated = false;
        }
    }
}