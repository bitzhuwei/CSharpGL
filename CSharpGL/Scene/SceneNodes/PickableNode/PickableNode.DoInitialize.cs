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
                var pickerList = new List<PickerBase>();
                foreach (var item in renderUnit.VertexArrayObjects)
                {
                    if (item.DrawCommand is DrawArraysCmd)
                    {
                        pickerList.Add(new ZeroIndexPicker(this, item.VertexAttributes[0].Buffer, item.DrawCommand));
                    }
                    else if (item.DrawCommand is DrawElementsCmd)
                    {
                        pickerList.Add(new OneIndexPicker(this, item.VertexAttributes[0].Buffer, item.DrawCommand));
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
                this.picker = pickerList.ToArray();

                this.PickingRenderUnit = renderUnit;
            }
        }
    }
}