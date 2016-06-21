using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLab.GridSource
{
    /// <summary>
    /// 块为六面体组成的模拟网格几何信息,支持切片分析
    /// </summary>
    public abstract class HexahedronGridderSource : GridderSource
    {

        private Dictionary<int, bool> CreateSliceDict(IList<int> slices)
        {
            Dictionary<int, bool> result = new Dictionary<int, bool>();
            for (int i = 0; i < slices.Count; i++)
            {
                result.Add(slices[i], true);
            }
            return result;
        }

        public int[] Slices { get; protected set; }

        /// <summary>
        /// 切片同ActNum的AND后的结果，表示某个网格是否画不画
        /// </summary>
        public int[] BindVisibles { get; protected set; }

        private List<int> _iBlocks;
        private Dictionary<int, bool> iSlices;
        public List<int> IBlocks
        {
            get { return this._iBlocks; }
            set
            {
                this._iBlocks = value;
                this.iSlices = CreateSliceDict(value);
            }
        }

        private List<int> _jBlocks;
        private Dictionary<int, bool> jSlices;
        public List<int> JBlocks
        {
            get { return this._jBlocks; }
            set
            {
                this._jBlocks = value;
                this.jSlices = CreateSliceDict(value);
            }
        }

        private List<int> _kBlocks;
        private Dictionary<int, bool> kSlices;
        public List<int> KBlocks
        {
            get
            {
                return this._kBlocks;
            }
            set
            {
                this._kBlocks = value;
                this.kSlices = CreateSliceDict(value);
            }
        }

        /// <summary>
        /// 判断(I,J,K)是否是切片的网格块
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool IsSliceBlock(int i, int j, int k)
        {
            //int gridIndex;
            //this.IJK2Index(i, j, k, out gridIndex);
            //return sliceVisibles[gridIndex] > 0;
            return (iSlices.ContainsKey(i) || jSlices.ContainsKey(j)) && kSlices.ContainsKey(k);
        }

        /// <summary>
        /// 判断IJ是否 处于IJ的平面
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public bool IsSliceBlock(int i, int j)
        {
            return iSlices.ContainsKey(i) || jSlices.ContainsKey(j);
        }

        /// <summary>
        /// 获取FRONT平面，LEFT TOP 上的点
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public abstract vec3 PointFLT(int i, int j, int k);

        /// <summary>
        /// 获取FRONT平面，RIGHT TOP 上的点
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public abstract vec3 PointFRT(int i, int j, int k);

        /// <summary>
        /// 获取FRONT平面，LEFT BUTTOM 上的点
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public abstract vec3 PointFLB(int i, int j, int k);

        /// <summary>
        ///  获取FRONT平面，RIGHT BUTTOM 上的点
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public abstract vec3 PointFRB(int i, int j, int k);

        /// <summary>
        /// 获取BACK平面，LEFT TOP 上的点
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public abstract vec3 PointBLT(int i, int j, int k);

        /// <summary>
        /// 获取BACK平面，RIGHT TOP 上的点
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public abstract vec3 PointBRT(int i, int j, int k);

        /// <summary>
        /// 获取BACK平面，LEFT BOTTOM 上的点
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public abstract vec3 PointBLB(int i, int j, int k);

        /// <summary>
        ///  获取BACK平面，RIGHT BOTTOM 上的点
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public abstract vec3 PointBRB(int i, int j, int k);

        protected void InitSliceVisibles()
        {
            this.Slices = CreateSliceVisibles();
            this.BindVisibles = BindCellActive(this.Slices, this.ActiveBlocks);
        }

        /// <summary>
        /// 生成网格是否显示的标志
        /// </summary>
        /// <returns></returns>
        protected int[] CreateSliceVisibles()
        {
            int[] sliceVisibles = new int[this.DimenSize];
            //默认不显示
            for (int gridIndex = 0; gridIndex < sliceVisibles.Length; gridIndex++)
            {
                int i, j, k;
                this.InvertIJK(gridIndex, out i, out j, out k);
                if (this.IsSliceBlock(i, j, k))
                    sliceVisibles[gridIndex] = 1;
                else
                    sliceVisibles[gridIndex] = 0;
            }
            return sliceVisibles;
        }

        /// <summary>
        /// 初始化切片可视性
        /// </summary>
        public override void Init()
        {
            base.Init();
            this.InitSliceVisibles();
        }

        /// <summary>
        /// 重新生成切片信息
        /// </summary>
        public void RefreashSlices()
        {
            this.InitSliceVisibles();
        }

        protected override Rectangle3D InitSourceActiveBounds()
        {
            bool initFlag = false;
            var rect = new Rectangle3D();
            int i, j, k;
            for (int gridIndex = 0; gridIndex < this.DimenSize; gridIndex++)
            {
                if (this.IsActiveBlock(gridIndex))
                {
                    this.InvertIJK(gridIndex, out i, out j, out k);
                    if (!initFlag)
                    {
                        initFlag = true;
                        rect = new Rectangle3D(PointFLB(i, j, k), PointBRT(i, j, k));
                    }
                    rect.Union(PointFLT(i, j, k));
                    rect.Union(PointFRT(i, j, k));
                    rect.Union(PointBLT(i, j, k));
                    rect.Union(PointBRT(i, j, k));
                    rect.Union(PointFLB(i, j, k));
                    rect.Union(PointFRB(i, j, k));
                    rect.Union(PointBLB(i, j, k));
                    rect.Union(PointBRB(i, j, k));
                }
            }
            return rect;
        }
    }
}
