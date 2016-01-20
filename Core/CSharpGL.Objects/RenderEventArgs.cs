using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects
{
    /// <summary>
    /// 渲染事件的参数。
    /// </summary>
    public class RenderEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderEventArgs"/> class.
        /// </summary>
        /// <param name="renderMode">渲染模式</param>
        /// <param name="camera">渲染时所用的camera</param>
        public RenderEventArgs(RenderModes renderMode, ICamera camera)
        {
            this.RenderMode = renderMode;
            this.Camera = camera;
        }

        /// <summary>
        /// 获取Camera
        /// </summary>
        public ICamera Camera { get; private set; }

        /// <summary>
        /// 获取渲染模式
        /// </summary>
        public RenderModes RenderMode { get; private set; }

    }

    public enum RenderModes
    {
        Render,
        HitTest,
        DesignMode,
    }
}
