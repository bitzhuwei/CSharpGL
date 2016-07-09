using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class FloatHelper
    {
        /// <summary>
        /// 获取float类型的简短描述。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToShortString(this float value)
        {
            string result = string.Empty;

            if (value <= -10 || 10 <= value)
            {
                result = string.Format("{0:0.00}", value);
            }
            else
            {
                result = string.Format("{0:0.0000}", value);
            }

            //if(!result.StartsWith("-"))
            //{
            //    result = "+" + result;
            //}

            return result;
        }
    }
}
