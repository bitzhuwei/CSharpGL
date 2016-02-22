using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpShadingLanguage.Convertor
{
    class WorkerData
    {
        internal string[] csharpShaderFiles;

        public WorkerData(params string[] csharpShaderFiles)
        {
            this.csharpShaderFiles = csharpShaderFiles;
        }

        public override string ToString()
        {
            return string.Format("{0} files.", csharpShaderFiles == null ? 0 : csharpShaderFiles.Length);
        }
    }
}
