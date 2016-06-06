using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.EarthMoonSystem
{
    class Earth : ITimeElapse
    {
        const double singleRotationSpeed = 360.0 / 24 / 60 / 60 / 1000;// X°每毫秒
        // 每秒自转1周。用于测试应该用角度还是弧度（结果是应该用弧度）。
        //const double singleRotationSpeed = 360.0 / 1000.0;//°每毫秒

        /// <summary>
        /// 自转角度
        /// </summary>
        public double SingleRotationAngle { get; private set; }

        /// <summary>
        /// 自转弧度
        /// </summary>
        public double SingleRotationRadian
        {
            get
            {
                return this.SingleRotationAngle * Math.PI / 180.0;
            }
        }

        public void Elapse(double interval)
        {
            double angle = this.SingleRotationAngle + singleRotationSpeed * interval;
            if (360 < angle)
            {
                angle = angle % 360;
            }

            this.SingleRotationAngle = angle;
        }

        public override string ToString()
        {
            return string.Format("Single Rotation: {0}°", this.SingleRotationAngle);
        }
    }
}
