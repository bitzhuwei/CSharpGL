using GlmNet;
using SharpGL;
using SharpGL.SceneComponent;
using SharpGL.SceneGraph.Core;
using SharpGL.Shaders;
using SimLab.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLab
{
    public class PointGrid : SimLabGrid, IRenderable
    {
        private const string in_Position = "in_Position";
        private const string in_uv = "in_uv";
        private const string in_radius = "in_radius";

        uint ATTRIB_INDEX_POSITION = 0;
        uint ATTRIB_INDEX_UV = 1;
        uint ATTRIB_INDEX_RADIUS = 2;

        private uint[] radiusBuffer;
        uint[] vertexArrayObject;
        private int count;

        private GlmNet.mat4 projectionMatrix;
        private GlmNet.mat4 viewMatrix;
        private mat4 modelMatrix;
        private ShaderProgram shaderProgram;

        public PointGrid(OpenGL gl, IScientificCamera camera)
            : base(gl, camera)
        { }

        public void Init(PointMeshGeometry3D geometry)
        {
            base.Init(geometry);

            this.radiusBuffer = new uint[1];
            this.radiusBuffer[0] = CreateVertexBufferObject(OpenGL.GL_ARRAY_BUFFER, geometry.Radius, OpenGL.GL_STREAM_DRAW);
            this.count = geometry.Count;
        }

        public void SetRadius(PointRadiusBuffer radius)
        {
            if (radius != null)
            {
                if (this.radiusBuffer != null)
                {
                    gl.DeleteBuffers(this.radiusBuffer.Length, this.radiusBuffer);
                }
                ////TODO:如果用此方式，则必须先将此对象加入scene树，然后再调用Init
                //OpenGL gl = this.TraverseToRootElement().ParentScene.OpenGL;
                this.radiusBuffer = new uint[1];
                this.radiusBuffer[0] = CreateVertexBufferObject(OpenGL.GL_ARRAY_BUFFER, radius, OpenGL.GL_STATIC_DRAW);

                if (this.vertexArrayObject != null)
                {
                    gl.DeleteVertexArrays(this.vertexArrayObject.Length, this.vertexArrayObject);
                    this.vertexArrayObject = null;
                }
            }
            else
            {
                if (this.radiusBuffer != null)
                {
                    gl.DeleteBuffers(this.radiusBuffer.Length, this.radiusBuffer);
                }
            }
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

            modelMatrix = glm.scale(mat4.identity(), new vec3(1, 1, this.ZAxisScale));

            gl.Enable(OpenGL.GL_VERTEX_PROGRAM_POINT_SIZE);
            gl.Enable(OpenGL.GL_POINT_SPRITE_ARB);
            gl.TexEnv(OpenGL.GL_POINT_SPRITE_ARB, OpenGL.GL_COORD_REPLACE_ARB, OpenGL.GL_TRUE);
            gl.Enable(OpenGL.GL_POINT_SMOOTH);
            gl.Hint(OpenGL.GL_POINT_SMOOTH_HINT, OpenGL.GL_NICEST);
            gl.Enable(OpenGL.GL_BLEND);
            gl.BlendEquation(OpenGL.GL_FUNC_ADD_EXT);
            gl.BlendFuncSeparate(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA, OpenGL.GL_ONE, OpenGL.GL_ONE);

            ShaderProgram shaderProgram = this.shaderProgram;
            int[] viewport = new int[4];
            gl.GetInteger(OpenGL.GL_VIEWPORT, viewport);

            shaderProgram.Bind(gl);
            shaderProgram.SetUniformMatrix4(gl, "projectionMatrix", projectionMatrix.to_array());
            shaderProgram.SetUniformMatrix4(gl, "viewMatrix", viewMatrix.to_array());
            shaderProgram.SetUniformMatrix4(gl, "modelMatrix", modelMatrix.to_array());
            shaderProgram.SetUniform1(gl, "canvasWidth", viewport[2] + 0.0f);
            shaderProgram.SetUniform1(gl, "canvasHeight", viewport[3] + 0.0f);
            shaderProgram.SetUniform1(gl, "opacity", this.Opacity);

            this.texture.Bind(gl);
            shaderProgram.SetUniform1(gl, "tex", this.texture.TextureName);
            shaderProgram.SetUniform1(gl, "brightness", this.Brightness);

        }

        #region IRenderable 成员

        void IRenderable.Render(OpenGL gl, RenderMode renderMode)
        {
            if (positionBuffer != null && colorBuffer != null && radiusBuffer != null)
            {
                if (this.shaderProgram == null)
                {
                    this.shaderProgram = InitShader(gl, renderMode);
                }
                if (this.vertexArrayObject == null)
                {
                    CreateVertexArrayObject(gl, renderMode);
                }

                BeforeRendering(gl, renderMode);

                if (this.RenderGrid && this.vertexArrayObject != null)
                {
                    gl.Enable(OpenGL.GL_BLEND);
                    gl.BlendFunc(SharpGL.Enumerations.BlendingSourceFactor.SourceAlpha, SharpGL.Enumerations.BlendingDestinationFactor.OneMinusSourceAlpha);

                    gl.BindVertexArray(this.vertexArrayObject[0]);
                    gl.DrawArrays(OpenGL.GL_POINTS, 0, count);
                    gl.BindVertexArray(0);

                    gl.Disable(OpenGL.GL_BLEND);
                }

                AfterRendering(gl, renderMode);
            }
        }


        private void CreateVertexArrayObject(OpenGL gl, RenderMode renderMode)
        {
            if (this.positionBuffer == null || this.colorBuffer == null || this.radiusBuffer == null) { return; }

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
            // prepare radius
            {
                int location = shaderProgram.GetAttributeLocation(gl, in_radius);
                ATTRIB_INDEX_RADIUS = (uint)location;
                gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, radiusBuffer[0]);
                gl.VertexAttribPointer(ATTRIB_INDEX_RADIUS, 1, OpenGL.GL_FLOAT, false, 0, IntPtr.Zero);
                gl.EnableVertexAttribArray(ATTRIB_INDEX_RADIUS);
            }

            gl.BindVertexArray(0);
        }

        private ShaderProgram InitShader(OpenGL gl, RenderMode renderMode)
        {
            String vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"Grids.PointGrid.vert");
            String fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"Grids.PointGrid.frag");

            var shaderProgram = new ShaderProgram();
            shaderProgram.Create(gl, vertexShaderSource, fragmentShaderSource, null);

            {
                int location = shaderProgram.GetAttributeLocation(gl, in_Position);
                if (location < 0) { throw new ArgumentException(); }
                this.ATTRIB_INDEX_POSITION = (uint)location;
            }
            {
                int location = shaderProgram.GetAttributeLocation(gl, in_uv);
                if (location < 0) { throw new ArgumentException(); }
                this.ATTRIB_INDEX_POSITION = (uint)location;
            }
            {
                int location = shaderProgram.GetAttributeLocation(gl, in_radius);
                if (location < 0) { throw new ArgumentException(); }
                this.ATTRIB_INDEX_POSITION = (uint)location;
            }

            shaderProgram.AssertValid(gl);

            return shaderProgram;
        }

        #endregion

        protected void AfterRendering(OpenGL gl, RenderMode renderMode)
        {
            shaderProgram.Unbind(gl);
            gl.Disable(OpenGL.GL_BLEND);
            gl.Disable(OpenGL.GL_VERTEX_PROGRAM_POINT_SIZE);
            gl.Disable(OpenGL.GL_POINT_SPRITE_ARB);
            gl.Disable(OpenGL.GL_POINT_SMOOTH);
            gl.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
        }

        #endregion IRenderable

        protected override void DisposeUnmanagedResources()
        {
            try
            {
                base.DisposeUnmanagedResources();

                if (this.radiusBuffer != null)
                {
                    gl.DeleteBuffers(this.radiusBuffer.Length, this.radiusBuffer);
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
