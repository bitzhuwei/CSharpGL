using CSharpGL.Maths;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CSharpGL.Objects.UI.SimpleUI
{
    /// <summary>
    /// Draw a rectangle on OpenGL control like a <see cref="Windows.Forms.Control"/> drawn on a <see cref="windows.Forms.Form"/>.
    /// Set its properties(Anchor, Margin, Size, etc) to adjust its behaviour.
    /// </summary>
    public class SimpleUIRect : SceneElementBase, IUILayout, IMVP//, IRenderable, IHasObjectSpace
    {
        /// <summary>
        /// shader program
        /// </summary>
        public ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_Color = "in_Color";
        public const string strMVP = "MVP";

        /// <summary>
        /// VAO
        /// </summary>
        protected uint[] vao;

        /// <summary>
        /// 图元类型
        /// </summary>
        protected PrimitiveModes axisPrimitiveMode;

        /// <summary>
        /// 顶点数
        /// </summary>
        protected int axisVertexCount;

        vec3 rectColor;

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
        public SimpleUIRect(IUILayoutParam param, GLColor rectColor = null)
        {
            IUILayout layout = this;
            layout.Param = param;

            if (rectColor == null)
            { this.rectColor = new vec3(0, 0, 1); }
            else
            { this.rectColor = new vec3(rectColor.R, rectColor.G, rectColor.B); }
        }

        protected override void DoInitialize()
        {
            this.shaderProgram = InitializeShader();

            InitVAO();
        }

        private void InitVAO()
        {
            this.axisPrimitiveMode = PrimitiveModes.LineLoop;
            this.axisVertexCount = 4;
            this.vao = new uint[1];

            GL.GenVertexArrays(1, vao);

            GL.BindVertexArray(vao[0]);

            //  Create a vertex buffer for the vertex data.
            {
                UnmanagedArray<vec3> positionArray = new UnmanagedArray<vec3>(4);
                positionArray[0] = new vec3(-0.5f, -0.5f, 0);
                positionArray[1] = new vec3(0.5f, -0.5f, 0);
                positionArray[2] = new vec3(0.5f, 0.5f, 0);
                positionArray[3] = new vec3(-0.5f, 0.5f, 0);

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
                UnmanagedArray<vec3> colorArray = new UnmanagedArray<vec3>(4);
                vec3 color = this.rectColor;
                for (int i = 0; i < colorArray.Length; i++)
                {
                    colorArray[i] = color;
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
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"UI.SimpleUI.SimpleUIRect.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"UI.SimpleUI.SimpleUIRect.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            shaderProgram.AssertValid();

            return shaderProgram;
        }

        protected override void DoRender(RenderModes renderMode)
        {
            GL.BindVertexArray(vao[0]);

            GL.DrawArrays(this.axisPrimitiveMode, 0, this.axisVertexCount);

            GL.BindVertexArray(0);
        }

        public IUILayoutParam Param { get; set; }


        void IMVP.UpdateMVP(mat4 mvp)
        {
            ShaderProgram shaderProgram = this.shaderProgram;

            shaderProgram.Bind();

            shaderProgram.SetUniformMatrix4(strMVP, mvp.to_array());
        }


        void IMVP.UnbindShaderProgram()
        {
            ShaderProgram shaderProgram = this.shaderProgram;

            shaderProgram.Unbind();
        }
    }
}
