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
        public abstract IEnumerable<uint> VertexIndexes();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<uint> NormalIndexes();

    }

    /// <summary>
    /// 
    /// </summary>
    public class ObjVNFTriangle : ObjVNFFace
    {
        public readonly uint[] vertexIndexes = new uint[3];
        public readonly uint[] normalIndexes = new uint[3];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="n0"></param>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        public ObjVNFTriangle(uint v0, uint v1, uint v2, uint n0, uint n1, uint n2)
        {
            vertexIndexes[0] = v0; vertexIndexes[1] = v1; vertexIndexes[2] = v2;
            normalIndexes[0] = n0; normalIndexes[1] = n1; normalIndexes[2] = n2;
        }

        public override IEnumerable<uint> VertexIndexes()
        {
            foreach (var item in vertexIndexes)
            {
                yield return item;
            }
        }

        public override IEnumerable<uint> NormalIndexes()
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
        public readonly uint[] vertexIndexes = new uint[4];
        public readonly uint[] normalIndexes = new uint[4];

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
        public ObjVNFQuad(uint v0, uint v1, uint v2, uint v3, uint n0, uint n1, uint n2, uint n3)
        {
            vertexIndexes[0] = v0; vertexIndexes[1] = v1; vertexIndexes[2] = v2; vertexIndexes[3] = v3;
            normalIndexes[0] = n0; normalIndexes[1] = n1; normalIndexes[2] = n2; normalIndexes[3] = n3;
        }

        public override IEnumerable<uint> VertexIndexes()
        {
            foreach (var item in vertexIndexes)
            {
                yield return item;
            }
        }

        public override IEnumerable<uint> NormalIndexes()
        {
            foreach (var item in normalIndexes)
            {
                yield return item;
            }
        }
    }

}
