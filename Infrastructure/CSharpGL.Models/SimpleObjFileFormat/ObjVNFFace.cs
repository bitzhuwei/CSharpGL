using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ObjVNFFace
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<int> VertexIndexes();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<int> NormalIndexes();

    }

    public class ObjVNFTriangle : ObjVNFFace
    {
        public readonly int[] vertexIndexes = new int[3];
        public readonly int[] normalIndexes = new int[3];

        public override IEnumerable<int> VertexIndexes()
        {
            foreach (var item in vertexIndexes)
            {
                yield return item;
            }
        }

        public override IEnumerable<int> NormalIndexes()
        {
            foreach (var item in normalIndexes)
            {
                yield return item;
            }
        }
    }


    public class ObjVNFQuad : ObjVNFFace
    {
        public readonly int[] vertexIndexes = new int[4];
        public readonly int[] normalIndexes = new int[4];

        public override IEnumerable<int> VertexIndexes()
        {
            foreach (var item in vertexIndexes)
            {
                yield return item;
            }
        }

        public override IEnumerable<int> NormalIndexes()
        {
            foreach (var item in normalIndexes)
            {
                yield return item;
            }
        }
    }

}
