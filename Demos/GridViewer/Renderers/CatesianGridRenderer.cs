using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    public partial class CatesianGridRenderer : Renderer
    {

        public CatesianGridRenderer(CatesianGrid catesianGrid, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(catesianGrid, shaderCodes, propertyNameMap, switches)
        {
            this.Grid = catesianGrid;
        }


        public CatesianGrid Grid { get; private set; }
    }
}
