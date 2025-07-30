namespace CSharpGL {
    /// <summary>
    /// uniform mat4 variable;
    /// </summary>
    public unsafe class UniformMat4 : UniformSingleVariable<mat4> {
        /// <summary>
        /// uniform mat4 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformMat4(string varName) : base(varName) { }

        /// <summary>
        /// uniform mat4 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformMat4(string varName, mat4 value) : base(varName, value) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(GLProgram program) {
            this.location = program.glUniformMatrix4(varName, this.value.ToArray());
            this.updated = false;
        }
    }
}