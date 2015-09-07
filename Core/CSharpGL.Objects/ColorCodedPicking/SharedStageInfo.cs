﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Objects.ColorCodedPicking
{
    /// <summary>
    /// This type's instance is used in <see cref="ColorCodedPickingScene.Draw(RenderMode.HitTest)"/>
    /// by <see cref="IColorCodedPicking"/> so that sceneElements can get their updated PickingBaseID.
    /// </summary>
    public class SharedStageInfo
    {
        /// <summary>
        /// Gets or sets how many vertices have been rendered during hit test.
        /// </summary>
        public virtual uint RenderedVertexCount { get; set; }

        /// <summary>
        /// Reset this instance's fields' values to initial state so that it can be used again during rendering.
        /// </summary>
        public virtual void Reset()
        {
            RenderedVertexCount = 0;
        }

        public override string ToString()
        {
            return string.Format("rendered {0} primitives during hit test(picking).", RenderedVertexCount);
            //return base.ToString();
        }

        /// <summary>
        /// Render the element that inherts <see cref="IColorCodedPicking"/> for color coded picking.
        /// </summary>
        /// <param name="pickable"></param>
        /// <param name="gl"></param>
        /// <param name="renderMode"></param>
        public virtual void RenderForPicking(IColorCodedPicking pickable, RenderEventArgs e)
        {
            if (pickable != null)
            {
                pickable.PickingBaseID = this.RenderedVertexCount;

                //  render the element.
                IRenderable renderable = pickable;
                renderable.Render(e);

                uint rendered = this.RenderedVertexCount + pickable.GetVertexCount();
                if (this.RenderedVertexCount <= rendered)
                {
                    this.RenderedVertexCount = rendered;
                }
                else
                {
                    throw new OverflowException(
                        string.Format("Too many geometries({0} + {1} > {2}) for color coded picking.",
                            this.RenderedVertexCount, pickable.GetVertexCount(), uint.MaxValue));
                }
            }
        }

    }
}