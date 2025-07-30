namespace CSharpGL {
    /// <summary>
    /// uniform uvec4 variable[10];
    /// </summary>
    public unsafe class UniformUVec4Array : UniformArrayVariable<uvec4> {
        /// <summary>
        /// uniform uvec4 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformUVec4Array(string varName, int length) : base(varName, length) { }

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