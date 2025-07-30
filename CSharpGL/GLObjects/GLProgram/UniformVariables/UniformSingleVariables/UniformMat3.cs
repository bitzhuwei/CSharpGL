namespace CSharpGL {
    /// <summary>
    /// uniform mat3 variable;
    /// </summary>
    public unsafe class UniformMat3 : UniformSingleVariable<mat3> {
        /// <summary>
        /// uniform mat3 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformMat3(string varName) : base(varName) { }

        /// <summary>
        /// uniform mat3 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformMat3(string varName, mat3 value) : base(varName, value) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(GLProgram program) {
            this.location = program.glUniformMatrix3(varName, this.value.ToArray());
            this.updated = false;
        }
    }
}