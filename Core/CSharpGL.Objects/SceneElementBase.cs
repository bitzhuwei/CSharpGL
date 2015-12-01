using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects
{
    /// <summary>
    /// 用OpenGL初始化和渲染一个元素。
    /// 只做初始化和渲染这两件事。
    /// 渲染前后有事件event可以配置。
    /// </summary>
    public abstract class SceneElementBase : IRenderable
    {
        /// <summary>
        /// 为便于调试而设置的ID值，没有应用意义。
        /// </summary>
        public int ID { get; protected set; }

        public static int idCounter = 0;

        public override string ToString()
        {
            return string.Format("element: {0}，{1}", this.ID, this.GetType());
        }

        /// <summary>
        /// 用OPENGL渲染一个元素。
        /// </summary>
        public SceneElementBase()
        {
            this.ID = idCounter++;
        }

        protected bool initialized = false;

        /// <summary>
        /// 初始化此Element，此方法应且只应执行1次。
        /// </summary>
        public void Initialize()
        {
            if (!initialized)
            {
                DoInitialize();

                initialized = true;
            }
        }

        /// <summary>
        /// 初始化此Element，此方法应且只应执行1次。
        /// </summary>
        protected abstract void DoInitialize();

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="renderMode"></param>
        public void Render(RenderEventArgs e)
        {
            if (!initialized) { Initialize(); }

            EventHandler<RenderEventArgs> beforeRendering = this.BeforeRendering;
            if (beforeRendering != null)
            {
                beforeRendering(this, e);
            }

            DoRender(e);

            EventHandler<RenderEventArgs> afterRendering = this.AfterRendering;
            if (afterRendering != null)
            {
                afterRendering(this, e);
            }
        }

        /// <summary>
        /// 执行渲染操作
        /// </summary>
        /// <param name="renderMode"></param>
        protected abstract void DoRender(RenderEventArgs e);

        /// <summary>
        /// 在渲染前进行某些准备（更新camera矩阵信息等）
        /// </summary>
        public event EventHandler<RenderEventArgs> BeforeRendering;

        /// <summary>
        /// 在渲染后进行某些善后（恢复OpenGL状态等）
        /// </summary>
        public event EventHandler<RenderEventArgs> AfterRendering;

    }

    ///// <summary>
    ///// 渲染事件的参数。
    ///// </summary>
    //public class RenderEventArgs : EventArgs
    //{
    //    public RenderEventArgs(RenderModes renderMode)
    //    {
    //        this.RenderMode = renderMode;
    //    }

    //    public RenderModes RenderMode { get; protected set; }

    //    public override string ToString()
    //    {
    //        return string.Format("{0}", this.RenderMode);
    //        //return base.ToString();
    //    }
    //}
}
