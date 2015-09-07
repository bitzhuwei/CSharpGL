using GLM;
using CSharpGL.Objects.Shaders;
using CSharpGL.UIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Objects.Demos.UIs
{
    /// <summary>
    /// Draw a cube on OpenGL control like a <see cref="Windows.Forms.Control"/> drawn on a <see cref="windows.Forms.Form"/>.
    /// Set its properties(Anchor, Margin, Size, etc) to adjust its behaviour.
    /// </summary>
    public class SimpleUICube : SceneElementBase, IUILayout, IMVP//, IRenderable, IHasObjectSpace
    {
        /// <summary>
        /// shader program
        /// </summary>
        public ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_Color = "in_Color";

        /// <summary>
        /// VAO
        /// </summary>
        protected uint[] vao;

        /// <summary>
        /// 图元类型
        /// </summary>
        protected DrawMode axisPrimitiveMode;

        /// <summary>
        /// 顶点数
        /// </summary>
        protected int axisVertexCount;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anchor">the edges of the viewport to which a SimpleUIRect is bound and determines how it is resized with its parent.
        /// <para>something like AnchorStyles.Left | AnchorStyles.Bottom.</para></param>
        /// <param name="margin">the space between viewport and SimpleRect.</param>
        /// <param name="size">Stores width when <see cref="OpenGLUIRect.Anchor"/>.Left &amp; <see cref="OpenGLUIRect.Anchor"/>.Right is <see cref="OpenGLUIRect.Anchor"/>.None.
        /// <para> and height when <see cref="OpenGLUIRect.Anchor"/>.Top &amp; <see cref="OpenGLUIRect.Anchor"/>.Bottom is <see cref="OpenGLUIRect.Anchor"/>.None.</para></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        /// <param name="rectColor">default color is red.</param>
        public SimpleUICube(IUILayoutParam param)
        {
            IUILayout layout = this;
            layout.Param = param;
        }

        protected override void DoInitialize()
        {
            this.shaderProgram = InitializeShader();

            InitVAO();

            this.BeforeRendering += this.GetSimpleUI_BeforeRendering();
            this.AfterRendering += this.GetSimpleUI_AfterRendering();
        }

        private void InitVAO()
        {
            this.axisPrimitiveMode = DrawMode.Lines;
            this.axisVertexCount = 8 * 3;
            this.vao = new uint[1];

            GL.GenVertexArrays(1, vao);

            GL.BindVertexArray(vao[0]);

            //  Create a vertex buffer for the vertex data.
            {
                UnmanagedArray<vec3> positionArray = new UnmanagedArray<vec3>(8 * 3);
                const float halfLength = 0.5f;
                // x axis
                positionArray[0] = new vec3(-halfLength, -halfLength, -halfLength);
                positionArray[1] = new vec3(halfLength, -halfLength, -halfLength);
                positionArray[2] = new vec3(-halfLength, -halfLength, halfLength);
                positionArray[3] = new vec3(halfLength, -halfLength, halfLength);
                positionArray[4] = new vec3(-halfLength, halfLength, halfLength);
                positionArray[5] = new vec3(halfLength, halfLength, halfLength);
                positionArray[6] = new vec3(-halfLength, halfLength, -halfLength);
                positionArray[7] = new vec3(halfLength, halfLength, -halfLength);
                // y axis
                positionArray[8 + 0] = new vec3(-halfLength, -halfLength, -halfLength);
                positionArray[8 + 1] = new vec3(-halfLength, halfLength, -halfLength);
                positionArray[8 + 2] = new vec3(-halfLength, -halfLength, halfLength);
                positionArray[8 + 3] = new vec3(-halfLength, halfLength, halfLength);
                positionArray[8 + 4] = new vec3(halfLength, -halfLength, halfLength);
                positionArray[8 + 5] = new vec3(halfLength, halfLength, halfLength);
                positionArray[8 + 6] = new vec3(halfLength, -halfLength, -halfLength);
                positionArray[8 + 7] = new vec3(halfLength, halfLength, -halfLength);
                // z axis
                positionArray[16 + 0] = new vec3(-halfLength, -halfLength, -halfLength);
                positionArray[16 + 1] = new vec3(-halfLength, -halfLength, halfLength);
                positionArray[16 + 2] = new vec3(-halfLength, halfLength, -halfLength);
                positionArray[16 + 3] = new vec3(-halfLength, halfLength, halfLength);
                positionArray[16 + 4] = new vec3(halfLength, halfLength, -halfLength);
                positionArray[16 + 5] = new vec3(halfLength, halfLength, halfLength);
                positionArray[16 + 6] = new vec3(halfLength, -halfLength, -halfLength);
                positionArray[16 + 7] = new vec3(halfLength, -halfLength, halfLength);

                uint positionLocation = shaderProgram.GetAttributeLocation(strin_Position);

                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                GL.BufferData(BufferTarget.ArrayBuffer, positionArray, BufferUsage.StaticDraw);
                GL.VertexAttribPointer(positionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(positionLocation);

                positionArray.Dispose();
            }

            //  Now do the same for the colour data.
            {
                UnmanagedArray<vec3> colorArray = new UnmanagedArray<vec3>(8 * 3);
                vec3[] colors = new vec3[] { new vec3(1, 0, 0), new vec3(0, 1, 0), new vec3(0, 0, 1), };
                for (int i = 0; i < colorArray.Length; i++)
                {
                    colorArray[i] = colors[i / 8];
                }

                uint colorLocation = shaderProgram.GetAttributeLocation(strin_Color);

                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                GL.BufferData(BufferTarget.ArrayBuffer, colorArray, BufferUsage.StaticDraw);
                GL.VertexAttribPointer(colorLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(colorLocation);

                colorArray.Dispose();
            }

            //  Unbind the vertex array, we've finished specifying data for it.
            GL.BindVertexArray(0);
        }

        protected ShaderProgram InitializeShader()
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"UIs.SimpleUICube.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"UIs.SimpleUICube.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            shaderProgram.AssertValid();

            return shaderProgram;
        }

        protected override void DoRender(RenderEventArgs e)
        {
            GL.BindVertexArray(vao[0]);

            GL.DrawArrays(this.axisPrimitiveMode, 0, this.axisVertexCount);

            GL.BindVertexArray(0);
        }

        public IUILayoutParam Param { get; set; }

        void IMVP.SetShaderProgram(mat4 mvp)
        {
            IMVPHelper.SetMVP(this, mvp);
        }

        void IMVP.ResetShaderProgram()
        {
            IMVPHelper.ResetMVP(this);
        }

        ShaderProgram IMVP.GetShaderProgram()
        {
            return this.shaderProgram;
        }
    }
}
