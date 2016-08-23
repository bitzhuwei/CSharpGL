using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    interface IScalableTransform : IModelTransform
    {
        /// <summary>
        /// world position before model is scaled.
        /// </summary>
        vec3 OriginalWorldPosition { get; }
    }
}
