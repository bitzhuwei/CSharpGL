namespace CSharpGL
{
    /// <summary>
    /// uniform mat4 variable[10];
    /// </summary>
    public class UniformMat4Array : UniformArrayVariable<mat4>
    {
        /// <summary>
        /// uniform mat4 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformMat4Array(string varName, int length) : base(varName, length) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniformMatrix4(VarName, this.Value.Array);
            this.Updated = false;
        }
    }
}