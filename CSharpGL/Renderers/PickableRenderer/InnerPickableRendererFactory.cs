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
        /// <param name="attributeNameMap"></param>
        /// <param name="positionNameInIBufferable"></param>
        /// <param name="switches"></param>
        /// <returns></returns>
        public static InnerPickableRenderer GetRenderer(
            this IBufferable model,
            AttributeNameMap attributeNameMap,
            string positionNameInIBufferable,
            params GLSwitch[] switches)
        {
            if (model == null || attributeNameMap == null || string.IsNullOrEmpty(positionNameInIBufferable))
            { throw new ArgumentNullException(); }

            AttributeNameMap map = null;
            foreach (var item in attributeNameMap)
            {
                if (item.NameInIBufferable == positionNameInIBufferable)
                {
                    map = new AttributeNameMap();
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