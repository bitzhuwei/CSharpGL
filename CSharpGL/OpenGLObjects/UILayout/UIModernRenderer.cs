﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 支持"拾取"的渲染器
    /// </summary>
    public partial class UIModernRenderer : RendererBase, IUILayout
    {
        private ModernRenderer modernRenderer;

        public ModernRenderer ModernRenderer
        {
            get { return modernRenderer; }
        }

        /// <summary>
        /// 支持"拾取"的渲染器
        /// </summary>
        /// <param name="bufferable">一种渲染方式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="propertyNameMap">关联<see cref="PropertyBufferPtr"/>和<see cref="shaderCode"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        public UIModernRenderer(
            ModernRenderer modernRenderer,
            System.Windows.Forms.AnchorStyles Anchor,
            System.Windows.Forms.Padding Margin,
            System.Drawing.Size Size,
            int zNear = -1000,
            int zFar = 1000
            )
        {
            this.modernRenderer = modernRenderer;
            this.Anchor = Anchor;
            this.Margin = Margin;
            this.Size = Size;
            this.zNear = zNear;
            this.zFar = zFar;
        }


        protected override void DoInitialize()
        {
            this.modernRenderer.Initialize();
        }

        protected override void DoRender(RenderEventArgs e)
        {
            this.modernRenderer.Render(e);
        }

        protected override void DisposeUnmanagedResources()
        {
            this.modernRenderer.Dispose();
        }

        public System.Windows.Forms.AnchorStyles Anchor { get; set; }

        public System.Windows.Forms.Padding Margin { get; set; }

        public System.Drawing.Size Size { get; set; }

        public int zNear { get; set; }

        public int zFar { get; set; }
    }
}
