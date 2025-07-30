namespace CSharpGL {
    /// <summary>
    /// uniform ivec4 variable[10];
    /// </summary>
    public unsafe class UniformIVec4Array : UniformArrayVariable<ivec4> {
        /// <summary>
        /// uniform vec4 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformIVec4Array(string varName, int length) : base(varName, length) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(GLProgram program) {
            this.location = program.glUniform(varName, this.Value.Array);
            this.updated = false;
        }
    }
}