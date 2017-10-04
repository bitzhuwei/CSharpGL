using System;
using System.Linq;

namespace CSharpGL
{
    /// <summary>
    /// Data for CPU(model) -&gt; Data for GPU(buffer node)
    /// <para>从模型的数据格式转换为<see cref="GLBuffer"/>，<see cref="GLBuffer"/>转换为<see cref="GLBuffer"/>，
    /// <see cref="GLBuffer"/>则可用于控制GPU的渲染操作。</para>
    /// </summary>
    public interface IShaderProgramProvider
    {
        /// <summary>
        /// 获取一个<see cref="ShaderProgram"/>实例。
        /// </summary>
        /// <returns></returns>
        ShaderProgram GetShaderProgram();
    }

    /// <summary>
    /// 
    /// </summary>
    public class ShaderArray : IShaderProgramProvider
    {
        private string[] feedbackVaryings;
        private ShaderProgram.BufferMode mode;
        private Shader[] shaders;

        /// <summary>
        /// result.
        /// </summary>
        private ShaderProgram program;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shaders"></param>
        public ShaderArray(params Shader[] shaders)
        {
            this.shaders = shaders;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feedbackVaryings"></param>
        /// <param name="mode"></param>
        /// <param name="shaders"></param>
        public ShaderArray(string[] feedbackVaryings, ShaderProgram.BufferMode mode, params Shader[] shaders)
        {
            this.feedbackVaryings = feedbackVaryings;
            this.mode = mode;
            this.shaders = shaders;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ShaderProgram GetShaderProgram()
        {
            if (this.program == null)
            {
                var program = new ShaderProgram();
                if (this.feedbackVaryings != null)
                {
                    program.Initialize(this.feedbackVaryings, this.mode, this.shaders);
                }
                else
                {
                    program.Initialize(this.shaders);
                }

                this.program = program;
            }

            return this.program;
        }
    }
}