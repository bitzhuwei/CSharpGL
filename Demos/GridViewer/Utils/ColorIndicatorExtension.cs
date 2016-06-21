using SharpGL.SceneComponent;
using SharpGL.SceneComponent.SimpleUI.ColorIndicator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLab.Utils
{
    public static class ColorIndicatorExtension
    {

        /// <summary>
        /// 简化访问参数的接口
        /// </summary>
        /// <param name="colorIndicator"></param>
        /// <returns></returns>
        public static ColorMapParams GetColorMapParams(this SimpleUIColorIndicator colorIndicator)
        {
               ColorMapParams result = new ColorMapParams();
               result.MaxValue = colorIndicator.Data.MaxValue;
               result.MinValue = colorIndicator.Data.MinValue;
               result.LogBase = colorIndicator.Data.LogBase;
               result.Step = colorIndicator.Data.Step;
               result.UseLogarithmic = colorIndicator.Data.UseLogarithmic;
               return result;
        }


        
    }
}
