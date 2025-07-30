namespace CSharpGL {
    /// <summary>
    /// uniform bvec2 variable;
    /// </summary>
    public unsafe class UniformBVec2 : UniformSingleVariable<bvec2> {
        /// <summary>
        /// uniform bvec2 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformBVec2(string varName) : base(varName) { }

        /// <summary>
        /// uniform bvec2 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformBVec2(string varName, bvec2 value) : base(varName, value) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(GLProgram program) {
            this.location = program.glUniform(varName, value.x, value.y);
            this.updated = false;
        }
    }
}