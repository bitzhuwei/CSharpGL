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
        /// <param name="picking"></param>
        /// <param name="gl"></param>
        /// <param name="renderMode"></param>
        public virtual void RenderForPicking(IColorCodedPicking picking, RenderModes renderMode)
        {
            if (picking != null)
            {
                picking.PickingBaseID = this.RenderedVertexCount;

                //  render the element.
                IRenderable renderable = picking;
                renderable.Render(renderMode);

                uint rendered = this.RenderedVertexCount + picking.GetVertexCount();
                if (this.RenderedVertexCount <= rendered)
                {
                    this.RenderedVertexCount = rendered;
                }
                else
                {
                    throw new OverflowException(
                        string.Format("Too many geometries({0} + {1} > {2}) for color coded picking.",
                            this.RenderedVertexCount, picking.GetVertexCount(), uint.MaxValue));
                }
            }
        }

    }
}