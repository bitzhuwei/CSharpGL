using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FrontToBackPeeling
{
    partial class PeelingNode : SceneNodeBase, IRenderable
    {

        public PeelingNode()
        {

        }

        #region IRenderable 成员

        public ThreeFlags EnableRendering { get { return ThreeFlags.BeforeChildren; } set { } }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {

            throw new NotImplementedException();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
