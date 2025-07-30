namespace CSharpGL {
    /// <summary>
    /// uniform bool variable;
    /// </summary>
    public unsafe class UniformBool : UniformSingleVariable<bool> {
        /// <summary>
        /// uniform bool variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformBool(string varName) : base(varName) { }

        /// <summary>
        /// uniform bool variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformBool(string varName, bool value) : base(varName, value) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(GLProgram program) {
            this.location = program.glUniform(varName, value ? 1 : 0);
            this.updated = false;
        }
    }
}