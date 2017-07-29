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

    /// <summary>
    /// 
    /// </summary>
    public class ObjVNFTriangle : ObjVNFFace
    {
        public readonly int[] vertexIndexes = new int[3];
        public readonly int[] normalIndexes = new int[3];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="n0"></param>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        public ObjVNFTriangle(int v0, int v1, int v2, int n0, int n1, int n2)
        {
            vertexIndexes[0] = v0; vertexIndexes[1] = v1; vertexIndexes[2] = v2;
            normalIndexes[0] = n0; normalIndexes[1] = n1; normalIndexes[2] = n2;
        }

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

    /// <summary>
    /// 
    /// </summary>
    public class ObjVNFQuad : ObjVNFFace
    {
        public readonly int[] vertexIndexes = new int[4];
        public readonly int[] normalIndexes = new int[4];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="n0"></param>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <param name="n3"></param>
        public ObjVNFQuad(int v0, int v1, int v2, int v3, int n0, int n1, int n2, int n3)
        {
            vertexIndexes[0] = v0; vertexIndexes[1] = v1; vertexIndexes[2] = v2; vertexIndexes[3] = v3;
            normalIndexes[0] = n0; normalIndexes[1] = n1; normalIndexes[2] = n2; normalIndexes[3] = n3;
        }

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
