using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpShadingLanguage
{
    public class BuildInFunctionAttribute : Attribute
    {
        public BuildInFunctionAttribute(string bulidInName)
        {
            this.bulidInName = bulidInName;
        }

        public string bulidInName { get; private set; }
    }
}
