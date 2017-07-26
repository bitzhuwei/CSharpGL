using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class ModernNode
    {
        private const string strModernNode = "ModernNode";
        private List<RenderUnit> renderUnits = new List<RenderUnit>();
        /// <summary>
        /// 
        /// </summary>
        [Category(strModernNode)]
        [Description("Each render unit takes care of one way of rendering.")]
        public List<RenderUnit> RenderUnits { get { return this.renderUnits; } }

    }
}