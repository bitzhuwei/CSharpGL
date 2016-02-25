using CSharpGL.Objects;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.CompilerBase;
using CSharpGL.GLSLCompiler;

namespace CSharpGL.Buffers
{
    /// <summary>
    /// 试验版的Renderer，使用modern OpenGL
    /// </summary>
    public class DummyModernRenderer : RendererBase
    {
        // 算法
        protected ShaderProgram shaderProgram;

        // 数据结构
        protected VertexArrayObject vertexArrayObject;
        protected BufferRenderer[] propertyBufferRenderers;
        protected IndexBufferRendererBase indexBufferRenderer;
        //protected VertexArrayObject vertexArrayObject;
        protected UniformVariableBase[] uniformVariables;

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
        private PropertyNameMap propertyNameMap;
        /// <summary>
        /// 各个shader中的uniform变量与<see cref="propertyBufferRenderers"/>中的元素名字的对应关系。
        /// </summary>
        protected UniformNameMap uniformNameMap;


        public PolygonModes polygonMode = PolygonModes.Filled;

        private int elementCount;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">从模型到buffer的renderer</param>
        /// <param name="allShaderCodes">shader代码</param>
        /// <param name="propertyNameMap">vertex shader中的in变量与<see cref="propertyBufferRenderers"/>中的元素名字的对应关系。</param>
        public DummyModernRenderer(IConvert2BufferRenderer model, CodeShader[] allShaderCodes, PropertyNameMap propertyNameMap, UniformNameMap uniformNameMap)
        {
            this.model = model;
            this.allShaderCodes = allShaderCodes;
            this.propertyNameMap = propertyNameMap;
            this.uniformNameMap = uniformNameMap;
        }

        public bool GetUniformValue<T>(string uniformNameInIConvert2BufferRenderer, out T value) where T : struct
        {
            string uniformNameInShader = this.uniformNameMap[uniformNameInIConvert2BufferRenderer];
            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == uniformNameInShader)
                {
                    value = (T)item.GetValue();
                    return true;
                }
            }

            value = default(T);

