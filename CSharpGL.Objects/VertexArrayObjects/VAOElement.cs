using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.VertexArrayObjects
{
    /// <summary>
    /// 用VAO渲染一个元素。
    /// </summary>
    public abstract class VAOElement
    {
        public VAOElement()
        {

        }

        protected bool initialized = false;

        /// <summary>
        /// 初始化此VAOElement
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
        /// 初始化Shader和VAO
        /// </summary>
        protected abstract void DoInitialize();

        public abstract void Render(RenderModes renderMode);
    }
}
