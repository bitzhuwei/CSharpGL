namespace CSharpGL {
    /// <summary>
    /// uniform uvec2 variable;
    /// </summary>
    public unsafe class UniformUVec2 : UniformSingleVariable<uvec2> {
        /// <summary>
        /// uniform uvec2 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformUVec2(string varName) : base(varName) { }

        /// <summary>
        /// uniform uvec2 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformUVec2(string varName, uvec2 value) : base(varName, value) { }

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