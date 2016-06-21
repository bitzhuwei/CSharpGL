using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLab.SimGrid
{

    /// <summary>
    /// 
    /// </summary>
    public class GridIndexer
    {
        private  int ni;
        private  int nj;
        private  int nk;

        /// <summary>
        /// k平面的网格数
        /// </summary>
        private  int nij;

        public GridIndexer(int nx, int ny, int nz)
        {
            this.ni = nx;
            this.nj = ny;
            this.nk = nz;
            this.nij = ni * nj;
            this.DimenSize = ni * nj * nk;
        }

        /// <summary>
        /// I,J,K 必须>=1，将I,JK,转化为从I方向J,K顺序描述的数组坐标，即网格索引坐标,
        /// I,J,K分别为x,y,z方向上的网格坐标
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int IndexOf(int i, int j, int k)
        {
             int result = (k - 1) * (this.ni * this.nj) + (j- 1) * this.ni + (i- 1);
             return result;
        }

        public int DimenSize { get; private set; }

        /// <summary>
        /// 将网格索引坐标转化为I,J,K表示的网格坐标
        /// </summary>
        /// <param name="gridIndex"></param>
        /// <param name="I"></param>
        /// <param name="J"></param>
        /// <param name="K"></param>
        public void IJKOfIndex(int gridIndex, out int I, out int J, out int K)
        {
            K = gridIndex / nij + 1;
            int ijLeft = gridIndex % nij;
            J = ijLeft / this.ni + 1;
            I = ijLeft % this.ni + 1;
        }



    }
}
