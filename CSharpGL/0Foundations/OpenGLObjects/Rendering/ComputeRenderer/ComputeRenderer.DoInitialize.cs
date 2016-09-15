namespace CSharpGL
{
    public partial class ComputeRenderer
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            // init shader program.
            ShaderProgram program = this.shaderCodes.CreateProgram();

            // sets fields.
            this.Program = program;
        }
    }
}