namespace CSharpGL {
    /// <summary>
    /// uniform mat3 variable[10];
    /// </summary>
    public unsafe class UniformMat3Array : UniformArrayVariable<mat3> {
        /// <summary>
        /// uniform mat3 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformMat3Array(string varName, int length) : base(varName, length) { }

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