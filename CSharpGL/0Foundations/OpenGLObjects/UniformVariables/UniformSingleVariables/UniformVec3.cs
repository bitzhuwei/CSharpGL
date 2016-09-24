namespace CSharpGL
{
    /// <summary>
    /// uniform vec3 variable;
    /// </summary>
    public class UniformVec3 : UniformSingleVariable<vec3>
    {
        /// <summary>
        /// uniform vec3 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformVec3(string varName) : base(varName) { }

        /// <summary>
        /// uniform vec3 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformVec3(string varName, vec3 value) : base(varName, value) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value.x, value.y, value.z);
            this.Updated = false;
        }
    }
}