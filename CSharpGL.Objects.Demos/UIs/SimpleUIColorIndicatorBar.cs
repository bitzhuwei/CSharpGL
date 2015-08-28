using CSharpGL.Maths;
using CSharpGL.Objects.SceneElements;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.UIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Objects.Demos.UIs
{
    public class SimpleUIColorIndicatorBar : SceneElementBase, IUILayout, IMVP
    {
        /// <summary>
        /// shader program
        /// </summary>
        private ShaderProgram shaderProgram;
        private const string strin_Position = "in_Position";
        private const string strin_Color = "in_Color";
        private const string strMVP = "MVP";

        /// <summary>
        /// VAO
        /// </summary>
        private uint[] vao;
        private PointSpriteStringElement[] numbers;

        /// <summary>
        /// 图元类型
        /// </summary>
        private PrimitiveModes axisPrimitiveMode;

        /// <summary>
        /// 顶点数
        /// </summary>
        private int vertexCount;
        private uint in_ColorLocation;
        private uint in_PositionLocation;

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
        public SimpleUIColorIndicatorBar(IUILayoutParam param, ColorPalette colorPalette, float min, float max, float step)
        {
            IUILayout layout = this;
            layout.Param = param;

            this.ColorPalette = colorPalette;

            this.Min = min;
            this.Max = max;
            this.Step = step;
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
            this.axisPrimitiveMode = PrimitiveModes.QuadStrip;
            GLColor[] colors = this.ColorPalette.Colors;
            float[] coords = this.ColorPalette.Coords;
            this.numbers = new PointSpriteStringElement[coords.Length];
            this.vertexCount = coords.Length * 2;
            this.vao = new uint[1];

            float coordLength = coords[coords.Length - 1] - coords[0];
            {
                GL.GenVertexArrays(1, vao);

                GL.BindVertexArray(vao[0]);

                //  Create a vertex buffer for the vertex data.
                {
                    UnmanagedArray<vec3> positionArray = new UnmanagedArray<vec3>(this.vertexCount);
                    positionArray[0] = new vec3(-0.5f, -0.5f, 0);
                    positionArray[1] = new vec3(-0.5f, 0.5f, 0);
                    for (int i = 1; i < coords.Length; i++)
                    {
                        float x = (coords[i] - coords[0]) / coordLength - 0.5f;
                        positionArray[i * 2 + 0] = new vec3(x, -0.5f, 0);
                        positionArray[i * 2 + 1] = new vec3(x, 0.5f, 0);
                    }

                    uint[] ids = new uint[1];
                    GL.GenBuffers(1, ids);
                    GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                    GL.BufferData(BufferTarget.ArrayBuffer, positionArray, BufferUsage.StaticDraw);
                    GL.VertexAttribPointer(in_PositionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                    GL.EnableVertexAttribArray(in_PositionLocation);

                    positionArray.Dispose();
                }

                //  Now do the same for the colour data.
                {
                    UnmanagedArray<vec3> colorArray = new UnmanagedArray<vec3>(this.vertexCount);
                    for (int i = 0; i < colors.Length; i++)
                    {
                        GLColor color = colors[i];
                        //TODO:试验成功后换vec4试试
                        colorArray[i * 2 + 0] = new vec3(color.R, color.G, color.B);//, color.A);
                        colorArray[i * 2 + 1] = new vec3(color.R, color.G, color.B);//, color.A);
                    }

                    uint[] ids = new uint[1];
                    GL.GenBuffers(1, ids);
                    GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                    GL.BufferData(BufferTarget.ArrayBuffer, colorArray, BufferUsage.StaticDraw);
                    GL.VertexAttribPointer(in_ColorLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                    GL.EnableVertexAttribArray(in_ColorLocation);

                    colorArray.Dispose();
                }

                //  Unbind the vertex array, we've finished specifying data for it.
                GL.BindVertexArray(0);
            }

            // prepare numbers
            {
                const float numberPosY = -0.6f;
                this.numbers[0] = new PointSpriteStringElement(
                    this.Min.ToShortString(), new vec3(-0.5f, numberPosY, 0));
                this.numbers[0].Initialize();
                for (int i = 1; i < coords.Length; i++)
                {
                    float x = (coords[i] - coords[0]) / coordLength - 0.5f;
                    if (i + 1 == coords.Length)
                    {
                        this.numbers[i] = new PointSpriteStringElement(
                            (this.Min + i * this.Step).ToShortString(), new vec3(x, numberPosY, 0));
                    }
                    else
                    {
                        this.numbers[i] = new PointSpriteStringElement(
                            this.Max.ToShortString(), new vec3(x, numberPosY, 0));
                    }
                    this.numbers[i].Initialize();
                }
            }
        }

        protected ShaderProgram InitializeShader()
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"UIs.SimpleUIColorIndicatorBar.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"UIs.SimpleUIColorIndicatorBar.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            in_PositionLocation = shaderProgram.GetAttributeLocation(strin_Position);
            in_ColorLocation = shaderProgram.GetAttributeLocation(strin_Color);

            shaderProgram.AssertValid();

            return shaderProgram;
        }

        protected override void DoRender(RenderEventArgs e)
        {
            // 记录当前多边形状态
            int[] polygonMode = new int[2];
            GL.GetInteger(GetTarget.PolygonMode, polygonMode);

            GL.BindVertexArray(vao[0]);

            // 画面
            GL.PolygonMode(PolygonModeFaces.FrontAndBack, PolygonModes.Filled);
            GL.DrawArrays(this.axisPrimitiveMode, 0, this.vertexCount);

            // 启用静态顶点属性
            GL.DisableVertexAttribArray(in_ColorLocation);
            GL.VertexAttrib3(in_ColorLocation, 1.0f, 1.0f, 1.0f);

            // 画线
            GL.PolygonMode(PolygonModeFaces.FrontAndBack, PolygonModes.Lines);
            GL.DrawArrays(this.axisPrimitiveMode, 0, this.vertexCount);

            // 恢复顶点属性数组
            GL.EnableVertexAttribArray(in_ColorLocation);

            GL.BindVertexArray(0);

            // 恢复多边形状态
            GL.PolygonMode(PolygonModeFaces.Front, (PolygonModes)polygonMode[0]);
            GL.PolygonMode(PolygonModeFaces.Back, (PolygonModes)polygonMode[1]);
        }

        public IUILayoutParam Param { get; set; }

        public ColorPalette ColorPalette { get; set; }

        public float Min { get; set; }

        public float Max { get; set; }

        public float Step { get; set; }

        void IMVP.SetShaderProgram(mat4 mvp)
        {
            IMVPHelper.DoUpdateMVP(this, mvp);
        }


        void IMVP.ResetShaderProgram()
        {
            IMVPHelper.DoUnbindShaderProgram(this);
        }

        ShaderProgram IMVP.GetShaderProgram()
        {
            return this.shaderProgram;
        }
    }
}
