﻿using System;
using System.Collections.Generic;

namespace CSharpGL {
    public partial class PickableNode {
        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize() {
            base.DoInitialize();

            IPickableRenderMethod renderMethod = this.pickingRenderMethodBuilder.ToRenderMethod(this.RenderUnit.Model);
            var pickerList = new List<PickerBase>();
            foreach (var vao in renderMethod.VertexArrayObjects) {
                IDrawCommand cmd = vao.DrawCommand;
                if (cmd is DrawArraysCmd drawArraysCmd)
                //|| cmd is MultiDrawArraysCmd)
                {
                    //I don't know what will happen during picking if 'overlap' exists in glMultiDrawArrays(..). I don't care either, because that is a problem that should be solved in modeling stage.
                    VertexBuffer positionBuffer = vao.VertexAttributes[0].buffer; // according to base.DoInitialize(), this is the position buffer of the only vertex attribute.
                    pickerList.Add(new DrawArraysPicker(this, positionBuffer, drawArraysCmd));
                }
                else if (cmd is DrawElementsCmd drawElementsCmd)
                //|| cmd is MultiDrawElementsCmd)
                {
                    //I don't know what will happen during picking if 'overlap' exists in glMultiDrawElements(..). I don't care either, because that is a problem that should be solved in modeling stage.
                    VertexBuffer positionBuffer = vao.VertexAttributes[0].buffer; // according to base.DoInitialize(), this is the position buffer of the only vertex attribute.
                    pickerList.Add(new DrawElementsPicker(this, positionBuffer, drawElementsCmd));
                }
                else {
                    throw new NotImplementedException(string.Format("`{0}` is a IDrawCommand type that has not been supported for `IPickable`.", cmd.GetType()));
                }
            }
            this.picker = pickerList.ToArray();

            this.PickingRenderMethod = renderMethod;
        }
    }
}