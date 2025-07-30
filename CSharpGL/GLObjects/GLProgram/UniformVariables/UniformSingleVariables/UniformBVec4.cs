namespace CSharpGL {
    /// <summary>
    /// uniform bvec4 variable;
    /// </summary>
    public unsafe class UniformBVec4 : UniformSingleVariable<bvec4> {
        /// <summary>
        /// uniform bvec4 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformBVec4(string varName) : base(varName) { }

        /// <summary>
        /// uniform bvec4 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformBVec4(string varName, bvec4 value) : base(varName, value) { }

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