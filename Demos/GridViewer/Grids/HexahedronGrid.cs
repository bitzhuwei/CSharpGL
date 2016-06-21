using GlmNet;
using SharpGL;
using SharpGL.Enumerations;
using SharpGL.SceneComponent;
using SharpGL.SceneGraph.Core;
using SharpGL.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLab
{
    public class HexahedronGrid : SimLabGrid, IRenderable
    {
        private const string in_Position = "in_Position";
        private const string in_uv = "in_uv";
        uint ATTRIB_INDEX_POSITION = 0;
        uint ATTRIB_INDEX_UV = 1;

        protected uint[] indexBuffer;
        protected int indexBufferLength;

        uint[] vertexArrayObject;

        private GlmNet.mat4 projectionMatrix;
        private GlmNet.mat4 viewMatrix;
        private mat4 modelMatrix;
        private ShaderProgram shaderProgram;


        public HexahedronGrid(OpenGL gl, IScientificCamera camera)
            : base(gl, camera)
        { }

        public void Init(HexahedronMeshGeometry3D geometry)
        {
            base.Init(geometry);

            indexBuffer = new uint[1];
            indexBuffer[0] = CreateVertexBufferObject(OpenGL.GL_ELEMENT_ARRAY_BUFFER, geometry.HalfHexahedronIndices, OpenGL.GL_STATIC_DRAW);

            int elementLength = sizeof(uint);// should be 4.
            this.indexBufferLength = geometry.HalfHexahedronIndices.SizeInBytes / (elementLength);
        }

        #region IRenderable

        protected void BeforeRendering(OpenGL gl, RenderMode renderMode)
        {
            IScientificCamera camera = this.camera;
            if (camera != null)
            {
                if (camera.CameraType == CameraTypes.Perspecitive)
                {
                    IPerspectiveViewCamera perspective = camera;
                    this.projectionMatrix = perspective.GetProjectionMat4();
                    this.viewMatrix = perspective.GetViewMat4();
                }
                else if (camera.CameraType == CameraTypes.Ortho)
                {
                    IOrthoViewCamera ortho = camera;
                    this.projectionMatrix = ortho.GetProjectionMat4();
                    this.viewMatrix = ortho.GetViewMat4();
                }
                else
                { throw new NotImplementedException(); }
            }

            gl.Enable(OpenGL.GL_TEXTURE_2D);
            this.texture.Bind(gl);

            modelMatrix = glm.scale(mat4.identity(), new vec3(1, 1, this.ZAxisScale));
            ShaderProgram shaderProgram = this.shaderProgram;
            //  Bind the shader, set the matrices.
            shaderProgram.Bind(gl);
            shaderProgram.SetUniformMatrix4(gl, "projectionMatrix", projectionMatrix.to_array());
            shaderProgram.SetUniformMatrix4(gl, "viewMatrix", viewMatrix.to_array());
            shaderProgram.SetUniformMatrix4(gl, "modelMatrix", modelMatrix.to_array());

            shaderProgram.SetUniform1(gl, "tex", this.texture.TextureName);
            shaderProgram.SetUniform1(gl, "brightness", this.Brightness);
            shaderProgram.SetUniform1(gl, "opacity", this.Opacity);

            gl.Enable(OpenGL.GL_POLYGON_SMOOTH);
            gl.Hint(OpenGL.GL_POLYGON_SMOOTH_HINT, OpenGL.GL_NICEST);
        }

        #region IRenderable 成员

        void IRenderable.Render(OpenGL gl, RenderMode renderMode)
        {
            if (positionBuffer == null || colorBuffer == null) { return; }

            if (this.shaderProgram == null)
            {
                this.shaderProgram = InitShader(gl, renderMode);
            }
            if (this.vertexArrayObject == null)
            {
                CreateVertexArrayObject(gl, renderMode);
            }

            BeforeRendering(gl, renderMode);

            if (this.RenderGridWireframe && this.vertexArrayObject != null)
            {
                //if (wireframeIndexBuffer != null)
                if (positionBuffer != null && colorBuffer != null && indexBuffer != null)
                {
                    shaderProgram.SetUniform1(gl, "renderingWireframe", 1.0f);// shader一律上白色。

                    gl.Disable(OpenGL.GL_LINE_STIPPLE);
                    gl.Disable(OpenGL.GL_POLYGON_STIPPLE);
                    gl.Enable(OpenGL.GL_LINE_SMOOTH);
                    gl.Enable(OpenGL.GL_POLYGON_SMOOTH);
                    gl.ShadeModel(SharpGL.Enumerations.ShadeModel.Smooth);
                    gl.Hint(SharpGL.Enumerations.HintTarget.LineSmooth, SharpGL.Enumerations.HintMode.Nicest);
                    gl.Hint(SharpGL.Enumerations.HintTarget.PolygonSmooth, SharpGL.Enumerations.HintMode.Nicest);
                    gl.PolygonMode(SharpGL.Enumerations.FaceMode.FrontAndBack, SharpGL.Enumerations.PolygonMode.Lines);

                    gl.Enable(OpenGL.GL_PRIMITIVE_RESTART);
                    gl.PrimitiveRestartIndex(uint.MaxValue);

                    gl.Enable(OpenGL.GL_BLEND);
                    gl.BlendFunc(SharpGL.Enumerations.BlendingSourceFactor.SourceAlpha, SharpGL.Enumerations.BlendingDestinationFactor.OneMinusSourceAlpha);

                    gl.BindVertexArray(this.vertexArrayObject[0]);
                    gl.BindBuffer(OpenGL.GL_ELEMENT_ARRAY_BUFFER, indexBuffer[0]);
                    gl.DrawElements(OpenGL.GL_QUAD_STRIP, this.indexBufferLength, OpenGL.GL_UNSIGNED_INT, IntPtr.Zero);
                    gl.BindVertexArray(0);

                    gl.Disable(OpenGL.GL_BLEND);

                    gl.Disable(OpenGL.GL_PRIMITIVE_RESTART);

                    gl.PolygonMode(SharpGL.Enumerations.FaceMode.FrontAndBack, SharpGL.Enumerations.PolygonMode.Filled);
                    gl.Disable(OpenGL.GL_POLYGON_SMOOTH);
                }
            }


            if (this.RenderGrid && this.vertexArrayObject != null)
            {
                if (positionBuffer != null && colorBuffer != null && indexBuffer != null)
                {
                    shaderProgram.SetUniform1(gl, "renderingWireframe", 0.0f);// shader根据uv buffer来上色。

                    gl.Enable(OpenGL.GL_PRIMITIVE_RESTART);
                    gl.PrimitiveRestartIndex(uint.MaxValue);

                    gl.Enable(OpenGL.GL_BLEND);
                    gl.BlendFunc(SharpGL.Enumerations.BlendingSourceFactor.SourceAlpha, SharpGL.Enumerations.BlendingDestinationFactor.OneMinusSourceAlpha);

                    gl.BindVertexArray(this.vertexArrayObject[0]);
                    gl.BindBuffer(OpenGL.GL_ELEMENT_ARRAY_BUFFER, indexBuffer[0]);
                    gl.DrawElements(OpenGL.GL_QUAD_STRIP, this.indexBufferLength, OpenGL.GL_UNSIGNED_INT, IntPtr.Zero);
                    gl.BindVertexArray(0);

                    gl.Disable(OpenGL.GL_BLEND);

                    gl.Disable(OpenGL.GL_PRIMITIVE_RESTART);
                }
            }

            AfterRendering(gl, renderMode);
        }


        private void CreateVertexArrayObject(OpenGL gl, RenderMode renderMode)
        {
            if (this.positionBuffer == null || this.colorBuffer == null) { return; }

            this.vertexArrayObject = new uint[1];
            gl.GenVertexArrays(1, this.vertexArrayObject);
            gl.BindVertexArray(this.vertexArrayObject[0]);

            // prepare positions
            {
                int location = shaderProgram.GetAttributeLocation(gl, in_Position);
                ATTRIB_INDEX_POSITION = (uint)location;
                gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, positionBuffer[0]);
                gl.VertexAttribPointer(ATTRIB_INDEX_POSITION, 3, OpenGL.GL_FLOAT, false, 0, IntPtr.Zero);
                gl.EnableVertexAttribArray(ATTRIB_INDEX_POSITION);
            }
            // prepare colors
            {
                int location = shaderProgram.GetAttributeLocation(gl, in_uv);
                ATTRIB_INDEX_UV = (uint)location;
                gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, colorBuffer[0]);
                gl.VertexAttribPointer(ATTRIB_INDEX_UV, 1, OpenGL.GL_FLOAT, false, 0, IntPtr.Zero);
                gl.EnableVertexAttribArray(ATTRIB_INDEX_UV);
            }

            gl.BindVertexArray(0);
        }

        private ShaderProgram InitShader(OpenGL gl, RenderMode renderMode)
        {
            String vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"Grids.HexahedronGrid.vert");
            String fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"Grids.HexahedronGrid.frag");
            ShaderProgram shaderProgram = new ShaderProgram();
            shaderProgram.Create(gl, vertexShaderSource, fragmentShaderSource, null);
            //shaderProgram.BindAttributeLocation(gl, ATTRIB_INDEX_POSITION, in_position);
            //shaderProgram.BindAttributeLocation(gl, ATTRIB_INDEX_COLOUR, in_uv);
            {
                int location = shaderProgram.GetAttributeLocation(gl, in_Position);
                if (location < 0) { throw new ArgumentException(); }
                this.ATTRIB_INDEX_POSITION = (uint)location;
            }
            {
                int location = shaderProgram.GetAttributeLocation(gl, in_uv);
                if (location < 0) { throw new ArgumentException(); }
                this.ATTRIB_INDEX_UV = (uint)location;
            }
            shaderProgram.AssertValid(gl);
            return shaderProgram;
        }

        #endregion

        protected void AfterRendering(OpenGL gl, RenderMode renderMode)
        {
            gl.Disable(OpenGL.GL_POLYGON_SMOOTH);

            shaderProgram.Unbind(gl);

            gl.BindTexture(OpenGL.GL_TEXTURE_2D, 0);

            gl.Disable(OpenGL.GL_TEXTURE_2D);
        }

        #endregion IRenderable

        protected override void DisposeUnmanagedResources()
        {
            base.DisposeUnmanagedResources();

            try
            {
                if (this.indexBuffer != null)
                {
                    gl.DeleteBuffers(this.indexBuffer.Length, this.indexBuffer);
                }

                if (this.vertexArrayObject != null)
                {
                    gl.DeleteVertexArrays(this.vertexArrayObject.Length, this.vertexArrayObject);
                }
            }
            catch (Exception)
            {
            }

        }
    }
}
