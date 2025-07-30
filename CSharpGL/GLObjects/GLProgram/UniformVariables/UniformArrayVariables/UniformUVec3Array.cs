namespace CSharpGL {
    /// <summary>
    /// uniform uvec3 variable[10];
    /// </summary>
    public unsafe class UniformUVec3Array : UniformArrayVariable<uvec3> {
        /// <summary>
        /// uniform vec3 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformUVec3Array(string varName, int length) : base(varName, length) { }

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