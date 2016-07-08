using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 根据<see cref="IndexBufferPtr"/>的具体类型获取一个<see cref="PickableRenderer"/>
    /// </summary>
    static class InnerPickableRendererFactory
    {
        /// <summary>
        /// 根据<see cref="IndexBufferPtr"/>的具体类型获取一个<see cref="PickableRenderer"/>
        /// </summary>
        /// <param name="bufferable"></param>
        /// <param name="propertyNameMap"></param>
        /// <param name="positionNameInIBufferable"></param>
        /// <param name="switches"></param>
        /// <returns></returns>
        public static InnerPickableRenderer GetRenderer(
            this IBufferable bufferable,
            PropertyNameMap propertyNameMap,
            string positionNameInIBufferable,
            params GLSwitch[] switches)
        {
            if (bufferable == null || propertyNameMap == null || string.IsNullOrEmpty(positionNameInIBufferable))
            { throw new ArgumentNullException(); }

            IndexBufferPtr indexBufferPtr = bufferable.GetIndex();
            if (indexBufferPtr is ZeroIndexBufferPtr)
            {
                return new ZeroIndexRenderer(bufferable, PickingShaderHelper.GetShaderCodes(), propertyNameMap, positionNameInIBufferable, switches);
            }
            else if (indexBufferPtr is OneIndexBufferPtr)
            {
                return new OneIndexRenderer(bufferable, PickingShaderHelper.GetShaderCodes(), propertyNameMap, positionNameInIBufferable, switches);
            }
            else
            { throw new NotImplementedException(); }
        }
    }
}
