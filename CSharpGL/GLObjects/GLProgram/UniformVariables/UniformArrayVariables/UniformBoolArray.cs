namespace CSharpGL {
    /// <summary>
    /// uniform bool variable[10];
    /// </summary>
    public unsafe class UniformBoolArray : UniformArrayVariable<bool> {
        /// <summary>
        /// uniform bool variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformBoolArray(string varName, int length) : base(varName, length) { }

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