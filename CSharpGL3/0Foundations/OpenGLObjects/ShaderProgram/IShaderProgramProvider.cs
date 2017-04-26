using System;
using System.Linq;

namespace CSharpGL
{
    /// <summary>
    /// Data for CPU(model) -&gt; Data for GPU(buffer renderer)
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
    public class ShaderCodeArray : IShaderProgramProvider
    {
        private Shader[] shaders;
        //private ShaderProgram program;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shaderCodes"></param>
        public ShaderCodeArray(ShaderCode[] shaderCodes)
        {
            this.shaders = (from item in shaderCodes select item.CreateShader()).ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ShaderProgram GetShaderProgram()
        {
            var program = new ShaderProgram();
            program.Initialize(shaders);

            return program;
            //return this.shaderCodes.CreateProgram();
            //if (this.program == null)
            //{
            //	this.program = this.shaderCodes.CreateProgram();
            //	this.shaderCodes = null;
            //}
            //return this.program;
        }
    }
}