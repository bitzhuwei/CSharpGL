using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RendererGenerator
{
    class VertexShaderBuilder : ShaderBuilder
    {
        public override string Build(DataStructure data)
        {
            throw new NotImplementedException();
        }

        public override string GetFilename(DataStructure dataStructure)
        {
            return string.Format("{0}.vert", dataStructure.TargetName);
        }
    }
}
