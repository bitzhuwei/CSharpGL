using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RendererGenerator
{
    abstract class ShaderBuilder
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
