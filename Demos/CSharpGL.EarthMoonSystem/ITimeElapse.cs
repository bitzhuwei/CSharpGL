using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.EarthMoonSystem
{
    interface ITimeElapse
    {
        /// <summary>
        /// 时间流逝（单位：毫秒）
        /// </summary>
        /// <param name="interval">流逝的时间（毫秒）</param>
        void Elapse(double interval);
    }
}
