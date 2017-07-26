using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class PickableNode
    {
        private const string strPickableRenderer = "PickableRenderer";

        private List<RenderUnit> renderUnits = new List<RenderUnit>();
        /// <summary>
        /// 
        /// </summary>
        [Category(strPickableRenderer)]
        [Description("Each render unit takes care of one way of rendering.")]
        public List<RenderUnit> RenderUnits { get { return this.renderUnits; } }

        /// <summary>
        /// 
        /// </summary>
        [Category(strPickableRenderer)]
        [Description("Takes care of rendering for picking.")]
        public IPickableRenderUnit PickingRenderUnit { get; private set; }
    }
}