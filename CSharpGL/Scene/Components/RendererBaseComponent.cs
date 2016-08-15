//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace CSharpGL
//{
//    /// <summary>
//    /// default renderer component that wraps a <see cref="RendererBase"/>.
//    /// </summary>
//    public class RendererBaseComponent : RendererComponent
//    {
//        private RendererBase renderer;

//        public RendererBase Renderer
//        {
//            get { return renderer; }
//            set { renderer = value; }
//        }

//        /// <summary>
//        /// default renderer component that wraps a <see cref="RendererBase"/>.
//        /// </summary>
//        /// <param name="renderer"></param>
//        /// <param name="obj"></param>
//        public RendererBaseComponent(RendererBase renderer, SceneObject obj = null)
//            : base(obj)
//        {
//            this.renderer = renderer;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="arg"></param>
//        public override void Render(RenderEventArg arg)
//        {
//            RendererBase renderer = this.renderer;
//            if (renderer != null)
//            {
//                renderer.Render(arg);
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        protected override void DisposeUnmanagedResource()
//        {
//            RendererBase renderer = this.renderer;
//            if (renderer != null)
//            {
//                this.renderer = null;
//                renderer.Dispose();
//            }
//        }
//    }
//}
