namespace CSharpGL.Texts
{
    using CSharpGL;
    using CSharpGL.Objects;
    using CSharpGL.Objects.Models;
    using CSharpGL.Objects.Shaders;
    using CSharpGL.Objects.Textures;
    using CSharpGL.Objects.VertexBuffers;
    using GLM;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    /// <summary>
    /// 一个<see cref=""/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// </summary>
    public class StringRenderer : RendererBase
    {
        ShaderProgram shaderProgram;
        
        #region VAO/VBO renderers
        
        VertexArrayObject vertexArrayObject;
        
        const string strposition = "position";
        BufferRenderer positionBufferRenderer;
        const string strcolor = "color";
        BufferRenderer colorBufferRenderer;
        const string strtexCoord = "texCoord";
        BufferRenderer texCoordBufferRenderer;
        
        IndexBufferRendererBase indexBufferRenderer;
        
        #endregion
        
        #region uniforms
        
        const string strmvp = "mvp";
        public mat4 mvp;
        
        const string strglyphTexture = "glyphTexture";
        public sampler2D glyphTexture;
        
        #endregion
        
        public PolygonModes polygonMode = PolygonModes.Filled;
        
        private int elementCount;

        private StringModel model;
        
        public StringRenderer(StringModel model)
        {
            this.model = model;
        }
        
        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile("String.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile("String.frag");
            
            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);
        }
        
        protected void InitializeVAO()
        {
            this.positionBufferRenderer = model.GetPositionBufferRenderer(strposition);
            this.colorBufferRenderer = model.GetColorBufferRenderer(strcolor);
            //this.texCoordBufferRenderer = ???(strtexCoord);
            this.texCoordBufferRenderer = model.GetTexCoordBufferRenderer(strtexCoord);
            this.indexBufferRenderer = model.GetIndexes() as IndexBufferRendererBase;
            
            {
                IndexBufferRenderer renderer = this.indexBufferRenderer as IndexBufferRenderer;
                if (renderer != null)
                { this.elementCount = renderer.ElementCount; }
            }
            {
                ZeroIndexBufferRenderer renderer = this.indexBufferRenderer as ZeroIndexBufferRenderer;
                if (renderer != null)
                { this.elementCount = renderer.VertexCount; } 
            }
        }
        
        protected override void DoInitialize()
        {
            InitializeShader(out shaderProgram);
        
            InitializeVAO();
        }
        
        protected override void DoRender(RenderEventArgs e)
        {
            ShaderProgram program = this.shaderProgram;
            // 绑定shader
            program.Bind();
            program.SetUniformMatrix4(strmvp, mvp.to_array());
            GL.ActiveTexture(GL.GL_TEXTURE0);
            GL.Enable(GL.GL_TEXTURE_2D);
            this.model.glyphTexture.Bind();
            program.SetUniform(strglyphTexture, 0);//texture1.Name);

            int[] originalPolygonMode = new int[1];
            GL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);
            GL.PolygonMode(PolygonModeFaces.FrontAndBack, this.polygonMode);
            
            GL.Enable(GL.GL_PRIMITIVE_RESTART);
            GL.PrimitiveRestartIndex(uint.MaxValue);
            
            if (this.vertexArrayObject == null)
            {
                var vertexArrayObject = new VertexArrayObject(
                this.indexBufferRenderer,
                this.positionBufferRenderer,
                this.colorBufferRenderer,
                this.texCoordBufferRenderer);
                vertexArrayObject.Create(e, this.shaderProgram);
                
                this.vertexArrayObject = vertexArrayObject;
            }
            else
            {
                this.vertexArrayObject.Render(e, this.shaderProgram);
            }
            
            GL.Disable(GL.GL_PRIMITIVE_RESTART);
            
            GL.PolygonMode(PolygonModeFaces.FrontAndBack, (PolygonModes)(originalPolygonMode[0]));

            this.model.glyphTexture.Unbind();
            // 解绑shader
            program.Unbind();
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
                    if (renderer.ElementCount > 0) { renderer.ElementCount--; }
                    return;
                }
            }
            {
                ZeroIndexBufferRenderer renderer = this.indexBufferRenderer as ZeroIndexBufferRenderer;
                if (renderer != null)
                {
                    if (renderer.VertexCount > 0) { renderer.VertexCount--; }
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
                    if (renderer.ElementCount < this.elementCount) { renderer.ElementCount++; }
                    return;
                }
            }
            {
                ZeroIndexBufferRenderer renderer = this.indexBufferRenderer as ZeroIndexBufferRenderer;
                if (renderer != null)
                {
                    if (renderer.VertexCount < this.elementCount) { renderer.VertexCount++; }
                    return;
                }
            }
        }
    }
}
