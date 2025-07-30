namespace CSharpGL {
    /// <summary>
    /// uniform mat2 variable;
    /// </summary>
    public unsafe class UniformMat2 : UniformSingleVariable<mat2> {
        /// <summary>
        /// uniform mat2 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformMat2(string varName) : base(varName) { }

        /// <summary>
        /// uniform mat2 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformMat2(string varName, mat2 value) : base(varName, value) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(GLProgram program) {
            this.location = program.glUniformMatrix2(varName, this.value.ToArray());
            this.updated = false;
        }
    }
}