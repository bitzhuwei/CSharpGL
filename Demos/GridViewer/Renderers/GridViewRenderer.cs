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
    public class GridViewRenderer : Renderer, IModelTransform
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
            this.ModelMatrix = mat4.identity();
        }

        /// <summary>
        /// IModelTransform.ModelMatrix
        /// </summary>
        public mat4 ModelMatrix { get; set; }

    }
}
