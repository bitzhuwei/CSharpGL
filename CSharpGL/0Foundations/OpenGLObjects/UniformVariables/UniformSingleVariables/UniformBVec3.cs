namespace CSharpGL
{
    /// <summary>
    /// uniform bvec3 variable;
    /// </summary>
    public class UniformBVec3 : UniformSingleVariable<bvec3>
    {
        /// <summary>
        /// uniform bvec3 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformBVec3(string varName) : base(varName) { }

        /// <summary>
        /// uniform bvec3 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformBVec3(string varName, bvec3 value) : base(varName, value) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value.x ? 1 : 0, value.y ? 1 : 0, value.z ? 1 : 0);
        }
    }
}