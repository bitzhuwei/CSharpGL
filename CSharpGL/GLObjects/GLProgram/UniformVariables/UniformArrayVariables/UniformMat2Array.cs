namespace CSharpGL {
    /// <summary>
    /// uniform mat2 variable[10];
    /// </summary>
    public unsafe class UniformMat2Array : UniformArrayVariable<mat2> {
        /// <summary>
        /// uniform mat2 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformMat2Array(string varName, int length) : base(varName, length) { }

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