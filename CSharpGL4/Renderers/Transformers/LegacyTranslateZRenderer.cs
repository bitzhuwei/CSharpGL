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

        public void RenderForLegacyPicking(LegacyPickEventArgs arg)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
