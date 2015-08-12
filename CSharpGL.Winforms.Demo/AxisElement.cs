using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Winforms.Demo
{
    /// <summary>
    /// 绘制三维坐标轴
    /// </summary>
    public class AxisElement : SceneElementBase, IDisposable
    {

        /// <summary>
        /// shader program
        /// </summary>
        public ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_Color = "in_Color";
        public const string strprojectionMatrix = "projectionMatrix";
        public const string strviewMatrix = "viewMatrix";
        public const string strmodelMatrix = "modelMatrix";

        /// <summary>
        /// VAO
        /// </summary>
        protected uint[] vao;

        /// <summary>
        /// 图元类型
        /// </summary>
        protected PrimitiveModes primitiveMode;

        /// <summary>
        /// 顶点数
        /// </summary>
        protected int vertexCount;

        private float radius;
        private float height;
        private int faceCount;

        /// <summary>
        /// 绘制三维坐标轴
        /// </summary>
        /// <param name="radius">轴（圆柱）的半径</param>
        /// <param name="height">轴（圆柱）的长度</param>
        /// <param name="faceCount">轴（圆柱）的面数（越多则越圆滑）</param>
        public AxisElement(float radius = 0.1f, float height = 30, int faceCount = 18)
        {
            this.radius = radius;
            this.height = height;
            this.faceCount = faceCount;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"AxisElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"AxisElement.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            shaderProgram.AssertValid();
        }

        protected void InitializeVAO(out uint[] vao, out PrimitiveModes primitiveMode, out int vertexCount)
        {
            primitiveMode = PrimitiveModes.QuadStrip;
            vertexCount = faceCount * 2;

            vao = new uint[3];
            GL.GenVertexArrays(3, vao);
            vec3[] colors = new vec3[] { new vec3(1, 0, 0), new vec3(0, 1, 0), new vec3(0, 0, 1) };
            for (int axisIndex = 0; axisIndex < 3; axisIndex++)
            {
                GL.BindVertexArray(vao[axisIndex]);

                //  Create a vertex buffer for the vertex data.
                {
                    uint[] ids = new uint[1];
                    GL.GenBuffers(1, ids);
                    GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                    UnmanagedArray<vec3> positionArray = new UnmanagedArray<vec3>(faceCount * 2);
                    for (int i = 0; i < faceCount * 2; i++)
                    {
                        int face = i / 2;
                        float[] components = new float[]{
                        (i % 2 == 1 ? 0 : 1) * this.height / 2,
                            (float)(this.radius * Math.Cos(face * (Math.PI * 2) / faceCount)),
                            (float)(this.radius * Math.Sin(face * (Math.PI * 2) / faceCount))};
                        positionArray[i] = new vec3(
                            components[(0 + axisIndex) % 3], components[(2 + axisIndex) % 3], components[(4 + axisIndex) % 3]);
                    }

                    uint positionLocation = shaderProgram.GetAttributeLocation(strin_Position);

                    GL.BufferData(BufferTarget.ArrayBuffer, positionArray, BufferUsage.StaticDraw);
                    GL.VertexAttribPointer(positionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                    GL.EnableVertexAttribArray(positionLocation);
                    positionArray.Dispose();
                }

                //  Now do the same for the colour data.
                {
                    uint[] ids = new uint[1];
                    GL.GenBuffers(1, ids);
                    GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                    UnmanagedArray<vec3> colorArray = new UnmanagedArray<vec3>(faceCount * 2);
                    for (int i = 0; i < colorArray.Length; i++)
                    {
                        //if (i % 2 == 0)
                        {
                            colorArray[i] = colors[axisIndex]; //new vec3(1, 0, 0); //new vec3((i % 3) / 3.0f, (i + 1) % 3 / 3.0f, (i + 2) % 3 / 3.0f);
                        }
                        //else
                        {
                            //colorArray[i] = new vec3(1,1,1); //new vec3((i % 3) / 3.0f, (i + 1) % 3 / 3.0f, (i + 2) % 3 / 3.0f);
                        }
                    }

                    uint colorLocation = shaderProgram.GetAttributeLocation(strin_Color);

                    GL.BufferData(BufferTarget.ArrayBuffer, colorArray, BufferUsage.StaticDraw);
                    GL.VertexAttribPointer(colorLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                    GL.EnableVertexAttribArray(colorLocation);
                    colorArray.Dispose();
                }
                {
                    uint[] ids = new uint[1];
                    GL.GenBuffers(1, ids);
                    GL.BindBuffer(BufferTarget.ElementArrayBuffer, ids[0]);
                    UnmanagedArray<uint> cylinderIndex = new UnmanagedArray<uint>(faceCount * 2 + 2);
                    for (int i = 0; i < cylinderIndex.Length - 2; i++)
                    {
                        cylinderIndex[i] = (uint)i;
                    }
                    cylinderIndex[cylinderIndex.Length - 2] = 0;
                    cylinderIndex[cylinderIndex.Length - 1] = 1;
                    GL.BufferData(BufferTarget.ElementArrayBuffer, cylinderIndex, BufferUsage.StaticDraw);
                    cylinderIndex.Dispose();
                }
                //  Unbind the vertex array, we've finished specifying data for it.
                GL.BindVertexArray(0);
            }
        }

        protected override void DoInitialize()
        {
            InitializeShader(out shaderProgram);

            InitializeVAO(out vao, out primitiveMode, out vertexCount);

        }

        protected override void DoRender(RenderModes renderMode)
        {
            for (int i = 0; i < vao.Length; i++)
            {
                GL.BindVertexArray(vao[i]);

                //GL.DrawArrays(primitiveMode, 0, vertexCount);
                GL.DrawElements(primitiveMode, faceCount * 2 + 2, GL.GL_UNSIGNED_INT, IntPtr.Zero);

                GL.BindVertexArray(0);
            }
        }


        #region IDisposable Members

        /// <summary>
        /// Internal variable which checks if Dispose has already been called
        /// </summary>
        protected Boolean disposed;

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
            if (vao != null)
            {
                GL.DeleteVertexArrays(vao.Length, vao);
                vao = null;
            }

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
    }
}
