using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SimLab.helper
{
    /// <summary>
    /// 自动计算坐标范围
    /// </summary>
    public class ColorIndicatorAxisAutomator
    {
        private static readonly double[] SCALES = { 0.1, 0.2, 0.5, 1 };
        private static readonly double[] UNIT_DECREASE_FACTORS = { 0.5, 0.2, 0.1, 0.05 };
        private static readonly double[] SCALE_MUTIPLY = { 1, 2, 5, 10 };

        private static void MinMax(ref double min, ref double max)
        {
            double minval = Math.Min(min, max);
            double maxval = Math.Max(min, max);
            min = minval;
            max = maxval;
            return;
        }

        /// <summary>
        /// 自动计算步长
        /// </summary>
        /// <param name="min">实际的最小值</param>
        /// <param name="max">实际的最大值</param>
        /// <param name="axisMin">计算出的坐标轴起始值</param>
        /// <param name="axisMax">计算出的坐标轴终止值</param>
        /// <param name="scale">计算出的刻度大小，如果需要计算刻度数用 (int)Math.Round((axisMax-axisMin)/scale)</param>
        public static void Automate(double min, double max, out double axisMin, out double axisMax, out double scale)
        {
            int expectedMaxSteps = 10; //期待的最大步长
            double mnDiff;

            MinMax(ref min, ref max);
            if ((min == max) && min == 0.0d)
            {
                axisMin = 0.0d;
                axisMax = 1.0d;
                scale = (axisMax - axisMin) / expectedMaxSteps;
                return;
            }

            //确定最大最小值
            int majorUnitPow;
            mnDiff = max - min;
            if (mnDiff == 0.0d)
            {
                majorUnitPow = (int)Math.Floor(Math.Log10(Math.Abs(max)));
                double minorMajorUnit = Math.Pow(10, majorUnitPow - 1);
                min = max - minorMajorUnit;
                mnDiff = max - min;
            }

            majorUnitPow = (int)Math.Floor(Math.Log10(mnDiff));

            double majorUnit = Math.Pow(10, majorUnitPow);
            int steps = (int)Math.Floor((max - min) / majorUnit);
            if (steps <= 4)
            {
                double tryMajorUnit;
                //增加steps,减少majorUnit
                for (int i = 0; i < UNIT_DECREASE_FACTORS.Length; i++)
                {
                    tryMajorUnit = majorUnit * UNIT_DECREASE_FACTORS[i];
                    steps = (int)Math.Floor((max - min) / tryMajorUnit);
                    if (steps > 4 && steps <= 10)
                    {
                        majorUnit = tryMajorUnit;
                        break;
                    }
                }
            }

            //修正最大值，最小值
            axisMin = Math.Floor(min / majorUnit) * majorUnit;
            axisMax = Math.Ceiling(max / majorUnit) * majorUnit;
            scale = majorUnit;
            return;
        }
    }
}
