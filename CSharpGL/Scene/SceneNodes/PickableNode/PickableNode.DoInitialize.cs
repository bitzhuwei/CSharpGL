using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class PickableNode
    {
        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
            base.DoInitialize();

            {
                IPickableRenderMethod renderUnit = this.pickingRenderUnitBuilder.ToRenderMethod(this.RenderUnit.Model);
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