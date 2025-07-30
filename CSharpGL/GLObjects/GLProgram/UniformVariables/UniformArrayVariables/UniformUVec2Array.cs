namespace CSharpGL {
    /// <summary>
    /// uniform uvec2 variable[10];
    /// </summary>
    public unsafe class UniformUVec2Array : UniformArrayVariable<uvec2> {
        /// <summary>
        /// uniform vec2 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformUVec2Array(string varName, int length) : base(varName, length) { }

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