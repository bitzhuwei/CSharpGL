namespace CSharpGL
{
    /// <summary>
    /// uniform uvec4 variable[10];
    /// </summary>
    public class UniformUVec4Array : UniformArrayVariable<uvec4>
    {
        /// <summary>
        /// uniform uvec4 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformUVec4Array(string varName, int length) : base(varName, length) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, this.Value.Array);
            this.Updated = false;
        }
    }
}