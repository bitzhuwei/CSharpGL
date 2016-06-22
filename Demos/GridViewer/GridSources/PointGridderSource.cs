using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SimLab.GridSource
{
    /// <summary>
    /// 块为六面体组成的模拟网格几何信息,支持切片分析
    /// </summary>
    public class PointGridderSource : GridderSource
    {
        /// <summary>
        /// 初始化切片可视性
        /// </summary>
        public override void Init()
        {
            base.Init();

            this.Radius = ArrayHelper.NewFloatArray(this.DimenSize, 1.0f);
        }

        public vec3[] Positions { get; set; }

        public float OriginalRadius { get; set; }

        /// <summary>
        /// 对应的每个点的半径
        /// </summary>
        public float[] Radius { get; set; }

        public vec3 GetPosition(int i, int j, int k)
        {
            int gridIndex = this.GridIndexOf(i, j, k);
            return this.Positions[gridIndex];
        }

        protected int[] ExpandVisiblesForPointGrid(int[] gridIndexes)
        {
            if (gridIndexes.Length == this.DimenSize)
            {
                return ArrayHelper.NewIntArray(this.DimenSize, 1);
            }
            else
            {
                int dimenSize = this.DimenSize;
                int[] visibles = ArrayHelper.NewIntArray(this.DimenSize, 0);
                for (int i = 0; i < gridIndexes.Length; i++)
                {
                    int gridIndex = gridIndexes[i];
                    if (gridIndex >= 0 && gridIndex < dimenSize)
                    {
                        visibles[i] = 1;
                    }
                }
                return visibles;
            }
        }

        /// <summary>
        /// 确定结果是否显示 返回数组大小为DimenSize
        /// </summary>
        /// <param name="gridIndexes"></param>
        /// <returns></returns>
        public int[] BindResultsVisibles(int[] gridIndexes)
        {
            int[] resultHas = this.ExpandVisiblesForPointGrid(gridIndexes);
            return this.BindCellActive(resultHas, this.ActiveBlocks);
        }

        //public PointRadiusBuffer CreateRadiusBuffer(float[] radius)
        //{
        //    return (this.Factory as PointGridFactory).CreateRadiusBufferData(this, radius);
        //}

        //public PointRadiusBuffer CreateRadiusBuffer(float radius)
        //{
        //    return (this.Factory as PointGridFactory).CreateRadiusBufferData(this, radius);
        //}

        protected override Rectangle3D InitSourceActiveBounds()
        {
            if (this.Positions == null || this.Positions.Length <= 0)
            { throw new ArgumentException("Points has No Value"); }

            vec3 v = this.Positions[0];
            var rect3d = new Rectangle3D(v, v);
            for (int i = 0; i < this.Positions.Length; i++)
            {
                rect3d.Union(this.Positions[i]);
            }
            return rect3d;
        }

    }
}
