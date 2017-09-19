using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FrontToBackPeeling
{
    class PeelingNode : SceneNodeBase, IRenderable
    {
        #region IRenderable 成员

        public ThreeFlags EnableRendering
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

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
