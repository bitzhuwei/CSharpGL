namespace CSharpGL
{
    /// <summary>
    /// uniform vec2 variable;
    /// </summary>
    public class UniformVec2 : UniformSingleVariable<vec2>
    {
        /// <summary>
        /// uniform vec2 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformVec2(string varName) : base(varName) { }

        /// <summary>
        /// uniform vec2 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformVec2(string varName, vec2 value) : base(varName, value) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value.x, value.y);
            this.Updated = false;
        }
    }
}