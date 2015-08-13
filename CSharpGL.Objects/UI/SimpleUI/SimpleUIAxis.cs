using CSharpGL.Maths;
using CSharpGL.Objects.SceneElements;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Objects.UI.SimpleUI
{
    public class SimpleUIAxis : SceneElementBase, IUILayout, IDisposable
    {
        public AxisElement axisElement;

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
        public SimpleUIAxis(AnchorStyles anchor, Padding margin, System.Drawing.Size size,
            int zNear = -1000, int zFar = 1000, GLColor rectColor = null,
            float radius = 0.3f, float length = 10, int faceCount = 10)
        {
            this.axisElement = new AxisElement(radius, length, faceCount);

            IUILayout layout = this;
            layout.Anchor = anchor;
            layout.Margin = margin;
            layout.Size = size;
            layout.zNear = zNear;
            layout.zFar = zFar;
            if (rectColor == null)
            { layout.RectColor = new vec3(1, 0, 0); }
            else
            { layout.RectColor = new vec3(1, 0, 0); }

            layout.RenderBound = true;
        }

        #region IDisposable Members

        /// <summary>
        /// Internal variable which checks if Dispose has already been called
        /// </summary>
        protected Boolean disposed;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected void Dispose(Boolean disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //Managed cleanup code here, while managed refs still valid
            }
            //Unmanaged cleanup code here
            if (this.axisElement != null)
            {
                this.axisElement.Dispose();
                this.axisElement = null;
            }

            disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Call the private Dispose(bool) helper and indicate
            // that we are explicitly disposing
            this.Dispose(true);

            // Tell the garbage collector that the object doesn't require any
            // cleanup when collected since Dispose was called explicitly.
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IUILayout

        AnchorStyles IUILayout.Anchor { get; set; }

        Padding IUILayout.Margin { get; set; }

        System.Drawing.Size IUILayout.Size { get; set; }

        int IUILayout.zNear { get; set; }

        int IUILayout.zFar { get; set; }

        vec3 IUILayout.RectColor { get; set; }

        bool IUILayout.RenderBound { get; set; }

        #endregion IUILayout


        protected override void DoInitialize()
        {
            this.axisElement.Initialize();
        }

        protected override void DoRender(RenderModes renderMode)
        {
            this.axisElement.Render(renderMode);
        }
    }
}
