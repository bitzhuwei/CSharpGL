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
    /// </summary>
    public class AxisElement3 : SceneElementBase, IMVP, IDisposable
    {
        //AxisPositionBuffer positionBuffer;
        //AxisColorBuffer colorBuffer;
        //AxisIndexBuffer indexBuffer;

        BufferRenderer[] positionBufferRenderers = new BufferRenderer[3];
        BufferRenderer[] colorBufferRenderers = new BufferRenderer[3];
        BufferRenderer[] indexBufferRenderers = new BufferRenderer[3];

        /// <summary>
        /// shader program
        /// </summary>
        private ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_Color = "in_Color";
        const string strMVP = "MVP";

        ///// <summary>
        ///// VAO
        ///// </summary>
        //protected uint[] vao;

        ///// <summary>
        ///// 图元类型
        ///// </summary>
        //protected DrawMode axisPrimitiveMode;

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
        public AxisElement3(float radius = 0.3f, float axisLength = 10, int faceCount = 10)
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
        public AxisElement3(vec3 planColor, float radius = 0.3f, float length = 10, int faceCount = 10)
        {
            this.radius = radius;
            this.axisLength = length;
            this.faceCount = faceCount;

            this.planColor = planColor;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.AxisElement3.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.AxisElement3.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            shaderProgram.AssertValid();
        }

        protected unsafe void InitializeVAO()
        {
            //this.axisPrimitiveMode = DrawMode.QuadStrip;// PrimitiveModes.QuadStrip;

            this.axisVertexCount = faceCount * 2;
            //this.vao = new uint[4];

            //GL.GenVertexArrays(4, vao);

            vec3[] colors = new vec3[] { new vec3(1, 0, 0), new vec3(0, 1, 0), new vec3(0, 0, 1) };
            // 计算三个坐标轴
            for (int axisIndex = 0; axisIndex < 3; axisIndex++)
            {
                //GL.BindVertexArray(vao[axisIndex]);

                //  Create a vertex buffer for the vertex data.
                var positionBuffer = new AxisPositionBuffer(strin_Position, BufferUsage.StaticDraw);
                positionBuffer.Alloc(faceCount * 2);
                vec3* positionArray = (vec3*)positionBuffer.FirstElement();
                {
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
                }
                this.positionBufferRenderers[axisIndex] = positionBuffer.GetRenderer();
                positionBuffer.Dispose();

                //  Now do the same for the colour data.
                var colorBuffer = new AxisColorBuffer(strin_Color, BufferUsage.StaticDraw);
                colorBuffer.Alloc(faceCount * 2);
                vec3* colorArray = (vec3*)colorBuffer.FirstElement();
                {
                    for (int i = 0; i < faceCount * 2; i++)
                    {
                        colorArray[i] = colors[axisIndex];
                    }
                }
                this.colorBufferRenderers[axisIndex] = colorBuffer.GetRenderer();
                colorBuffer.Dispose();

                var indexBuffer = new AxisIndexBuffer();
                int indexLength = faceCount * 2 + 2;
                indexBuffer.Alloc(indexLength);
                byte* cylinderIndex = (byte*)indexBuffer.FirstElement();
                {
                    for (int i = 0; i < indexLength - 2; i++)
                    {
                        cylinderIndex[i] = (byte)i;
                    }
                    cylinderIndex[indexLength - 2] = 0;
                    cylinderIndex[indexLength - 1] = 1;
                }
                this.indexBufferRenderers[axisIndex] = indexBuffer.GetRenderer();
                indexBuffer.Dispose();
            }
            //// 计算XZ平面
            //{
            //    this.planPrimitveMode = DrawMode.LineLoop;
            //    this.planVertexCount = 4;

            //    GL.BindVertexArray(vao[3]);

            //    //  Create a vertex buffer for the vertex data.
            //    using (var plan = new UnmanagedArray<vec3>(4))
            //    {
            //        float length = this.axisLength;
            //        plan[0] = new vec3(-length, 0, -length);
            //        plan[1] = new vec3(-length, 0, length);
            //        plan[2] = new vec3(length, 0, length);
            //        plan[3] = new vec3(length, 0, -length);

            //        uint positionLocation = shaderProgram.GetAttributeLocation(strin_Position);

            //        uint[] ids = new uint[1];
            //        GL.GenBuffers(1, ids);
            //        GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
            //        GL.BufferData(BufferTarget.ArrayBuffer, plan, BufferUsage.StaticDraw);
            //        GL.VertexAttribPointer(positionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            //        GL.EnableVertexAttribArray(positionLocation);
            //    }

            //    //  Now do the same for the colour data.
            //    using (var colorArray = new UnmanagedArray<vec3>(4))
            //    {
            //        for (int i = 0; i < colorArray.Length; i++)
            //        {
            //            colorArray[i] = this.planColor;
            //        }

            //        uint colorLocation = shaderProgram.GetAttributeLocation(strin_Color);

            //        uint[] ids = new uint[1];
            //        GL.GenBuffers(1, ids);
            //        GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
            //        GL.BufferData(BufferTarget.ArrayBuffer, colorArray, BufferUsage.StaticDraw);
            //        GL.VertexAttribPointer(colorLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            //        GL.EnableVertexAttribArray(colorLocation);
            //    }

            //    //  Unbind the vertex array, we've finished specifying data for it.
            //    GL.BindVertexArray(0);
            //}
        }

        protected override void DoInitialize()
        {
            InitializeShader(out shaderProgram);

            InitializeVAO();
        }

        protected override void DoRender(RenderEventArgs e)
        {
            // 画坐标轴
            for (int i = 0; i < 3; i++)
            {
                //GL.BindVertexArray(vao[i]);

                //GL.DrawArrays(primitiveMode, 0, vertexCount);
                //GL.DrawElements(axisPrimitiveMode, faceCount * 2 + 2, GL.GL_UNSIGNED_INT, IntPtr.Zero);
                //GL.DrawElements(axisPrimitiveMode, faceCount * 2 + 2, GL.GL_UNSIGNED_INT, IntPtr.Zero);

                //GL.BindVertexArray(0);

                this.positionBufferRenderers[i].Render(e, this.shaderProgram);
                this.colorBufferRenderers[i].Render(e, this.shaderProgram);
                this.indexBufferRenderers[i].Render(e, this.shaderProgram);
            }

            //// 画平面
            //{
            //GL.BindVertexArray(vao[3]);

            //GL.DrawArrays(this.planPrimitveMode, 0, 4);

            //GL.BindVertexArray(0);
            //}
        }


        #region IDisposable Members

        /// <summary>
        /// Internal variable which checks if Dispose has already been called
        /// </summary>
        protected Boolean disposed;
        private DrawMode planPrimitveMode;
        private int planVertexCount;
        private vec3 planColor;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected void Dispose(Boolean disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //Managed cleanup code here, while managed refs still valid
            }
            //Unmanaged cleanup code here
            foreach (var item in this.positionBufferRenderers)
            {
                item.Dispose();
            }
            foreach (var item in this.colorBufferRenderers)
            {
                item.Dispose();
            }
            foreach (var item in this.indexBufferRenderers)
            {
                item.Dispose();
            }
            //if (vao != null)
            //{
            //    GL.DeleteVertexArrays(vao.Length, vao);
            //    vao = null;
            //}

            disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Call the private Dispose(bool) helper and indicate
            // that we are explicitly disposing
            this.Dispose(true);

            // Tell the garbage collector that the object doesn't require any
            // cleanup when collected since Dispose was called explicitly.
            GC.SuppressFinalize(this);
        }

        #endregion

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
