using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
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
        public virtual uint RenderedVertexCount { get; private set; }

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
        public virtual void RenderForPicking(IColorCodedPicking pickable, RenderEventArgs arg)
        {
            if (pickable != null)
            {
                pickable.SetPickingBaseID(this.RenderedVertexCount);

                //  render the element.
                pickable.Render(arg);

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