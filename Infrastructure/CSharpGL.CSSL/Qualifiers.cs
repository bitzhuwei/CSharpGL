using System;

namespace CSharpGL.CSSL
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public abstract class QualifierAttribute : Attribute
    {
        // This is a positional argument
        public QualifierAttribute(string nameInGLSL)
        {
            this.NameInGLSL = nameInGLSL;
        }

        public string NameInGLSL { get; private set; }

        public override string ToString()
        {
            return this.NameInGLSL;
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public sealed class InAttribute : QualifierAttribute
    {
        // This is a positional argument
        public InAttribute()
            : base("in")
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public sealed class OutAttribute : QualifierAttribute
    {
        // This is a positional argument
        public OutAttribute()
            : base("out")
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public sealed class UniformAttribute : QualifierAttribute
    {
        // This is a positional argument
        public UniformAttribute()
            : base("uniform")
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public sealed class FlatAttribute : QualifierAttribute
    {
        // This is a positional argument
        public FlatAttribute()
            : base("flat")
        {
        }
    }
}