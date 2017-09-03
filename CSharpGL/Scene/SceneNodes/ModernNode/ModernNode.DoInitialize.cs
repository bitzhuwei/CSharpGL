using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class ModernNode
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            foreach (var item in this.builders)
            {
                var renderUnit = item.ToRenderUnit(this.model);
                this.renderUnits.Add(renderUnit);
            }
        }
    }
}