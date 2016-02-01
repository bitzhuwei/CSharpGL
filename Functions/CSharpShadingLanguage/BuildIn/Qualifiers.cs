using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpShadingLanguage
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public sealed class InAttribute : Attribute
    {
        // This is a positional argument
        public InAttribute()
        {
        }
    }
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public sealed class OutAttribute : Attribute
    {
        // This is a positional argument
        public OutAttribute()
        {
        }
    }
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public sealed class UniformAttribute : Attribute
    {
        // This is a positional argument
        public UniformAttribute()
        {
        }
    }
}
