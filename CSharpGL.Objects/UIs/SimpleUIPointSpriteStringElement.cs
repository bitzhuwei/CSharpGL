using CSharpGL.Maths;
using CSharpGL.Objects.SceneElements;
using CSharpGL.Objects.Shaders;
using CSharpGL.Texts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.UIs
{
    /// <summary>
    /// 用shader+VAO+组装的texture显示一个指定的字符串
    /// <para>代表一个三维空间内的内容不可变的字符串</para>
    /// </summary>
    public class SimpleUIPointSpriteStringElement : SceneElementBase, IMVP, IUILayout, IDisposable
    {
        PointSpriteStringElement element;

        public SimpleUIPointSpriteStringElement(IUILayoutParam param,
            string content, vec3 position, 
            GLColor color = null, int fontSize = 32, int maxRowWidth = 256, FontResource fontResource = null)
        {
            IUILayout layout = this;
            layout.Param = param;
            this.element = new PointSpriteStringElement(content, position, color, fontSize, maxRowWidth, fontResource);
        }
        protected override void DoInitialize()
        {
            this.element.Initialize();

            this.BeforeRendering += this.GetSimpleUI_BeforeRendering();
            this.AfterRendering += this.GetSimpleUI_AfterRendering();
        }

        protected override void DoRender(RenderEventArgs e)
        {
            this.element.Render(e);
        }

        ~SimpleUIPointSpriteStringElement()
        {
            this.Dispose();
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
                // Managed cleanup code here, while managed refs still valid
                this.element.Dispose();
            }
            // Unmanaged cleanup code here

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

        void IMVP.SetShaderProgram(mat4 mvp)
        {
            IMVP element = this.element as IMVP;
            element.SetShaderProgram(mvp);
        }

        void IMVP.ResetShaderProgram()
        {
            IMVP element = this.element as IMVP;
            element.ResetShaderProgram();
        }

        ShaderProgram IMVP.GetShaderProgram()
        {
            return ((IMVP)this.element).GetShaderProgram();
        }

        IUILayoutParam IUILayout.Param { get; set; }
    }
}
