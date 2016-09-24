namespace CSharpGL
{
    /// <summary>
    /// uniform vec4 variable;
    /// </summary>
    public class UniformVec4 : UniformSingleVariable<vec4>
    {
        /// <summary>
        /// uniform vec4 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformVec4(string varName) : base(varName) { }

        /// <summary>
        /// uniform vec4 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformVec4(string varName, vec4 value) : base(varName, value) { }

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