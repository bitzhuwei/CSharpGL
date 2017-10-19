using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class RotateLeftHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nBits"></param>
        /// <returns></returns>
        public static int RotateLeft(int value, int nBits)
        {
            nBits %= 32;
            return value << nBits | value >> 32 - nBits;
        }
    }
}
