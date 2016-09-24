namespace CSharpGL
{
    /// <summary>
    /// uniform ivec3 variable[10];
    /// </summary>
    public class UniformIVec3Array : UniformArrayVariable<ivec3>
    {
        /// <summary>
        /// uniform vec3 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformIVec3Array(string varName, int length) : base(varName, length) { }

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