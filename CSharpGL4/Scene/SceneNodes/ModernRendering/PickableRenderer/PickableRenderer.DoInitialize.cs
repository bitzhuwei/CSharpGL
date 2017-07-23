using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class PickableRenderer
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            foreach (var item in this.builders)
            {
                RenderUnit renderUnit = item.ToRenderUnit(this.model);
                this.renderUnits.Add(renderUnit);
            }

            {
                IPickableRenderUnit renderUnit = this.pickingRenderUnitBuilder.ToRenderUnit(this.model);
                if (renderUnit.VertexArrayObject.IndexBuffer is ZeroIndexBuffer)
                {
                    this.picker = new ZeroIndexPicker(this);
                }
                else if (renderUnit.VertexArrayObject.IndexBuffer is OneIndexBuffer)
                {
                    this.picker = new OneIndexPicker(this);
                }

                this.PickingRenderUnit = renderUnit;
            }
        }
    }
}