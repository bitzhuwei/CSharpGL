using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GLFieldEventArgs<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private GLField<T> Value { get; set; }

        public GLFieldEventArgs(GLField<T> value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return string.Format("Arg: {0}", this.Value);
        }
    }
}