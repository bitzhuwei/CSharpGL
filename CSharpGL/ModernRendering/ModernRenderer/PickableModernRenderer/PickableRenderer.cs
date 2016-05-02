using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 支持"拾取"的渲染器
    /// </summary>
    public abstract partial class PickableRenderer : Renderer, IColorCodedPicking
    {
        PolygonModeSwitch polygonModeSwitch4Picking = new PolygonModeSwitch(PolygonModes.Filled);

        protected List<GLSwitch> switchList4Picking = new List<GLSwitch>();
        [Editor(typeof(GLSwithListEditor), typeof(UITypeEditor))]
        public IReadOnlyList<GLSwitch> SwitchList4Picking
        {
            get { return switchList4Picking; }
        }

        /// <summary>
        /// 支持"拾取"的渲染器
        /// </summary>
        /// <param name="bufferable">一种渲染方式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="propertyNameMap">关联<see cref="PropertyBufferPtr"/>和<see cref="shaderCode"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        internal PickableRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        {
            {
                this.switchList4Picking.Add(polygonModeSwitch4Picking);
            }
            {
                float min, max;
                GL.LineWidthRange(out min, out max);
                this.switchList4Picking.Add(new LineWidthSwitch(max));
            }
            {
                float min, max;
                GL.PointSizeRange(out min, out max);
                this.switchList4Picking.Add(new PointSizeSwitch(max));
            }
        }
    }
}
