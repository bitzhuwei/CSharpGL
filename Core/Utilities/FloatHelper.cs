﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class FloatHelper
    {
        /// <summary>
        /// 获取float类型的简短描述。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToShortString(this float value)
        {
            string result = null;
            if (value <= -10 || 10 <= value)
            {
                result = string.Format("{0:0.0}", value);
            }
            else
            {
                result = string.Format("{0:0.00}", value);
            }

            return result;
        }
    }
}
