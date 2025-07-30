using System;
using System.Linq;

namespace CSharpGL {
    /// <summary>
    /// Data for CPU(model) -&gt; Data for GPU(buffer node)
    /// <para>从模型的数据格式转换为<see cref="GLBuffer"/>，<see cref="GLBuffer"/>转换为<see cref="GLBuffer"/>，
    /// <see cref="GLBuffer"/>则可用于控制GPU的渲染操作。</para>
    /// </summary>
    public interface IGLProgramProvider {
        /// <summary>
        /// 获取一个<see cref="GLProgram"/>实例。
        /// </summary>
        /// <returns></returns>
        GLProgram? GetShaderProgram();
    }

    /// <summary>
    /// 
    /// </summary>
    public class ShaderArray : IGLProgramProvider {
        private string[]? feedbackVaryings;
        private GLProgram.BufferMode mode;
        private Shader[] shaders;

        /// <summary>
        /// result.
        /// </summary>
        private GLProgram? program;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shaders"></param>
        public ShaderArray(params Shader[] shaders) {
            this.shaders = shaders;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feedbackVaryings"></param>
        /// <param name="mode"></param>
        /// <param name="shaders"></param>
        public ShaderArray(string[] feedbackVaryings, GLProgram.BufferMode mode, params Shader[] shaders) {
            this.feedbackVaryings = feedbackVaryings;
            this.mode = mode;
            this.shaders = shaders;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GLProgram? GetShaderProgram() {
            if (this.program == null) {
                if (this.feedbackVaryings != null) {
                    var (program, log) = GLProgram.Create(this.feedbackVaryings, this.mode, this.shaders);
                    this.program = program;
                }
                else {
                    var (program, log) = GLProgram.Create(this.shaders);
                    this.program = program;
                }
            }

            return this.program;
        }
    }
}