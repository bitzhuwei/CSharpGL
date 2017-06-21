using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class LegacyTranslateZRenderer : RendererBase, ILegacyPickable
    {
        #region ILegacyPickable 成员

        public bool LegacyPickingEnabled
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

        public void RenderBeforeChildrenForLegacyPicking(LegacyPickEventArgs arg)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Render this model after rendering its children in legacy OpenGL.
        /// </summary>
        /// <param name="arg"></param>
        public void RenderAfterChildrenForLegacyPicking(LegacyPickEventArgs arg) { }

        #endregion
    }
}
