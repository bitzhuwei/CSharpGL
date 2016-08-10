using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RendererGenerator
{
    class RendererBuilder
    {
        public string GetFilename(DataStructure dataStructure)
        {
            return string.Format("{0}Renderer.cs");
        }

        public void Build(DataStructure dataStructure, string rendererFilename = "")
        {
            if (string.IsNullOrEmpty(rendererFilename)) { rendererFilename = this.GetFilename(dataStructure); }
            throw new NotImplementedException();
        }
    }
}
