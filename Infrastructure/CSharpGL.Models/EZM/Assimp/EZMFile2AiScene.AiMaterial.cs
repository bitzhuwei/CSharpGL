using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public static partial class EZMFile2AiScene
    {
        private static AiMaterial Parse(EZMMaterial ezmMaterial)
        {
            var aiMaterial = new AiMaterial();
            aiMaterial.Name = ezmMaterial.Name;
            aiMaterial.MetaData = ezmMaterial.MetaData;
            aiMaterial.Tag = ezmMaterial.Tag;

            return aiMaterial;
        }

    }
}
