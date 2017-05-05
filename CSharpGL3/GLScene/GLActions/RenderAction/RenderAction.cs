using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class RenderAction : GLAction
    {
        //private static readonly Type type = typeof(RenderAction);
        //internal override Type ThisTypeCache
        //{
        //    get { return type; }
        //}

        /// <summary>
        /// 
        /// </summary>
        public RenderAction()
        {
            this.Context = new RenderActionContext();
        }

        /// <summary>
        /// 
        /// </summary>
        public RenderActionContext Context { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void Render()
        {
            if (this.AppliedNode == null) { throw new Exception("No node applied!"); }

            OpenGL.ClearColor = Color.SkyBlue;
            OpenGL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

            this.Triverse(this.AppliedNode);
        }

        private void Triverse(GLNode gLNode)
        {
            GLSnippet snippet = this.FindSnippet(gLNode);
            if (snippet != null)
            {
                snippet.BeforeChildren(this, gLNode);
            }

            foreach (var item in gLNode.Children)
            {
                this.Triverse(item);
            }

            if (snippet != null)
            {
                snippet.AfterChildren(this, gLNode);
            }
        }

    }
}
