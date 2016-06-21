using CSharpGL;
using SimLab.GridSource;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLab.SimGrid
{
    /// <summary>
    /// 无结构的四面体网格，包含二维无结构和三维四面体网格的格式,
    /// 文件内容分为三个段,依次为nodes,elements,fractures.
    /// nodes为（x,y,z,0)的数组
    /// elements元素为nodes数组的索引,element[ELEMENT_FORMAT3+1](三角形) 或element[ELEMENT_FORMAT4+1](4面体)
    /// fratures元素为node数组的索引, fracture[FRACTURE_FORMAT2+1] (线段） 或fracture[FRACTURE_FORMAT3+1](三角形)]  
    /// elements.Length+fractures.Length = NX*NY*NZ ,通常NY,NZ =1， 所以NX = (elements.length+fratures.length)
    /// </summary>
    public class DynamicUnstructuredGridderSource : GridderSource
    {
        /// <summary>
        /// 组成母体的形状
        /// </summary>
        public const int MATRIX_FORMAT3_TRIANGLE = 3;
        public const int MATRIX_FORMAT4_TETRAHEDRON = 4;
        public const int MATRIX_FORMAT6_TRIANGULAR_PRISM = 6;
        /// <summary>
        /// 组成裂缝的形状
        /// </summary>
        public const int FRACTURE_FORMAT2_LINE = 2;
        public const int FRACTURE_FORMAT3_TRIANGLE = 3;
        public const int FRACTURE_FORMAT4_QUAD = 4;

        /// <summary>
        /// 文件头定义: 点的个数
        /// </summary>
        public int NodeNum { get; internal set; }

        public vec3[] Nodes { get; set; }

        /// <summary>
        /// 如果nodeInElem 为NODE_FORMAT3 时，element部分表示三角形，elem
        /// </summary>
        public int ElementNum { get; internal set; }

        /// <summary>
        /// 基质几何结构描述
        /// </summary>
        public int[][] Elements { get; internal set; }

        /// <summary>
        /// 基质格式定义
        /// 当值为ElEMENT_FORMAT3,表示elements段为三角型，此时任意element为elements[i][ELEMENT_FORMAT3+1]，
        /// ELEMENT_FORMAT4时表示为四面体,此时elements[i][ELEMENT_FORMAT4+1]四面体
        /// 每个element数组最后一个描述保留，值为0
        /// </summary>
        public int ElementFormat { get; internal set; }

        /// <summary>
        /// 断层和裂缝数
        /// </summary>
        public int FractureNum { get; internal set; }

        public int[][] Fractures { get; internal set; }

        /// <summary>
        /// FRACTURE_FORMAT2是 fractures[i][FRACTURE_FORMAT2+1]
        /// FRACTURE_FORMAT2是 fractures[i][FRACTURE_FORMAT3+1]
        /// fracure[]中最后一个数组元素表示MARKER
        /// </summary>
        public int FractureFormat { get; internal set; }

        /// <summary>
        /// 母体不可见
        /// </summary>
        public int[] MatrixInvisibles { get; internal set; }

        /// <summary>
        /// 断层不可见
        /// </summary>
        public int[] FracturesInvisible { get; internal set; }


        /// <summary>
        /// 不可见母体纹理,值全部为2
        /// </summary>
        public float[] InvisibleMatrixTextures { get; internal set; }

        /// <summary>
        /// 不可见裂缝纹理,值全部为2
        /// </summary>
        public float[] InvisibleFractureTextures { get; internal set; }

        public int[] ActiveMatrix { get; internal set; }
        public int[] ActiveFractures { get; internal set; }

        private int[] InitActiveMatrix()
        {
            int matrixSize = this.DimenSize - this.FractureNum;
            int fractureSize = this.FractureNum;
            int[] activematrix = new int[matrixSize];
            Array.Copy(this.ActiveBlocks, fractureSize, activematrix, 0, matrixSize);
            return activematrix;
        }

        private int[] InitActiveFractures()
        {
            int fractureSize = this.FractureNum;
            int[] activeFractures = new int[fractureSize];
            Array.Copy(this.ActiveBlocks, activeFractures, fractureSize);
            return activeFractures;
        }

        private void InitMatrixFracturesInvisibles()
        {
            int matrixSize = this.DimenSize - this.FractureNum;
            this.MatrixInvisibles = ArrayHelper.NewIntArray(matrixSize, 0);
            int fractureSize = this.FractureNum;
            this.FracturesInvisible = ArrayHelper.NewIntArray(fractureSize, 0);
            this.InvisibleMatrixTextures = ArrayHelper.NewFloatArray(matrixSize, 2.0f);
            this.InvisibleFractureTextures = ArrayHelper.NewFloatArray(fractureSize, 2.0f);
        }

        /// <summary>
        /// 将结果整理成转化为可见
        /// </summary>
        /// <param name="gridIndexes">结果集合</param>
        /// <returns></returns>
        public int[] ExpandMatrixVisibles(int[] gridIndexes)
        {
            int matrixSize = this.ElementNum;
            int dimenSize = this.DimenSize;
            int matrixStartIndex = this.FractureNum;
            int[] results = new int[matrixSize];
            Array.Copy(this.MatrixInvisibles, results, results.Length);
            for (int mixedIndex = 0; mixedIndex < gridIndexes.Length; mixedIndex++)
            {
                int gridIndex = gridIndexes[mixedIndex];
                if (gridIndex >= matrixStartIndex && gridIndex < dimenSize)
                {
                    results[gridIndex - matrixStartIndex] = 1;
                }
            }
            return results;
        }

        public int[] ExpandFractureVisibles(int[] gridIndexes)
        {
            int fractureNum = this.FractureNum;
            int[] results = new int[fractureNum];
            Array.Copy(FracturesInvisible, results, fractureNum);
            for (int mixedIndex = 0; mixedIndex < gridIndexes.Length; mixedIndex++)
            {
                int gridIndex = gridIndexes[mixedIndex];
                if (gridIndex >= 0 && gridIndex < fractureNum)
                {
                    results[gridIndex] = 1;
                }
            }
            return results;
        }

        public int[] BindResultsAndActiveMatrix(int[] gridIndexes)
        {
            int[] results = this.ExpandMatrixVisibles(gridIndexes);
            return this.BindCellActive(results, this.ActiveMatrix);
        }

        public int[] BindResultsAndActiveFractures(int[] gridIndexes)
        {
            int[] results = this.ExpandFractureVisibles(gridIndexes);
            return this.BindCellActive(results, this.ActiveFractures);
        }

        public override void Init()
        {
            base.Init();
            this.InitMatrixFracturesInvisibles();

            if (this.ActiveMatrix == null)
            {
                this.ActiveMatrix = InitActiveMatrix();
            }
            if (this.ActiveFractures == null)
            {
                this.ActiveFractures = this.InitActiveFractures();
            }
        }

        protected override Rectangle3D InitSourceActiveBounds()
        {
            if (this.NodeNum <= 0)
            { throw new ArgumentException("No nodes found"); }

            vec3[] nodes = this.Nodes;
            var rect = new Rectangle3D(nodes[0], nodes[0]);
            for (int i = 0; i < nodes.Length; i++)
            {
                rect.Union(nodes[i]);
            }
            return rect;
        }

        //public TexCoordBuffer CreateFractureTextureCoordinates(int[] gridIndexes, float[] values, float minValue, float maxValue)
        //{
        //    return ((DynamicUnstructureGridFactory)this.Factory).CreateFractureTextureCoordinates(this, gridIndexes, values, minValue, maxValue);
        //}
    }
}
