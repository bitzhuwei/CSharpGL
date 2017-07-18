namespace CSharpGL
{
    public partial class PickableRenderer
    {
        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        public virtual void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            DoRender(arg);
        }

        public virtual void RenderAfterChildren(RenderEventArgs arg)
        {
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