using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Models
{
    /// <summary>
    /// contains indexes of a triangle.
    /// </summary>
    public class ObjFace
    {
        /// <summary>
        /// 
        /// </summary>
        public ivec3 VertexIndexes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ivec3 NormalIndexes { get; set; }

        /// <summary>
        /// contains indexes of a triangle.
        /// </summary>
        /// <param name="index0"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public ObjFace()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("v:[{0}], n:[{1}]", this.VertexIndexes, this.NormalIndexes);
        }
    }
}
