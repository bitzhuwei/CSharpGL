//using System.ComponentModel;
//namespace CSharpGL
//{
//    public partial class ModernNode
//    {
//        #region IRenderable 成员

//        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
//        /// <summary>
//        /// Render before/after children? Render children? 
//        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
//        /// </summary>
//        [Browsable(false)]
//        [Category(strModernNode)]
//        [Description("Render before/after children? Render children?")]
//        public ThreeFlags EnableRendering
//        {
//            get { return this.enableRendering; }
//            set { this.enableRendering = value; }
//        }

//        /// <summary>
//        /// Render something before renddering children.
//        /// </summary>
//        /// <param name="arg"></param>
//        public abstract void RenderBeforeChildren(RenderEventArgs arg);

//        /// <summary>
//        /// Render something after renddering children.
//        /// </summary>
//        /// <param name="arg"></param>
//        public abstract void RenderAfterChildren(RenderEventArgs arg);

//        #endregion
//    }
//}