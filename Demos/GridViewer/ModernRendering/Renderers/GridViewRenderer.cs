using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    /// <summary>
    /// base renderer for gridview.
    /// </summary>
    public abstract class GridViewRenderer : Renderer
    {
        /// <summary>
        /// gridview's model.
        /// </summary>
        public GridViewModel Grid { get; private set; }

        protected GridViewRenderer(vec3 originalWorldPosition, GridViewModel model, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(model, shaderCodes, propertyNameMap, switches)
        {
            this.OriginalWorldPosition = originalWorldPosition;
            this.Grid = model;
        }

        public virtual BoundingBox GetRectangle()
        {
            var max = this.Lengths / 2;
            var min = -max;
            vec3 position = this.OriginalWorldPosition;
            var result = new BoundingBox(min + position, max + position);

            return result;
        }

    }
}
