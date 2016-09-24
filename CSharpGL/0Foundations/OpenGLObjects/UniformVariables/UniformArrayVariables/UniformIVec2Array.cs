namespace CSharpGL
{
    /// <summary>
    /// uniform ivec2 variable[10];
    /// </summary>
    public class UniformIVec2Array : UniformArrayVariable<ivec2>
    {
        /// <summary>
        /// uniform vec2 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformIVec2Array(string varName, int length) : base(varName, length) { }

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