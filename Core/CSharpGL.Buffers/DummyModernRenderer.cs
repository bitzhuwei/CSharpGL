using CSharpGL.Objects;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Buffers
{
    /// <summary>
    /// 试验版的Renderer，使用modern OpenGL
    /// </summary>
    public abstract class DummyModernRenderer : RendererBase
    {
        // 算法
        protected ShaderProgram shaderProgram;

        // 数据结构
        protected BufferRenderer[] propertyBufferRenderers;
        protected IndexBufferRendererBase indexBufferRenderer;
        //protected VertexArrayObject vertexArrayObject;

        /// <summary>
        /// 从模型到buffer的renderer
        /// </summary>
        private IConvert2BufferRenderer model;
        /// <summary>
        /// shader代码
        /// </summary>
        private CodeShader[] allShaderCodes;
        /// <summary>
        /// vertex shader中的in变量与<see cref="propertyBufferRenderers"/>中的元素名字的对应关系。
        /// </summary>
        private PropertyNameMap map;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">从模型到buffer的renderer</param>
        /// <param name="allShaderCodes">shader代码</param>
        /// <param name="map">vertex shader中的in变量与<see cref="propertyBufferRenderers"/>中的元素名字的对应关系。</param>
        public DummyModernRenderer(IConvert2BufferRenderer model, CodeShader[] allShaderCodes, PropertyNameMap map)
        {
            this.model = model; this.allShaderCodes = allShaderCodes; this.map = map;
        }

        protected override void DoInitialize()
        {
            // init shader program
            ShaderProgram program = new ShaderProgram();
            string vertexShaderCode = null, geometryShaderCode = null, fragmentShaderCode = null;
            FillShaderCodes(this.allShaderCodes, ref vertexShaderCode, ref geometryShaderCode, ref fragmentShaderCode);
            program.Create(vertexShaderCode, fragmentShaderCode, geometryShaderCode, null);
            this.shaderProgram = program;
            this.allShaderCodes = null;

            // init property buffer objects' renderer
            var propertyBufferRenderers = new BufferRenderer[map.Count()];
            int index = 0;
            foreach (var item in map)
            {
                BufferRenderer bufferRenderer = this.model.GetBufferRenderer(
                item.NameInIConvert2BufferRenderer, item.VarNameInShader);
                if (bufferRenderer == null) { throw new Exception(); }
                propertyBufferRenderers[index++] = bufferRenderer;
            }
            this.propertyBufferRenderers = propertyBufferRenderers;
            this.map = null;

            // init index buffer object's renderer
            this.indexBufferRenderer = this.model.GetIndexBufferRenderer();
            this.model = null;
        }

        private void FillShaderCodes(CodeShader[] allShaderCodes, ref string vertexShaderCode, ref string geometryShaderCode, ref string fragmentShaderCode)
        {
            bool vertexShaderFilled = false, geometryShaderFilled = false, fragmentShaderFilled = false;
            foreach (var item in allShaderCodes)
            {
                switch (item.ShaderType)
                {
                    case ShaderType.VertexShader:
                        if (vertexShaderFilled)
                        { throw new Exception(string.Format("There should be only 1 vertex shader.")); }
                        vertexShaderCode = item.SourceCode;
                        vertexShaderFilled = true;
                        break;
                    case ShaderType.GeometryShader:
                        if (geometryShaderFilled)
                        { throw new Exception(string.Format("There should be only 1 geometry shader.")); }
                        geometryShaderCode = item.SourceCode;
                        geometryShaderFilled = true;
                        break;
                    case ShaderType.FragmentShader:
                        if (fragmentShaderFilled)
                        { throw new Exception(string.Format("There should be only 1 fragment shader.")); }
                        fragmentShaderCode = item.SourceCode;
                        fragmentShaderFilled = true;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            if (!vertexShaderFilled)
            { throw new Exception("No vertex shader specified!"); }
            if (!geometryShaderFilled)
            { geometryShaderCode = null; }
            if (!fragmentShaderFilled)
            { throw new Exception("No fragment shader specified!"); }
        }

    }
}