            return false;
        }
        public bool SetUniformValue(string uniformNameInIConvert2BufferRenderer, ValueType value)
        {
            string uniformNameInShader = this.uniformNameMap[uniformNameInIConvert2BufferRenderer];
            foreach (var item in this.uniformVariables)
            {
                if (item.VarName == uniformNameInShader)
                {
                    item.SetValue(value);
                    return true;
                }
            }

            return false;
        }

        protected override void DoRender(RenderEventArgs e)
        {
            ShaderProgram program = this.shaderProgram;
            // 绑定shader
            program.Bind();

            foreach (var item in this.uniformVariables)
            {
                item.SetUniform(program);
            }

            int[] originalPolygonMode = new int[1];
            GL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);

            GL.PolygonMode(PolygonModeFaces.FrontAndBack, this.polygonMode);

            GL.Enable(GL.GL_PRIMITIVE_RESTART);
            GL.PrimitiveRestartIndex(uint.MaxValue);

            if (this.vertexArrayObject == null)
            {
                var vertexArrayObject = new VertexArrayObject(this.indexBufferRenderer, this.propertyBufferRenderers);
                vertexArrayObject.Create(e, program);

                this.vertexArrayObject = vertexArrayObject;
            }
            else
            {
                this.vertexArrayObject.Render(e, program);
            }

            GL.Disable(GL.GL_PRIMITIVE_RESTART);

            GL.PolygonMode(PolygonModeFaces.FrontAndBack, (PolygonModes)(originalPolygonMode[0]));

            // 解绑shader
            program.Unbind();
        }

        protected override void DoInitialize()
        {
            // init shader program
            ShaderProgram program = new ShaderProgram();
            string vertexShaderCode = null, geometryShaderCode = null, fragmentShaderCode = null;
            FillShaderCodes(this.allShaderCodes, ref vertexShaderCode, ref geometryShaderCode, ref fragmentShaderCode);
            program.Create(vertexShaderCode, fragmentShaderCode, geometryShaderCode, null);
            this.shaderProgram = program;

            // init all uniform variables
            this.uniformVariables = GetAllUniformVariables(this.allShaderCodes);

            // init property buffer objects' renderer
            var propertyBufferRenderers = new BufferRenderer[propertyNameMap.Count()];
            int index = 0;
            foreach (var item in propertyNameMap)
            {
                BufferRenderer bufferRenderer = this.model.GetBufferRenderer(
                item.NameInIConvert2BufferRenderer, item.VarNameInShader);
                if (bufferRenderer == null) { throw new Exception(); }
                propertyBufferRenderers[index++] = bufferRenderer;
            }
            this.propertyBufferRenderers = propertyBufferRenderers;

            // init index buffer object's renderer
            this.indexBufferRenderer = this.model.GetIndexBufferRenderer();

            this.model = null;
            this.allShaderCodes = null;
            this.propertyNameMap = null;
            //this.uniformNameMap = null;

            {
                IndexBufferRenderer renderer = this.indexBufferRenderer as IndexBufferRenderer;
                if (renderer != null)
                {
                    this.elementCount = renderer.ElementCount;
                }
            }
            {
                ZeroIndexBufferRenderer renderer = this.indexBufferRenderer as ZeroIndexBufferRenderer;
                if (renderer != null)
                {
                    this.elementCount = renderer.VertexCount;
                }
            }

        }

        private UniformVariableBase[] GetAllUniformVariables(CodeShader[] allShaderCodes)
        {
            List<UniformVariableBase> result = new List<UniformVariableBase>();
            foreach (var shaderCode in allShaderCodes)
            {
                var lexi = new LexicalAnalyzerGLSLCompiler(shaderCode.SourceCode);
                TokenList<EnumTokenTypeGLSLCompiler> tokenList = lexi.Analyze();
                var uniformVarTokens = new List<Token<EnumTokenTypeGLSLCompiler>>();
                uniformVarTokens.Add(new Token<EnumTokenTypeGLSLCompiler>() { TokenType = EnumTokenTypeGLSLCompiler.identifier, Detail = "uniform", });
                uniformVarTokens.Add(new Token<EnumTokenTypeGLSLCompiler>() { TokenType = EnumTokenTypeGLSLCompiler.identifier, Detail = "", });
                uniformVarTokens.Add(new Token<EnumTokenTypeGLSLCompiler>() { TokenType = EnumTokenTypeGLSLCompiler.identifier, Detail = "", });
                int index = -3;
                while (index < tokenList.Count)
                {
                    index = tokenList.KMP(uniformVarTokens, index + 3, new UniformTokensComparer());
                    if (index >= 0)
                    {
                        UniformVariableBase uniformVar = GetUniformVar(tokenList, index);
                        result.Add(uniformVar);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return result.Distinct().ToArray();
        }

        private UniformVariableBase GetUniformVar(TokenList<EnumTokenTypeGLSLCompiler> tokenList, int index)
        {
            UniformVariableBase uniformVar = null;
            string varType = tokenList[index + 1].Detail;
            if (varType == "float")
            { uniformVar = new UniformFloat(tokenList[index + 2].Detail); }
            else if (varType == "vec2")
            { uniformVar = new UniformVec2(tokenList[index + 2].Detail); }
            else if (varType == "vec3")
            { uniformVar = new UniformVec3(tokenList[index + 2].Detail); }
            else if (varType == "vec4")
            { uniformVar = new UniformVec4(tokenList[index + 2].Detail); }
            else if (varType == "mat2")
            { uniformVar = new UniformMat2(tokenList[index + 2].Detail); }
            else if (varType == "mat3")
            { uniformVar = new UniformMat3(tokenList[index + 2].Detail); }
            else if (varType == "mat4")
            { uniformVar = new UniformMat4(tokenList[index + 2].Detail); }
            else
            { throw new NotImplementedException(); }

            return uniformVar;
        }

        class UniformTokensComparer : IComparer<Token<EnumTokenTypeGLSLCompiler>>
        {

            int IComparer<Token<EnumTokenTypeGLSLCompiler>>.Compare(Token<EnumTokenTypeGLSLCompiler> x, Token<EnumTokenTypeGLSLCompiler> y)
            {
                return (x.TokenType == y.TokenType && x.Detail.Contains(y.Detail)) ? 0 : 1;
            }
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

        protected override void DisposeUnmanagedResources()
        {
            if (this.vertexArrayObject != null)
            {
                this.vertexArrayObject.Dispose();
            }
        }

        public void DecreaseVertexCount()
        {
            {
                IndexBufferRenderer renderer = this.indexBufferRenderer as IndexBufferRenderer;
                if (renderer != null)
                {
                    if (renderer.ElementCount > 0)
                    {
                        renderer.ElementCount--;
                    }
                    return;
                }
            }
            {
                ZeroIndexBufferRenderer renderer = this.indexBufferRenderer as ZeroIndexBufferRenderer;
                if (renderer != null)
                {
                    if (renderer.VertexCount > 0)
                    {
                        renderer.VertexCount--;
                    }
                    return;
                }
            }
        }

        public void IncreaseVertexCount()
        {
            {
                IndexBufferRenderer renderer = this.indexBufferRenderer as IndexBufferRenderer;
                if (renderer != null)
                {
                    if (renderer.ElementCount < this.elementCount)
                    {
                        renderer.ElementCount++;
                    }
                    return;
                }
            }
            {
                ZeroIndexBufferRenderer renderer = this.indexBufferRenderer as ZeroIndexBufferRenderer;
                if (renderer != null)
                {
                    if (renderer.VertexCount < this.elementCount)
                    {
                        renderer.VertexCount++;
                    }
                    return;
                }
            }
        }
    }
}
