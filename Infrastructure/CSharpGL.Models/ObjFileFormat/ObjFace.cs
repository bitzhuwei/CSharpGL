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
        private readonly int[] vertexIndexes = new int[3];

        /// <summary>
        /// contains indexes of a triangle.
        /// </summary>
        /// <param name="index0"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public ObjFace(int index0, int index1, int index2)
        {
            this.vertexIndexes[0] = index0;
            this.vertexIndexes[1] = index1;
            this.vertexIndexes[2] = index2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", vertexIndexes[0], vertexIndexes[1], vertexIndexes[2]);
        }
    }
}
