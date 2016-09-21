using System;

namespace CSharpGL
{
    /// <summary>
    /// 根据<see cref="IndexBufferPtr"/>的具体类型获取一个<see cref="PickableRenderer"/>
    /// </summary>
    internal static class InnerPickableRendererFactory
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
            AttributeNameMap propertyNameMap,
            string positionNameInIBufferable,
            params GLSwitch[] switches)
        {
            if (bufferable == null || propertyNameMap == null || string.IsNullOrEmpty(positionNameInIBufferable))
            { throw new ArgumentNullException(); }

            AttributeNameMap map = null;
            foreach (var item in propertyNameMap)
            {
                if (item.NameInIBufferable == positionNameInIBufferable)
                {
                    map = new AttributeNameMap();
                    map.Add(item.VarNameInShader, item.NameInIBufferable);
                    break;
                }
            }
            if (map == null) { throw new Exception(string.Format("No matching variable name in shader for [{0}]", positionNameInIBufferable)); }

            if (bufferable.UsesZeroIndexBuffer())
            {
                return new ZeroIndexRenderer(bufferable, PickingShaderHelper.GetShaderCodes(), map, positionNameInIBufferable, switches);
            }
            else
            {
                return new OneIndexRenderer(bufferable, PickingShaderHelper.GetShaderCodes(), map, positionNameInIBufferable, switches);
            }
        }
    }
}