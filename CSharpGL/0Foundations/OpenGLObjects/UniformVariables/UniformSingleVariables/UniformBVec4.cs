namespace CSharpGL
{
    /// <summary>
    /// uniform bvec4 variable;
    /// </summary>
    public class UniformBVec4 : UniformSingleVariable<bvec4>
    {
        /// <summary>
        /// uniform bvec4 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformBVec4(string varName) : base(varName) { }

        /// <summary>
        /// uniform bvec4 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformBVec4(string varName, bvec4 value) : base(varName, value) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value.x ? 1 : 0, value.y ? 1 : 0, value.z ? 1 : 0, value.w ? 1 : 0);
            this.Updated = false;
        }
    }
}