using CSharpGL;
using SimLab.SimGrid;
using System;
using System.Linq;

namespace SimLab.GridSource
{
    /// <summary>
    /// 网格数据源, 赋值后调用初始化Init才能使用:
    /// GridderSource src = new CatesianGridderSource()
    /// src.NX = 1;
    /// ....
    /// src.Init();
    /// </summary>
    public abstract class GridderSource
    {
        private GridIndexer gridIndexer;

        /// <summary>
        /// X轴方向上的网格数。
        /// </summary>
        public int NX { get; set; }

        /// <summary>
        /// Y轴方向上的网格数。
        /// </summary>
        public int NY { get; set; }

        /// <summary>
        /// Z轴方向上的网格数。
        /// </summary>
        public int NZ { get; set; }

        /// <summary>
        /// 获取网格包含的元素总数。
        /// </summary>
        public int DimenSize { get { return this.NX * this.NY * this.NZ; } }

        /// <summary>
        /// 每个网格一个值，全部为零，表示全部不可视
        /// </summary>
        private int[] zeroVisibles;

        /// <summary>
        /// 透明texture坐标,大小为DimenSize
        /// </summary>
        private float[] invisibleTextures;

        /// <summary>
        /// 此网格至少包含1个元素，返回true；否则返回false。
        /// </summary>
        public bool IsDimensEmpty
        { get { return (this.NX <= 0 || this.NY <= 0 || this.NZ <= 0); } }

        public int[] ActiveBlocks { get; set; }

        /// <summary>
        /// 将一维数组索引转化为三维（I,J,K）表示的网格索引号
        /// </summary>
        /// <param name="index">0开始的网格索引</param>
        /// <param name="iv"></param>
        /// <param name="jv"></param>
        /// <param name="kv"></param>
        public void InvertIJK(int index, out int I, out int J, out int K)
        {
            this.gridIndexer.IJKOfIndex(index, out I, out J, out K);
        }

        /// <summary>
        /// 求出网格索引位置
        /// </summary>
        /// <param name="I">网格坐标 I方向，1起始</param>
        /// <param name="J">网格坐标 J方向，1起始</param>
        /// <param name="K">网格坐标 K方向，1起始</param>
        /// <returns></returns>
        protected int GridIndexOf(int I, int J, int K)
        {
            return gridIndexer.IndexOf(I, J, K);
        }

        protected void IJK2Index(int I, int J, int K, out int index)
        {
            index = this.gridIndexer.IndexOf(I, J, K);
            return;
        }

        ///// <summary>
        ///// 判断网格是否是活动网格
        ///// </summary>
        ///// <param name="i">下标从1开始</param>
        ///// <param name="j">下标从1开始</param>
        ///// <param name="k">下标从1开始</param>
        ///// <returns></returns>
        //public bool IsActiveBlock(int i, int j, int k)
        //{
        //    int gridIndex;
        //    this.IJK2Index(i, j, k, out gridIndex);
        //    int actnum = this.ActNums[gridIndex];

        //    //小于或等于0的网格块都是非活动的网格块
        //    return (this.ActNums[gridIndex] > 0);
        //}

        /// <summary>
        /// 网格索引
        /// </summary>
        /// <param name="gridIndex"></param>
        /// <returns></returns>
        public bool IsActiveBlock(int gridIndex)
        {
            return this.ActiveBlocks[gridIndex] > 0;
        }

