using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Demos
{
    public static class ShaderHelper
    {
        public static string Load(string shaderFilename)
        {
            return ManifestResourceLoader.LoadTextFile(shaderFilename);
        }
    }
}
