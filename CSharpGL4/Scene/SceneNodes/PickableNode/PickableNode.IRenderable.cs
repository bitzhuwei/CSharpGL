namespace CSharpGL
{
    public partial class PickableNode
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
        }

        public virtual void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}