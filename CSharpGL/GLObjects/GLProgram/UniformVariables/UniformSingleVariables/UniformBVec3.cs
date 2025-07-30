namespace CSharpGL {
    /// <summary>
    /// uniform bvec3 variable;
    /// </summary>
    public unsafe class UniformBVec3 : UniformSingleVariable<bvec3> {
        /// <summary>
        /// uniform bvec3 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformBVec3(string varName) : base(varName) { }

        /// <summary>
        /// uniform bvec3 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformBVec3(string varName, bvec3 value) : base(varName, value) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(GLProgram program) {
            this.location = program.glUniform(varName, value.x, value.y, value.z);
            this.updated = false;
        }
    }
}