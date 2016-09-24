namespace CSharpGL
{
    /// <summary>
    /// uniform mat3 variable[10];
    /// </summary>
    public class UniformMat3Array : UniformArrayVariable<mat3>
    {
        /// <summary>
        /// uniform mat3 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformMat3Array(string varName, int length) : base(varName, length) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniformMatrix3(VarName, this.Value.Array);
            this.Updated = false;
        }
    }
}