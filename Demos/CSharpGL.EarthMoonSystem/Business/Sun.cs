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
        public const double radius = 1200.0 / 3.0;

        public void Elapse(double interval)
        {
        }

        public vec3 GetPosition()
        {
            return new vec3();
        }

        public mat4 GetModelRotationMatrix()
        {
            return glm.scale(mat4.identity(), new vec3(scaleFactor, scaleFactor, scaleFactor));
        }

        private float scaleFactor = 1.0f;

        public float ScaleFactor
        {
            get { return scaleFactor; }
            set { scaleFactor = value; }
        }
        public override string ToString()
        {
            return string.Format("Sun");
        }
    }
}
