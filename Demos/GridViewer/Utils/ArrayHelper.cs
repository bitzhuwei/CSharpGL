using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SimLab
{
    public static class ArrayHelper
    {

        /// <summary>
        /// 创建数组
        /// </summary>
        /// <param name="dimenSize">数组大小</param>
        /// <param name="value">初始值</param>
        /// <returns></returns>
        public static int[] NewIntArray(int dimenSize, int value = 1)
        {
            int[] array = new int[dimenSize];
            for (int i = 0; i < dimenSize; i++)
            {
                array[i] = value;
            }
            return array;
        }

        public static float[] NewFloatArray(int size, float value = 2)
        {
            float[] array = new float[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = value;
            }
            return array;
        }

        public static List<int> CreateAllSlices(int max)
        {
            List<int> results = new List<int>();
            for (int i = 1; i <= max; i++)
            {
                results.Add(i);
            }
            return results;
        }
    }
}
