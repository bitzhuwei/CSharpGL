using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.SceneElements
{
    /// <summary>
    /// 绘制三维坐标轴2：用三个独立的mat4记录和传递projection * view * model
    /// <para>充当此类库里的示例元素</para>
    /// <para>此类型保留着最原始的调用OpenGL的形式，方便以后温习思考。</para>
    /// </summary>
    public class AxisElement2 : SceneElementBase, IDisposable
    {

        /// <summary>
        /// shader program
        /// </summary>
        public ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_Color = "in_Color";
        const string strprojectionMatrix = "projectionMatrix";
        public mat4 projectionMatrix;
        const string strviewMatrix = "viewMatrix";
        public mat4 viewMatrix;
        const string strmodelMatrix = "modelMatrix";
        public mat4 modelMatrix;

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

        private float radius;
        private float axisLength;
        private int faceCount;

        /// <summary>
        /// 绘制三维坐标轴
        /// </summary>
        /// <param name="radius">轴（圆柱）的半径</param>
        /// <param name="axisLength">轴（圆柱）的长度</param>
        /// <param name="faceCount">轴（圆柱）的面数（越多则越圆滑）</param>
        public AxisElement2(float radius = 0.3f, float axisLength = 10, int faceCount = 10)
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
        public AxisElement2(vec3 planColor, float radius = 0.3f, float length = 10, int faceCount = 10)
        {
            this.radius = radius;
            this.axisLength = length;
            this.faceCount = faceCount;

            this.planColor = planColor;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.AxisElement2.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.AxisElement2.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

        }

        protected void InitializeVAO()
        {
            this.axisPrimitiveMode = DrawMode.QuadStrip; //PrimitiveModes.QuadStrip;
            this.axisVertexCount = faceCount * 2;
            this.vao = new uint[4];

            GL.GenVertexArrays(4, vao);

            vec3[] colors = new vec3[] { new vec3(1, 0, 0), new vec3(0, 1, 0), new vec3(0, 0, 1) };
            // 计算三个坐标轴
            for (int axisIndex = 0; axisIndex < 3; axisIndex++)
            {
                GL.BindVertexArray(vao[axisIndex]);

                //  Create a vertex buffer for the vertex data.
                {
                    UnmanagedArray<vec3> positionArray = new UnmanagedArray<vec3>(faceCount * 2);
                    for (int i = 0; i < faceCount * 2; i++)
                    {
                        int face = i / 2;
                        float[] components = new float[]{
                            i % 2 == 1 ? 0 : this.axisLength,
                            (float)(this.radius * Math.Cos(face * (Math.PI * 2) / faceCount)),
                            (float)(this.radius * Math.Sin(face * (Math.PI * 2) / faceCount))};
                        positionArray[i] = new vec3(
                            components[(0 + axisIndex) % 3], components[(2 + axisIndex) % 3], components[(4 + axisIndex) % 3]);
                    }

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
                    UnmanagedArray<vec3> colorArray = new UnmanagedArray<vec3>(faceCount * 2);
                    for (int i = 0; i < colorArray.Length; i++)
                    {
                        colorArray[i] = colors[axisIndex];
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
                {
                    UnmanagedArray<uint> cylinderIndex = new UnmanagedArray<uint>(faceCount * 2 + 2);
                    for (int i = 0; i < cylinderIndex.Length - 2; i++)
                    {
                        cylinderIndex[i] = (uint)i;
                    }
                    cylinderIndex[cylinderIndex.Length - 2] = 0;
                    cylinderIndex[cylinderIndex.Length - 1] = 1;

                    uint[] ids = new uint[1];
                    GL.GenBuffers(1, ids);
                    GL.BindBuffer(BufferTarget.ElementArrayBuffer, ids[0]);
                    GL.BufferData(BufferTarget.ElementArrayBuffer, cylinderIndex, BufferUsage.StaticDraw);
                    cylinderIndex.Dispose();
                }
                //  Unbind the vertex array, we've finished specifying data for it.
                GL.BindVertexArray(0);
            }
            // 计算XZ平面
            {
                this.planPrimitveMode = DrawMode.LineLoop;
                var lanVertexCount = 4;

                GL.BindVertexArray(vao[3]);

                //  Create a vertex buffer for the vertex data.
                {
                    UnmanagedArray<vec3> plan = new UnmanagedArray<vec3>(lanVertexCount);
                    float length = this.axisLength;
                    plan[0] = new vec3(-length, 0, -length);
                    plan[1] = new vec3(-length, 0, length);
                    plan[2] = new vec3(length, 0, length);
                    plan[3] = new vec3(length, 0, -length);

                    uint positionLocation = shaderProgram.GetAttributeLocation(strin_Position);

                    uint[] ids = new uint[1];
                    GL.GenBuffers(1, ids);
                    GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                    GL.BufferData(BufferTarget.ArrayBuffer, plan, BufferUsage.StaticDraw);
                    GL.VertexAttribPointer(positionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                    GL.EnableVertexAttribArray(positionLocation);

                    plan.Dispose();
                }

                //  Now do the same for the colour data.
                {
                    UnmanagedArray<vec3> colorArray = new UnmanagedArray<vec3>(4);
                    for (int i = 0; i < colorArray.Length; i++)
                    {
                        colorArray[i] = this.planColor;
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
        }

        protected override void DoInitialize()
        {
            InitializeShader(out shaderProgram);

            InitializeVAO();
        }

        protected override void DoRender(RenderEventArgs e)
        {
            shaderProgram.Bind();

            shaderProgram.SetUniformMatrix4(strprojectionMatrix, projectionMatrix.to_array());
            shaderProgram.SetUniformMatrix4(strviewMatrix, viewMatrix.to_array());
            shaderProgram.SetUniformMatrix4(strmodelMatrix, modelMatrix.to_array());

            // 画坐标轴
            for (int i = 0; i < 3; i++)
            {
                GL.BindVertexArray(vao[i]);

                //GL.DrawArrays(primitiveMode, 0, vertexCount);
                GL.DrawElements(axisPrimitiveMode, faceCount * 2 + 2, GL.GL_UNSIGNED_INT, IntPtr.Zero);

                GL.BindVertexArray(0);
            }

            // 画平面
            {
                GL.BindVertexArray(vao[3]);

                GL.DrawArrays(this.planPrimitveMode, 0, 4);

                GL.BindVertexArray(0);
            }

            shaderProgram.Unbind();
        }


        protected override void CleanUnmanagedRes()
        {
            if (vao != null)
            {
                GL.DeleteVertexArrays(vao.Length, vao);
                vao = null;
            }

            base.CleanUnmanagedRes();
        }
        private DrawMode planPrimitveMode;
        private vec3 planColor;

    }
}
