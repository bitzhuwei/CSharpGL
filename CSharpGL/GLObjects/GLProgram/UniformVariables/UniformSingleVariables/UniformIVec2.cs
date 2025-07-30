namespace CSharpGL {
    /// <summary>
    /// uniform ivec2 variable;
    /// </summary>
    public unsafe class UniformIVec2 : UniformSingleVariable<ivec2> {
        /// <summary>
        /// uniform ivec2 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformIVec2(string varName) : base(varName) { }

        /// <summary>
        /// uniform ivec2 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformIVec2(string varName, ivec2 value) : base(varName, value) { }

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