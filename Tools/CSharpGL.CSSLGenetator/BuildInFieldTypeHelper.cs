using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.CSSLGenetator
{
    static class BuildInFieldTypeHelper
    {
        static List<IntermediateStructure> buildInFieldTypeList = new List<IntermediateStructure>();
        
        static BuildInFieldTypeHelper()
        {
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "int" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "float" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "vec2" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "vec3" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "vec4" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "mat2" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "mat3" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "mat4" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "sampler1D" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "sampler2D" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "sampler3D" });
        }

        public static IEnumerable<IntermediateStructure> GetBuildInTypeList()
        {
            return buildInFieldTypeList;
        }

    }
}
