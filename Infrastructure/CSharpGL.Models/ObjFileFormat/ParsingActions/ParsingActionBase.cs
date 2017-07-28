using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Models
{
    /// <summary>
    /// contains indexes of a triangle.
    /// </summary>
    public abstract class ParsingActionBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public abstract void Parse(ObjParsingContext context);
    }
}
