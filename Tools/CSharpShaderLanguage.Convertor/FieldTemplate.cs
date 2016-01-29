using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpShaderLanguage.Convertor
{
    class FieldTemplate
    {
        private FieldQualifier varQualifier;
        private Type varType;
        private string varName;

        public FieldTemplate(FieldQualifier varQualifier, Type type, string varName)
        {
            this.varQualifier = varQualifier;
            this.varType = type;
            this.varName = varName;
        }

        internal string Dump()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.varQualifier.ToString().ToLower());
            builder.Append(" ");
            builder.Append(this.varType.Name);
            builder.Append(" ");
            builder.Append(this.varName);
            builder.Append(";");

            return builder.ToString();
        }
    }

    enum FieldQualifier
    {
        In,
        Out,
        Uniform,
    }
}
