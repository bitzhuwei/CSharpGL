using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class LegacyTranslateYRenderer : RendererBase, ILegacyPickable
    {
        #region ILegacyPickable 成员

        private bool legacyPickingEnabled = true;
        public bool LegacyPickingEnabled
        {
            get { return legacyPickingEnabled; }
            set { legacyPickingEnabled = value; }
        }

        private bool legacyPickingChildrenEnabled = true;
        /// <summary>
        /// picking in children.
        /// </summary>
        public bool LegacyPickingChildrenEnabled
        {
            get { return legacyPickingChildrenEnabled; }
            set { legacyPickingChildrenEnabled = value; }
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
