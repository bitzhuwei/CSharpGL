namespace CSharpGL {
    /// <summary>
    /// uniform ivec3 variable[10];
    /// </summary>
    public unsafe class UniformIVec3Array : UniformArrayVariable<ivec3> {
        /// <summary>
        /// uniform vec3 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformIVec3Array(string varName, int length) : base(varName, length) { }

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