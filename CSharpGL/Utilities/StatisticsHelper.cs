using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public static class StatisticsHelper
    {
        /// <summary>
        /// 求平均值和方差
        /// </summary>
        /// <param name="values"></param>
        /// <param name="average"></param>
        /// <param name="variance"></param>
        public static void AverageVariance(this float[] values, out float average, out float variance)
        {
            average = Average(values);

            var array = new float[values.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (values[i] - average) * (values[i] - average);
            }

            variance = Average(array);
        }
        /// <summary>
        /// 求平均值和方差
        /// </summary>
        /// <param name="values"></param>
        /// <param name="average"></param>
        /// <param name="variance"></param>
        public static void AverageVariance(this double[] values, out double average, out double variance)
        {
            average = Average(values);

            var array = new double[values.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (values[i] - average) * (values[i] - average);
            }

            variance = Average(array);
        }

        /// <summary>
        /// 求平均值
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static float Average(this float[] values)
        {
            if (values == null || values.Length == 0) { throw new ArgumentException(); }

            float average1 = values[0];
            for (int index = 1; index < values.Length; index++)
            {
                average1 = average1 * ((float)index / ((float)index + 1)) + values[index] / (index + 1);
            }
            float average2 = values[values.Length - 1];
            for (int j = values.Length - 2, index = 1; index < values.Length; j--, index++)
            {
                average2 = average2 * ((float)index / ((float)index + 1)) + values[j] / (index + 1);
            }

            float result = average1 / 2 + average2 / 2;
            return result;
        }
        /// <summary>
        /// 求平均值
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static double Average(this double[] values)
        {
            if (values.Length == 0) { return 0; }

            double average1 = values[0];
            for (int index = 1; index < values.Length; index++)
            {
                average1 = average1 * ((double)index / ((double)index + 1)) + values[index] / (index + 1);
            }
            double average2 = values[values.Length - 1];
            for (int j = values.Length - 2, index = 1; index < values.Length; j--, index++)
            {
                average2 = average2 * ((double)index / ((double)index + 1)) + values[j] / (index + 1);
            }

            double result = average1 / 2 + average2 / 2;
            return result;
        }
    }
}
