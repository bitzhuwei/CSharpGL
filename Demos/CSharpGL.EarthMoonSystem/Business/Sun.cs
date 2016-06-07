using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.EarthMoonSystem
{
    class Sun : ITimeElapse
    {
        /// <summary>
        /// 半径（单位：千米）
        /// </summary>
        public const double radius = 695000;

        public void Elapse(double interval)
        {
        }

        public mat4 GetModelRotationMatrix()
        {
            return mat4.identity();
        }

        public override string ToString()
        {
            return string.Format("Sun");
        }
    }
}
