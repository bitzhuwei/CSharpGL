using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace PointLight.NoShadow
{
    partial class PointLightNoShadowNode : ModernNode, IRenderable
    {

        private PointLightNoShadowNode(IBufferSource model, params RenderMethodBuilder[] builders) : base(model, builders) { }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering { get { return this.enableRendering; } set { this.enableRendering = value; } }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
