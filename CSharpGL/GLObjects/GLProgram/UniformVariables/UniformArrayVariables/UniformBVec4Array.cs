namespace CSharpGL {
    /// <summary>
    /// uniform bvec4 variable[10];
    /// </summary>
    public unsafe class UniformBVec4Array : UniformArrayVariable<bvec4> {
        /// <summary>
        /// uniform bvec4 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformBVec4Array(string varName, int length) : base(varName, length) { }

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