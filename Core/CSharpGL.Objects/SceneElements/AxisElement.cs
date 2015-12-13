using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL.Objects.VertexBuffers;

namespace CSharpGL.Objects.SceneElements
{
    /// <summary>
    /// 绘制三维坐标轴
    /// <para>充当此类库里的示例元素</para>
    /// <para>此类型使用封装了的VAO和VBO。我认为是可以提高项目工作效率的，是个好的设计。</para>
    /// </summary>
    public class AxisElement : SceneElementBase, IMVP, IDisposable
    {

        VertexArrayObject[] axisVAO;
        BufferRenderer[] positionBufferRenderers = new BufferRenderer[3];
        BufferRenderer[] colorBufferRenderers = new BufferRenderer[3];
        BufferRenderer[] indexBufferRenderers = new BufferRenderer[3];

        VertexArrayObject planVAO;
        BufferRenderer planPositionBufferRenderer;
        BufferRenderer planColorBufferRenderer;
        BufferRenderer planIndexBufferRenderer;

        /// <summary>
        /// shader program
        /// </summary>
        private ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_Color = "in_Color";
        const string strMVP = "MVP";

        private float radius;
        private float axisLength;
        private int faceCount;
        private vec3 planColor;

        /// <summary>
        /// 绘制三维坐标轴
        /// </summary>
        /// <param name="radius">轴（圆柱）的半径</param>
        /// <param name="axisLength">轴（圆柱）的长度</param>
        /// <param name="faceCount">轴（圆柱）的面数（越多则越圆滑）</param>
        public AxisElement(float radius = 0.3f, float axisLength = 10, int faceCount = 10)
        {
            this.radius = radius;
            this.axisLength = axisLength;
            this.faceCount = faceCount;

            this.planColor = new vec3(1, 1, 1);
        }

        /// <summary>
        /// 绘制三维坐标轴
        /// </summary>
        /// <param name="planColor">XZ平面的颜色</param>
        /// <param name="radius">轴（圆柱）的半径</param>
        /// <param name="length">轴（圆柱）的长度</param>
        /// <param name="faceCount">轴（圆柱）的面数（越多则越圆滑）</param>
        public AxisElement(vec3 planColor, float radius = 0.3f, float length = 10, int faceCount = 10)
        {
            this.radius = radius;
            this.axisLength = length;
            this.faceCount = faceCount;

            this.planColor = planColor;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.AxisElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.AxisElement.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            shaderProgram.AssertValid();
        }

