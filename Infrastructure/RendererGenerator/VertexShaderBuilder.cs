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
            var builder = new StringBuilder();
            builder.AppendLine(this.Version);
            builder.AppendLine();
            foreach (var item in data.PropertyList)
            {
                builder.AppendLine(item.ToGLSL());
            }
            builder.AppendLine();

            builder.AppendLine("void main(void)");
            builder.AppendLine("{");
            builder.AppendLine("    // TODO: setup gl_Position = ...");
            builder.AppendLine("}");
            builder.AppendLine();

            return builder.ToString();
        }

        public override string GetFilename(DataStructure dataStructure)
        {
            return string.Format("{0}.vert", dataStructure.TargetName);
        }
    }
}
