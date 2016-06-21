using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLab.GridSource.Factory
{

    /// <summary>
    /// GridderSource 用于创建三维可视对象的抽象
    /// </summary>
    public abstract class GridBufferDataFactory
    {

        /// <summary>
        /// 通过网格数据源生成
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public abstract MeshBase CreateMesh(GridderSource source);

        public abstract TexCoordBuffer CreateTextureCoordinates(GridderSource source, int[] gridIndexes, float[] values, float minValue, float maxValue);

    }
}
