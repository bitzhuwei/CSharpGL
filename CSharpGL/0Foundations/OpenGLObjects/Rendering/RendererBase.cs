using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// 用OpenGL初始化和渲染一个模型。
    /// <para>Initialize and render something with OpenGL.</para>
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public abstract partial class RendererBase : IRenderable, IDisposable
    {
        private readonly object synObj = new object();

        private const string strRendererBase = "RendererBase";

        /// <summary>
        /// binding scene object.
        /// </summary>
        [Category(strRendererBase)]
        [Description("binding object.")]
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public SceneObject BindingSceneObject { get; set; }

        /// <summary>
        /// Render this or not.
        /// </summary>
        [Category(strRendererBase)]
        [Description("Render this or not.")]
        public bool Enabled { get; set; }

        /// <summary>
        /// 为便于调试而设置的ID值，没有应用意义。
        /// <para>for debugging purpose only.</para>
        /// </summary>
        [Category(strRendererBase)]
        [Description("为便于调试而设置的ID值，没有应用意义。(for debugging purpose only.)")]
        public int Id { get; private set; }

        private static int idCounter = 0;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[{0}]: [{1}]", this.Id, this.GetType().Name);
        }

        /// <summary>
        /// 用OpenGL初始化和渲染一个模型。
        /// <para>Initialize and render something with OpenGL.</para>
        /// </summary>
        public RendererBase()
        {
            this.Enabled = true;
            this.Id = idCounter++;
        }
    }
}