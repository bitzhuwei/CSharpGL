using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public static class ModernRendererFactory
    {
        public static ModernRenderer GetModernRenderer(this IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
        {
            if (bufferable == null || shaderCodes == null || propertyNameMap == null || string.IsNullOrEmpty(positionNameInIBufferable))
            { throw new ArgumentNullException(); }

            IndexBufferPtr indexBufferPtr = bufferable.GetIndex();
            if (indexBufferPtr is ZeroIndexBufferPtr)
            {
                return new ZeroIndexModernRenderer(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches);
            }
            else if (indexBufferPtr is OneIndexBufferPtr)
            {
                return new OneIndexModernRenderer(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches);
            }
            else
            { throw new NotImplementedException(); }
        }
    }
}
