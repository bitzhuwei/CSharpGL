using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL.Objects.VertexBuffers;

namespace CSharpGL.Objects.Common
{

    //TODO: 如果有兴趣，可以改用1个VBO来存储整个Axis的内容，甚至画一个更好看的Axis。
    /// <summary>
    /// 绘制三维坐标轴
    /// <para>充当此类库里的示例元素</para>
    /// <para>此类型使用封装了的VAO和VBO。我认为是可以提高开发效率的，是个好的设计。</para>
    /// </summary>
    public class AxisElement : RendererBase
    {

        VertexArrayObject[] axisVAO;
        BufferRenderer[] positionBufferRenderers = new BufferRenderer[3];
        BufferRenderer[] colorBufferRenderers = new BufferRenderer[3];
        IndexBufferRendererBase[] indexBufferRenderers = new IndexBufferRendererBase[3];

        VertexArrayObject planVAO;
        BufferRenderer planPositionBufferRenderer;
        BufferRenderer planColorBufferRenderer;
        IndexBufferRendererBase planIndexBufferRenderer;

        /// <summary>
        /// shader program
        /// </summary>
        private ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_Color = "in_Color";
        const string strMVP = "MVP";
        public mat4 mvp;

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

        void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"AxisElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"AxisElement.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

        }

        unsafe void InitializeVAO()
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
                    this.indexBufferRenderers[axisIndex] = indexBuffer.GetRenderer() as IndexBufferRendererBase;
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

                using (var indexBuffer = new ZeroIndexBuffer(DrawMode.LineLoop, 0, planVertexCount))
                {
                    indexBuffer.Alloc(planVertexCount);//这句话实际上什么都没有做。
                    this.planIndexBufferRenderer = indexBuffer.GetRenderer() as IndexBufferRendererBase;
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
            // 绑定shader
            this.shaderProgram.Bind();
            this.shaderProgram.SetUniformMatrix4(strMVP, mvp.to_array());

            if (this.axisVAO == null)
            {
                this.axisVAO = new VertexArrayObject[3];
                for (int i = 0; i < 3; i++)
                {
                    var vao = new VertexArrayObject(
                        this.indexBufferRenderers[i],
                        this.positionBufferRenderers[i], this.colorBufferRenderers[i]);
                    vao.Create(e, this.shaderProgram);

                    this.axisVAO[i] = vao;
                }

                {
                    var vao = new VertexArrayObject(
                        this.planIndexBufferRenderer,
                        this.planPositionBufferRenderer, planColorBufferRenderer);
                    vao.Create(e, this.shaderProgram);

                    this.planVAO = vao;
                }
            }
            else
            {
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

            // 解绑shader
            this.shaderProgram.Unbind();
        }



        protected override void DisposeUnmanagedResources()
        {
            if (this.axisVAO != null)
            {
                foreach (var item in this.axisVAO)
                {
                    item.Dispose();
                }
            }

            if (this.planVAO != null)
            {
                this.planVAO.Dispose();
            }

        }

    }

    class AxisPositionBuffer : PropertyBuffer<vec3>
    {
        public AxisPositionBuffer(string varNameInVertexShader, BufferUsage usage)
            : base(varNameInVertexShader, 3, GL.GL_FLOAT, usage)
        { }

    }

    class AxisColorBuffer : PropertyBuffer<vec3>
    {
        public AxisColorBuffer(string varNameInVertexShader, BufferUsage usage)
            : base(varNameInVertexShader, 3, GL.GL_FLOAT, usage)
        { }

    }

    public class AxisIndexBuffer : IndexBuffer<byte>
    {
        public AxisIndexBuffer()
            : base(DrawMode.QuadStrip, IndexElementType.UnsignedByte, BufferUsage.StaticDraw)
        { }
    }
}
