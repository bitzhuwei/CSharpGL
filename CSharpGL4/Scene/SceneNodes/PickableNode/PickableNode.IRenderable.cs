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
        public abstract void RenderBeforeChildren(RenderEventArgs arg);

        public abstract void RenderAfterChildren(RenderEventArgs arg);

        #endregion
    }
}