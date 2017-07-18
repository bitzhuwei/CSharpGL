using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class Renderer
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            foreach (var item in this.builders)
            {
                var renderUnit = item.ToRenderUnit();
                this.renderUnits.Add(renderUnit);
            }
        }
    }
}