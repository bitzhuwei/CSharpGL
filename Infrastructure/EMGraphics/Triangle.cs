using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMGraphics
{
    /// <summary>
    /// 
    /// </summary>
    public class Triangle
    {
        /// <summary>
        /// 本面元的第一个点
        /// </summary>
        public int Num1 { get; set; }

        /// <summary>
        /// 本面元的第二个点
        /// </summary>
        public int Num2 { get; set; }

        /// <summary>
        /// 本面元的第三个点
        /// </summary>
        public int Num3 { get; set; }

        /// <summary>
        /// 网格平面的单位法向量
        /// </summary>
        public vec3 Normal { get; set; }

        /// <summary>
        /// 面元的重心坐标
        /// </summary>
        public vec3 GravityPoint { get; set; }

        /// <summary>
        /// 网格的面积
        /// </summary>
        public double Area { get; set; }

    }
}
