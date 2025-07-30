namespace CSharpGL {
    /// <summary>
    /// uniform float variable[10];
    /// </summary>
    public unsafe class UniformFloatArray : UniformArrayVariable<float> {
        /// <summary>
        /// uniform float variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformFloatArray(string varName, int length) : base(varName, length) { }

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