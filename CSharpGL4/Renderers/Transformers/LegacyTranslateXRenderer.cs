using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class LegacyTranslateXRenderer : RendererBase, ILegacyPickable
    {
        #region ILegacyPickable 成员

        private bool legacyPickingEnabled = true;
        public bool LegacyPickingEnabled
        {
            get { return this.legacyPickingEnabled; }
            set { this.legacyPickingEnabled = value; }
        }

        public void RenderForLegacyPicking(LegacyPickEventArgs arg)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
