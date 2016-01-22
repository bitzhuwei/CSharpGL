using CSharpGL.Objects.Models;
using FormShaderDesigner1594Demos.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormShaderDesigner1594Demos.RendererFactories
{
    class CloudRendererFactory : RendererFactory
    {
        public override ShaderDesignerRendererBase GetRenderer(IModel model)
        {
            return new CloudRenderer(model);
        }
    }
}
