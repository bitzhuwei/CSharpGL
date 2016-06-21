using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLab.Utils
{

    /// <summary>
    /// 色标参数
    /// </summary>
    public class ColorMapParams
    {

        public bool IsAutomatic { get; set; }

        public double MinValue { get; set; }

        public double MaxValue { get; set; }

        public bool UseLogarithmic { get; set; }

        public double LogBase { get; set; }

        /// <summary>
        /// 步长
        /// </summary>
        public double Step { get; set; }

    }
}
