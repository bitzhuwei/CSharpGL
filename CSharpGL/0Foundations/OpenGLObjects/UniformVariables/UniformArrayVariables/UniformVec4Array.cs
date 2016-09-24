namespace CSharpGL
{
    /// <summary>
    /// uniform vec4 variable[10];
    /// </summary>
    public class UniformVec4Array : UniformArrayVariable<vec4>
    {
        /// <summary>
        /// uniform vec4 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformVec4Array(string varName, int length) : base(varName, length) { }

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