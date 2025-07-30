namespace CSharpGL {
    /// <summary>
    /// uniform bvec3 variable[10];
    /// </summary>
    public unsafe class UniformBVec3Array : UniformArrayVariable<bvec3> {
        /// <summary>
        /// uniform bvec3 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformBVec3Array(string varName, int length) : base(varName, length) { }

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