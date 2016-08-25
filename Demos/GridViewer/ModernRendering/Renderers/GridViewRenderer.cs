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
    public abstract class GridViewRenderer : Renderer, IRectangle3D
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

        public virtual Rectangle3D GetRectangle()
        {
            var max = this.Lengths / 2;
            var min = -max;
            vec3 position = this.ModelMatrix.GetTranslate();
            var result = new Rectangle3D(min + position, max + position);

            return result;
        }

    }
}
