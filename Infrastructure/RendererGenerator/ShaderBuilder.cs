namespace RendererGenerator
{
    internal abstract class ShaderBuilder
    {
        public string Version { get; set; }

        public ShaderBuilder()
        {
            this.Version = "#version 150 core";
        }

        public abstract string Build(DataStructure data);

        public abstract string GetFilename(DataStructure dataStructure);
    }
}