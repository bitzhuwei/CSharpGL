namespace CSharpGL
{
    /// <summary>
    /// uniform uvec3 variable;
    /// </summary>
    public class UniformUVec3 : UniformSingleVariable<uvec3>
    {
        /// <summary>
        /// uniform uvec3 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformUVec3(string varName) : base(varName) { }

        /// <summary>
        /// uniform uvec3 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformUVec3(string varName, uvec3 value) : base(varName, value) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value.x, value.y, value.z);
        }
    }
}