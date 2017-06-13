namespace CSharpGL
{
    public partial class Renderer
    {

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        public void Render(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            DoRender(arg);
        }

        /// <summary>
        /// Render something.
        /// </summary>
        protected virtual void DoRender(RenderEventArgs arg)
        {
            ShaderProgram program = this.Program;

            // 绑定shader
            program.Bind();
            program.PushUniforms();

            this.stateList.On();

            this.vertexArrayObject.Render(arg, program);

            this.stateList.Off();

            // 解绑shader
            program.Unbind();
        }

    }
}