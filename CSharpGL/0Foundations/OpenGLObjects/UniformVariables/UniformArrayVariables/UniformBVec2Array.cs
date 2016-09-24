namespace CSharpGL
{
    /// <summary>
    /// uniform bvec2 variable[10];
    /// </summary>
    public class UniformBVec2Array : UniformArrayVariable<bvec2>
    {
        /// <summary>
        /// uniform bvec2 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformBVec2Array(string varName, int length) : base(varName, length) { }

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