using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RendererGenerator
{
    class FragmentShaderBuilder : ShaderBuilder
    {
        public override string Build(DataStructure data)
        {
            throw new NotImplementedException();
        }

        public override string GetFilename(DataStructure dataStructure)
        {
            return string.Format("{0}.frag", dataStructure.TargetName);
        }
    }
}
