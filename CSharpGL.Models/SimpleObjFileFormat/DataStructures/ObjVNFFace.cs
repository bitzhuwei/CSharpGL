using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public abstract class ObjVNFFace {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract uint[] VertexIndexes();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract uint[] NormalIndexes();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract uint[] TexCoordIndexes();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract uint[] TangentIndexes();

    }

    /// <summary>
    /// 
    /// </summary>
    public unsafe class ObjVNFTriangle : ObjVNFFace {
        public readonly uint[] vertexIndexes = new uint[3];
        public readonly uint[] normalIndexes = new uint[3];
        public readonly uint[] texCoordIndexes = new uint[3];
        public readonly uint[] tangentIndexes = new uint[3];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="n0"></param>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        public ObjVNFTriangle(uint v0, uint v1, uint v2, uint n0, uint n1, uint n2, uint t0, uint t1, uint t2) {
            vertexIndexes[0] = v0; vertexIndexes[1] = v1; vertexIndexes[2] = v2;
            normalIndexes[0] = n0; normalIndexes[1] = n1; normalIndexes[2] = n2;
            texCoordIndexes[0] = t0; texCoordIndexes[1] = t1; texCoordIndexes[2] = t2;
        }

        public override uint[] VertexIndexes() {
            return this.vertexIndexes;
        }

        public override uint[] NormalIndexes() {
            return this.normalIndexes;
        }

        public override uint[] TexCoordIndexes() {
            return this.texCoordIndexes;
        }

        public override uint[] TangentIndexes() {
            return this.tangentIndexes;
        }

        public override string ToString() {
            return string.Format("v:{0}, {1}, {2}, n:{3}, {4}, {5}",
                vertexIndexes[0], vertexIndexes[1], vertexIndexes[2],
                normalIndexes[0], normalIndexes[1], normalIndexes[2]);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public unsafe class ObjVNFQuad : ObjVNFFace {
        public readonly uint[] vertexIndexes = new uint[4];
        public readonly uint[] normalIndexes = new uint[4];
        public readonly uint[] texCoordIndexes = new uint[4];
        public readonly uint[] tangentIndexes = new uint[4];

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
        public ObjVNFQuad(uint v0, uint v1, uint v2, uint v3, uint n0, uint n1, uint n2, uint n3, uint t0, uint t1, uint t2, uint t3) {
            vertexIndexes[0] = v0; vertexIndexes[1] = v1; vertexIndexes[2] = v2; vertexIndexes[3] = v3;
            normalIndexes[0] = n0; normalIndexes[1] = n1; normalIndexes[2] = n2; normalIndexes[3] = n3;
            texCoordIndexes[0] = t0; texCoordIndexes[1] = t1; texCoordIndexes[2] = t2; texCoordIndexes[3] = t3;
        }

        public override uint[] VertexIndexes() {
            return this.vertexIndexes;
        }

        public override uint[] NormalIndexes() {
            return this.normalIndexes;
        }

        public override uint[] TexCoordIndexes() {
            return this.texCoordIndexes;
        }

        public override uint[] TangentIndexes() {
            return this.tangentIndexes;
        }

        public override string ToString() {
            return string.Format("v:{0}, {1}, {2}, {3}, n:{4}, {5}, {6}, {7}",
                vertexIndexes[0], vertexIndexes[1], vertexIndexes[2], vertexIndexes[3],
                normalIndexes[0], normalIndexes[1], normalIndexes[2], normalIndexes[3]);
        }
    }

}