        /// <summary>
        /// 计算初始Bounds,
        /// </summary>
        protected abstract BoundingBox InitSourceActiveBounds();

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init()
        {
            if (this.gridIndexer == null)
            {
                this.gridIndexer = new GridIndexer(this.NX, this.NY, this.NZ);
            }

            if (this.ActiveBlocks == null)
            {
                this.ActiveBlocks = ArrayHelper.NewIntArray(this.DimenSize, 1);
            }
            if (this.zeroVisibles == null)
            {
                this.zeroVisibles = ArrayHelper.NewIntArray(this.DimenSize, 0);
            }
            if (this.invisibleTextures == null)
            {
                //初始化不可视
                this.invisibleTextures = ArrayHelper.NewFloatArray(this.DimenSize, 2);
            }

            this.InitGridCoordinates();

            this.SourceActiveBounds = this.InitSourceActiveBounds();
            //初始化
            mat4 identityMat = mat4.identity();
            vec3 center = this.SourceActiveBounds.GetCenter();
            //矩形三角形移动到中心点
            this.Position = -center;

            vec3 newcenter = this.Position * center;
            //System.Console.WriteLine(center);
            vec3 destMin = this.Position * this.SourceActiveBounds.MinPosition;
            vec3 destMax = this.Position * this.SourceActiveBounds.MaxPosition;

            //变换后的三维矩形六面体
            this.TransformedActiveBounds = new BoundingBox(destMin, destMax);
        }

        ///// <summary>
        ///// 创建纹理映射坐标
        ///// </summary>
        ///// <param name="gridIndexes"></param>
        ///// <param name="values"></param>
        ///// <param name="minValue"></param>
        ///// <param name="maxValue"></param>
        ///// <returns></returns>
        //public TexCoordBuffer CreateTextureCoordinates(int[] gridIndexes, float[] values, float minValue, float maxValue)
        //{
        //    return this.Factory.CreateTextureCoordinates(this, gridIndexes, values, minValue, maxValue);
        //}

        //public  CreateMesh()
        //{
        //    MeshBase geometry = this.Factory.CreateMesh(this);
        //    this.Max = geometry.Max;
        //    this.Min = geometry.Min;
        //    return geometry;
        //}

        public int[] BindCellActive(int[] a1, int[] a2)
        {
            if (a1.Length != a2.Length)
            { throw new ArgumentException("array size not equal"); }

            int length = a1.Length;
            int[] results = new int[length];
            for (int i = 0; i < length; i++)
            {
                results[i] = (a1[i] > 0 && a2[i] > 0) ? 1 : 0;
            }
            return results;
        }

        /// <summary>
        /// 将网格索引转化为可视结果
        /// </summary>
        /// <param name="gridIndexes"></param>
        /// <returns></returns>
        public int[] ExpandVisibles(int[] gridIndexes)
        {
            int[] array = this.zeroVisibles.ToArray();
            //new int[this.DimenSize];
            //Array.Copy(this.zeroVisibles, array, this.DimenSize);
            for (int i = 0; i < gridIndexes.Length; i++)
            {
                array[gridIndexes[i]] = 1;
            }
            return array;
        }

        /// <summary>
        /// 初始化描述网格的坐标
        /// </summary>
        protected virtual void InitGridCoordinates() { }

        /// <summary>
        /// 快速生成默认的网格Texture,值为空(值大于1）
        /// </summary>
        /// <returns></returns>
        public float[] GetInvisibleTextureCoords()
        {
            //float[] none = new float[this.DimenSize];
            //Array.Copy(this.invisibleTextures, none, this.DimenSize);
            //return none;
            return this.invisibleTextures.ToArray();
        }

        /// <summary>
        /// 模型范围的边界最小值
        /// </summary>
        public vec3 Min { get; internal set; }

        /// <summary>
        /// 模型范围的边界最大值
        /// </summary>
        public vec3 Max { get; internal set; }

        /// <summary>
        /// 原始数据的三维矩形边界
        /// </summary>
        public BoundingBox SourceActiveBounds { get; internal set; }

        //TODO: rename to translate.
        /// <summary>
        /// SourceActiveBounds到DestActiveBounds的
        /// </summary>
        public vec3 Position { get; internal set; }

        /// <summary>
        /// 中心点在坐标原点
        /// </summary>
        public BoundingBox TransformedActiveBounds { get; internal set; }

        public object Tag { get; set; }
    }
}