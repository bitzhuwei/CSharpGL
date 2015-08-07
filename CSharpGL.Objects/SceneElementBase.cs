using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects
{
    /// <summary>
    /// 用OPENGL渲染一个元素。
    /// </summary>
    public abstract class SceneElementBase
    {
        /// <summary>
        /// 用OPENGL渲染一个元素。
        /// </summary>
        public SceneElementBase()
        {

        }

        protected bool initialized = false;

        /// <summary>
        /// 初始化此Element
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
        /// 初始化此Element
        /// </summary>
        protected abstract void DoInitialize();

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="renderMode"></param>
        public abstract void Render(RenderModes renderMode);
    }
}
