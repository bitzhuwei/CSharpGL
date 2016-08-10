using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RendererGenerator
{
    class ModelBuilder
    {

        public string GetFilename(DataStructure dataStructure)
        {
            return string.Format("{0}Model.cs", dataStructure.TargetName);
        }

        public void Build(DataStructure dataStructure, string modelFilename = "")
        {
            if (string.IsNullOrEmpty(modelFilename)) { modelFilename = this.GetFilename(dataStructure); }
            throw new NotImplementedException();
        }
    }
}
