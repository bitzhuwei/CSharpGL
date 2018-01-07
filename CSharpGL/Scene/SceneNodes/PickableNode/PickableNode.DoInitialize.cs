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

            IPickableRenderMethod renderUnit = this.pickingRenderUnitBuilder.ToRenderMethod(this.RenderUnit.Model);
            var pickerList = new List<PickerBase>();
            foreach (var item in renderUnit.VertexArrayObjects)
            {
                if (item.DrawCommand is DrawArraysCmd
                    || item.DrawCommand is MultiDrawArraysCmd)
                {
                    pickerList.Add(new DrawArraysPicker(this, item.VertexAttributes[0].Buffer, item.DrawCommand));
                }
                else if (item.DrawCommand is DrawElementsCmd
                    || item.DrawCommand is MultiDrawElementsCmd) // I don't know what will happen during picking if overlaps exists in glMultiDrawElements(..). I also don't care, because that is modeling's problem.
                {
                    pickerList.Add(new OneIndexPicker(this, item.VertexAttributes[0].Buffer, item.DrawCommand));
                }
                else
                {
                    throw new NotImplementedException(string.Format("`{0}` is a new IDrawCommand. CSharpGL has not supported `IPickable` with it yet.", item.DrawCommand.GetType()));
                }
            }
            this.picker = pickerList.ToArray();

            this.PickingRenderUnit = renderUnit;
        }
    }
}