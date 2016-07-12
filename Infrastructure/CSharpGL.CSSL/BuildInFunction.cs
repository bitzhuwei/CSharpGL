using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.CSSL
{
    public class BuildInFunctionAttribute : Attribute
    {
        public BuildInFunctionAttribute(string buildInName)
        {
            this.BuildInName = buildInName;
        }

        public string BuildInName { get; private set; }
    }
}
