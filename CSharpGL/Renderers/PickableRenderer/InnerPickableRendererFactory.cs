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
        /// <param name="model"></param>
        /// <param name="attributeMap"></param>
        /// <param name="positionNameInIBufferable"></param>
        /// <param name="switches"></param>
        /// <returns></returns>
        public static InnerPickableRenderer GetRenderer(
            this IBufferable model,
            AttributeMap attributeMap,
            string positionNameInIBufferable,
            params GLSwitch[] switches)
        {
            if (model == null || attributeMap == null || string.IsNullOrEmpty(positionNameInIBufferable))
            { throw new ArgumentNullException(); }

            AttributeMap map = null;
            foreach (AttributeMap.NamePair item in attributeMap)
            {
                if (item.NameInIBufferable == positionNameInIBufferable)
                {
                    map = new AttributeMap();
                    map.Add(item.VarNameInShader, item.NameInIBufferable);
                    break;
                }
            }
            if (map == null) { throw new Exception(string.Format("No matching variable name in shader for [{0}]", positionNameInIBufferable)); }

            if (model.UsesZeroIndexBuffer())
            {
                return new ZeroIndexRenderer(model, PickingShaderHelper.GetShaderCodes(), map, positionNameInIBufferable, switches);
            }
            else
            {
                return new OneIndexRenderer(model, PickingShaderHelper.GetShaderCodes(), map, positionNameInIBufferable, switches);
            }
        }
    }
}