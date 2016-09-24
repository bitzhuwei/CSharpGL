namespace CSharpGL
{
    /// <summary>
    /// uniform uvec4 variable;
    /// </summary>
    public class UniformUVec4 : UniformSingleVariable<uvec4>
    {
        /// <summary>
        /// uniform uvec4 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformUVec4(string varName) : base(varName) { }

        /// <summary>
        /// uniform uvec4 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformUVec4(string varName, uvec4 value) : base(varName, value) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value.x, value.y, value.z, value.w);
            this.Updated = false;
        }
    }
}