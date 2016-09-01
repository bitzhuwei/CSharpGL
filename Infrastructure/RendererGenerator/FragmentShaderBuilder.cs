using System.Text;

namespace RendererGenerator
{
    internal class FragmentShaderBuilder : ShaderBuilder
    {
        public override string Build(DataStructure data)
        {
            var builder = new StringBuilder();
            builder.AppendLine(this.Version);
            builder.AppendLine();

            builder.AppendLine("void main(void)");
            builder.AppendLine("{");
            builder.AppendLine("    // TODO: setup output color ...");
            builder.AppendLine("}");
            builder.AppendLine();

            return builder.ToString();
        }

        public override string GetFilename(DataStructure dataStructure)
        {
            return string.Format("{0}.frag", dataStructure.TargetName);
        }
    }
}