        protected unsafe void InitializeVAO()
        {

            vec3[] colors = new vec3[] { new vec3(1, 0, 0), new vec3(0, 1, 0), new vec3(0, 0, 1) };
            // 计算三个坐标轴
            for (int axisIndex = 0; axisIndex < 3; axisIndex++)
            {
                var axisVertexCount = faceCount * 2;

                //  Create a vertex buffer for the vertex data.
                using (var positionBuffer = new AxisPositionBuffer(strin_Position, BufferUsage.StaticDraw))
                {
                    positionBuffer.Alloc(axisVertexCount);
                    vec3* positionArray = (vec3*)positionBuffer.FirstElement();
                    for (int i = 0; i < axisVertexCount; i++)
                    {
                        int face = i / 2;
                        float[] components = new float[]{
                            i % 2 == 1 ? 0 : this.axisLength,
                            (float)(this.radius * Math.Cos(face * (Math.PI * 2) / faceCount)),
                            (float)(this.radius * Math.Sin(face * (Math.PI * 2) / faceCount))};
                        positionArray[i] = new vec3(
                            components[(0 + axisIndex) % 3], components[(2 + axisIndex) % 3], components[(4 + axisIndex) % 3]);
                    }
                    this.positionBufferRenderers[axisIndex] = positionBuffer.GetRenderer();
                }

                //  Now do the same for the color data.
                using (var colorBuffer = new AxisColorBuffer(strin_Color, BufferUsage.StaticDraw))
                {
                    colorBuffer.Alloc(axisVertexCount);
                    vec3* colorArray = (vec3*)colorBuffer.FirstElement();
                    for (int i = 0; i < axisVertexCount; i++)
                    {
                        colorArray[i] = colors[axisIndex];
                    }
                    this.colorBufferRenderers[axisIndex] = colorBuffer.GetRenderer();
                }

                // Now for the index data.
                using (var indexBuffer = new AxisIndexBuffer())
                {
                    int indexLength = axisVertexCount + 2;
                    indexBuffer.Alloc(indexLength);
                    byte* cylinderIndex = (byte*)indexBuffer.FirstElement();
                    for (int i = 0; i < indexLength - 2; i++)
                    {
                        cylinderIndex[i] = (byte)i;
                    }
                    cylinderIndex[indexLength - 2] = 0;
                    cylinderIndex[indexLength - 1] = 1;
                    this.indexBufferRenderers[axisIndex] = indexBuffer.GetRenderer();
                }

            }
            // 计算XZ平面
            {
                int planVertexCount = 4;

                //  Create a vertex buffer for the vertex data.
                using (var positionBuffer = new AxisPositionBuffer(strin_Position, BufferUsage.StaticDraw))
                {
                    positionBuffer.Alloc(planVertexCount);
                    vec3* plan = (vec3*)positionBuffer.FirstElement();
                    {
                        float length = this.axisLength;
                        plan[0] = new vec3(-length, 0, -length);
                        plan[1] = new vec3(-length, 0, length);
                        plan[2] = new vec3(length, 0, length);
                        plan[3] = new vec3(length, 0, -length);
                    }
                    this.planPositionBufferRenderer = positionBuffer.GetRenderer();
                }

                //  Now do the same for the colour data.
                using (var colorBuffer = new AxisColorBuffer(strin_Color, BufferUsage.StaticDraw))
                {
                    colorBuffer.Alloc(planVertexCount);
                    vec3* colorArray = (vec3*)colorBuffer.FirstElement();
                    {
                        for (int i = 0; i < planVertexCount; i++)
                        {
                            colorArray[i] = this.planColor;
                        }
                    }
                    this.planColorBufferRenderer = colorBuffer.GetRenderer();
                }

                using (var indexBuffer = new ZeroIndexBuffer(DrawMode.LineLoop, planVertexCount))
                {
                    indexBuffer.Alloc(planVertexCount);//这句话实际上什么都没有做。
                    this.planIndexBufferRenderer = indexBuffer.GetRenderer();
                }
            }
        }

        protected override void DoInitialize()
        {
            InitializeShader(out shaderProgram);

            InitializeVAO();
        }

        protected override void DoRender(RenderEventArgs e)
        {
            if (this.axisVAO == null)
            {
                this.axisVAO = new VertexArrayObject[3];
                for (int i = 0; i < 3; i++)
                {
                    var vao = new VertexArrayObject(this.positionBufferRenderers[i], this.colorBufferRenderers[i], this.indexBufferRenderers[i]);
                    vao.Create(e, this.shaderProgram);

                    this.axisVAO[i] = vao;
                }

                {
                    var vao = new VertexArrayObject(this.planPositionBufferRenderer, planColorBufferRenderer, this.planIndexBufferRenderer);
                    vao.Create(e, this.shaderProgram);

                    this.planVAO = vao;
                }
            }

            // 画坐标轴
            for (int i = 0; i < 3; i++)
            {
                this.axisVAO[i].Render(e, this.shaderProgram);
            }
            // 画平面
            {
                this.planVAO.Render(e, this.shaderProgram);
            }
        }



        protected override void CleanUnmanagedRes()
        {
            foreach (var item in this.axisVAO)
            {
                item.Dispose();
            }

            this.planVAO.Dispose();

            base.CleanUnmanagedRes();
        }

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
