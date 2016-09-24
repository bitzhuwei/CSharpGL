namespace CSharpGL
{
    /// <summary>
    /// uniform int variable;
    /// </summary>
    public class UniformInt32 : UniformSingleVariable<int>
    {
        /// <summary>
        /// uniform int variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformInt32(string varName) : base(varName) { }

        /// <summary>
        /// uniform int variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformInt32(string varName, int value) : base(varName, value) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value);
            this.Updated = false;
        }
    }
}