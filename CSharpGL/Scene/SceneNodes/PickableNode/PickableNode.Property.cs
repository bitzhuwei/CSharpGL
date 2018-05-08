using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class PickableNode
    {
        private const string strPickableRenderer = "PickableRenderer";

        ///// <summary>
        ///// 
        ///// </summary>
        //[Category(strPickableRenderer)]
        //[Description("rendering in multiple ways.")]
        //public ModernRenderUnit RenderUnit { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        [Category(strPickableRenderer)]
        [Description("Takes care of rendering for picking.")]
        public IPickableRenderMethod PickingRenderMethod { get; private set; }

    }
}