namespace CSharpGL
{
    /// <summary>
    /// uniform bvec2 variable;
    /// </summary>
    public class UniformBVec2 : UniformSingleVariable<bvec2>
    {
        /// <summary>
        /// uniform bvec2 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformBVec2(string varName) : base(varName) { }

        /// <summary>
        /// uniform bvec2 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformBVec2(string varName, bvec2 value) : base(varName, value) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value.x ? 1 : 0, value.y ? 1 : 0);
        }
    }
}