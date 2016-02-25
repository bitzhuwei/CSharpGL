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
        /// <param name="param">the edges of the viewport to which a SimpleUIRect is bound and determines how it is resized with its parent.
        /// <para>something like AnchorStyles.Left | AnchorStyles.Bottom.</para></param>
        /// <param name="content"></param>
        public DummyLabel(IUILayoutParam param, string content)
        {
            this.renderer = new StringRenderer(content.GetDummyModel());

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
