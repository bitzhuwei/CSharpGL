namespace CSharpGL
{
    /// <summary>
    /// uniform mat4 variable;
    /// </summary>
    public class UniformMat4 : UniformSingleVariable<mat4>
    {
        /// <summary>
        /// uniform mat4 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformMat4(string varName) : base(varName) { }

        /// <summary>
        /// uniform mat4 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformMat4(string varName, mat4 value) : base(varName, value) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniformMatrix4(VarName, this.value.ToArray());
            this.Updated = false;
        }
    }
}