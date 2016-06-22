using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL.CSSLGenetator
{
    static class BuildInFieldTypeHelper
    {
        static List<IntermediateStructure> buildInFieldTypeList = new List<IntermediateStructure>();

        static BuildInFieldTypeHelper()
        {
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "int", DefaultValue = "int(1)" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "float", DefaultValue = "float(1.0f)" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "vec2", DefaultValue = "vec2(1.0f,1.0f)" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "vec3", DefaultValue = "vec3(1.0f,1.0f,1.0f)" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "vec4", DefaultValue = "vec4(1.0f,1.0f,1.0f,1.0f)" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "mat2", DefaultValue = "mat2(1.0f)" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "mat3", DefaultValue = "mat3(1.0f)" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "mat4", DefaultValue = "mat4(1.0f)" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "sampler1D", DefaultValue = "" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "sampler2D", DefaultValue = "" });
            buildInFieldTypeList.Add(new IntermediateStructure() { Name = "sampler3D", DefaultValue = "" });
        }

        public static IEnumerable<IntermediateStructure> GetBuildInTypeList()
        {
            return buildInFieldTypeList;
        }

    }
}
