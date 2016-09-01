using System;

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