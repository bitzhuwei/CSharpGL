using CSharpGL.Objects;
using CSharpGL.Texts;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL.Texts.StringModelFactory;

namespace CSharpGL.UIs
{
    public class DummyLabel : RendererBase, IUILayout
    {
        public StringRenderer renderer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anchor">the edges of the viewport to which a SimpleUIRect is bound and determines how it is resized with its parent.
        /// <para>something like AnchorStyles.Left | AnchorStyles.Bottom.</para></param>
        /// <param name="margin">the space between viewport and SimpleRect.</param>
        /// <param name="size">Stores width when <see cref="OpenGLUIRect.Anchor"/>.Left & <see cref="OpenGLUIRect.Anchor"/>.Right is <see cref="OpenGLUIRect.Anchor"/>.None.
        /// <para> and height when <see cref="OpenGLUIRect.Anchor"/>.Top & <see cref="OpenGLUIRect.Anchor"/>.Bottom is <see cref="OpenGLUIRect.Anchor"/>.None.</para></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        /// <param name="rectColor">default color is red.</param>
        public DummyLabel(IUILayoutParam param, string content)
        {
            this.renderer = new StringRenderer(content.GetModel());
            // 把AxiesElement缩放到恰好放进此UI
            //radius = radius / axisLength / 2;
            //axisLength = 0.5f;
            //this.axisElement = new AxisElement(radius, axisLength, faceCount);

            IUILayout layout = this;
            layout.Param = param;
        }

        protected override void DisposeUnmanagedResources()
        {
            this.renderer.Dispose();
        }

        #region IUILayout

        public IUILayoutParam Param { get; set; }

        #endregion IUILayout

        protected override void DoInitialize()
        {
            this.renderer.Initialize();
        }

        protected override void DoRender(RenderEventArgs e)
        {
            mat4 projectionMatrix, viewMatrix, modelMatrix;
            {
                IUILayout element = this as IUILayout;
                //element.GetMatrix(out projectionMatrix, out viewMatrix, out modelMatrix, e.Camera);
                element.GetMatrix(out projectionMatrix, out viewMatrix, out modelMatrix, null);
            }
            this.renderer.mvp = projectionMatrix * viewMatrix * modelMatrix;

            this.renderer.Render(e);

        }
    }
}
