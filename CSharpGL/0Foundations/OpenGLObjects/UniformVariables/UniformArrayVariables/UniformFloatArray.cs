namespace CSharpGL
{
    /// <summary>
    /// uniform float variable[10];
    /// </summary>
    public class UniformFloatArray : UniformArrayVariable<float>
    {
        /// <summary>
        /// uniform float variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformFloatArray(string varName, int length) : base(varName, length) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, this.Value.Array);
        }
    }
}