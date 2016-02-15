using CSharpShadingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.CSSL2GLSL
{
    public class SemanticField
    {
        //private FieldQualifier varQualifier;
        private QualifierAttribute attribute;
        private Type varType;
        private string varName;

        //public SemanticField(FieldQualifier varQualifier, Type type, string varName)
        public SemanticField(QualifierAttribute attribute, Type type, string varName)
        {
            //this.varQualifier = varQualifier;
            this.attribute = attribute;
            this.varType = type;
            this.varName = varName;
        }

        public string Dump()
        {
            StringBuilder builder = new StringBuilder();
            //builder.Append(this.varQualifier.ToString());
            builder.Append(this.attribute.NameInGLSL);
            builder.Append(" ");
            if (this.varType.Name == "Single")
            { builder.Append("float"); }
            else if (this.varType.Name == "Int32")
            { builder.Append("int"); }
            else
            { builder.Append(this.varType.Name); }
            builder.Append(" ");
            builder.Append(this.varName);
            builder.Append(";");

            return builder.ToString();
        }
    }

    public enum FieldQualifier
    {
        In,
        Out,
        Uniform,
    }
}
