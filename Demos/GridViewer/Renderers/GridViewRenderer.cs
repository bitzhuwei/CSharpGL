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
    public abstract class GridViewRenderer : Renderer, IModelSize, IRectangle3D
    {
        /// <summary>
        /// gridview's model.
        /// </summary>
        public GridViewModel Grid { get; private set; }

        public GridViewRenderer(GridViewModel model, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(model, shaderCodes, propertyNameMap, switches)
        {
            this.Grid = model;
        }

        public abstract float XLength { get; }

        public abstract float YLength { get; }

        public abstract float ZLength { get; }

        public virtual Rectangle3D GetRectangle()
        {
            var max = new vec3(XLength / 2, YLength / 2, ZLength / 2);
            var min = -max;
            vec3 position = this.ModelMatrix.GetTranslate();
            var result = new Rectangle3D(min + position, max + position);

            return result;
        }
    }
}
