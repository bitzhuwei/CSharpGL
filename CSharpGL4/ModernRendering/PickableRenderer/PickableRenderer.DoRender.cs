namespace CSharpGL
{
    public partial class PickableRenderer
    {
        #region IRenderable 成员

        private bool renderingEnabled = true;
        /// <summary>
        /// 
        /// </summary>
        public bool RenderingEnabled { get { return renderingEnabled; } set { renderingEnabled = value; } }

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        public void Render(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            DoRender(arg);
        }

        #endregion

        /// <summary>
        /// Render something.
        /// </summary>
        protected virtual void DoRender(RenderEventArgs arg)
        {
            ShaderProgram program = this.RenderProgram;

            // 绑定shader
            program.Bind();
            program.PushUniforms();

            this.stateList.On();

            this.vertexArrayObject.Render(program);

            this.stateList.Off();

            // 解绑shader
            program.Unbind();
        }

    }
}