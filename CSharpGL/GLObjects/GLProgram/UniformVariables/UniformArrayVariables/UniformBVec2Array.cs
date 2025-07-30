namespace CSharpGL {
    /// <summary>
    /// uniform bvec2 variable[10];
    /// </summary>
    public unsafe class UniformBVec2Array : UniformArrayVariable<bvec2> {
        /// <summary>
        /// uniform bvec2 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformBVec2Array(string varName, int length) : base(varName, length) { }

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