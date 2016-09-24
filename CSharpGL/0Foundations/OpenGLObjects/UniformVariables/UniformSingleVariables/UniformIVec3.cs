namespace CSharpGL
{
    /// <summary>
    /// uniform ivec3 variable;
    /// </summary>
    public class UniformIVec3 : UniformSingleVariable<ivec3>
    {
        /// <summary>
        /// uniform ivec3 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformIVec3(string varName) : base(varName) { }

        /// <summary>
        /// uniform ivec3 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformIVec3(string varName, ivec3 value) : base(varName, value) { }

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