namespace CSharpGL
{
    public partial class ModernNode
    {

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        /// <summary>
        /// 
        /// </summary>
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        /// <summary>
        /// Render something before renddering children.
        /// </summary>
        /// <param name="arg"></param>
        public abstract void RenderBeforeChildren(RenderEventArgs arg);

        /// <summary>
        /// Render something after renddering children.
        /// </summary>
        /// <param name="arg"></param>
        public abstract void RenderAfterChildren(RenderEventArgs arg);

        #endregion
    }
}