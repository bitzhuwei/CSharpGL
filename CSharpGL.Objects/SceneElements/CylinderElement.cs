using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.SceneElements
{
    /// <summary>
    /// 圆柱体
    /// </summary>
    public class CylinderElement : SceneElementBase
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

        public CylinderElement(float radius, float height, int faceCount = 18)
        {
            this.radius = radius;
            this.height = height;
            this.faceCount = faceCount;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.CylinderElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.CylinderElement.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            shaderProgram.AssertValid();
        }

        protected void InitializeVAO(out uint[] vao, out PrimitiveModes primitiveMode, out int vertexCount)
        {
            primitiveMode = PrimitiveModes.QuadStrip;
            vertexCount = faceCount * 2;

            vao = new uint[1];
            GL.GenVertexArrays(1, vao);
            GL.BindVertexArray(vao[0]);

            //  Create a vertex buffer for the vertex data.
            {
                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                UnmanagedArray<vec3> positionArray = new UnmanagedArray<vec3>(faceCount * 2);
                for (int i = 0; i < faceCount * 2; i++)
                {
                    int face = i / 2;
                    positionArray[i] = new vec3(
                        (float)(this.radius * Math.Cos(face * (Math.PI * 2) / faceCount)),
                        (i % 2 == 1 ? -1 : 1) * this.height / 2,
                        (float)(this.radius * Math.Sin(face * (Math.PI * 2) / faceCount))
                        );
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
                    if (i % 2 == 0)
                    {
                        colorArray[i] = new vec3(1, 0, 0); //new vec3((i % 3) / 3.0f, (i + 1) % 3 / 3.0f, (i + 2) % 3 / 3.0f);
                    }
                    else
                    {
                        colorArray[i] = new vec3(0, 1, 0); //new vec3((i % 3) / 3.0f, (i + 1) % 3 / 3.0f, (i + 2) % 3 / 3.0f);
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

        protected override void DoInitialize()
        {
            InitializeShader(out shaderProgram);

            InitializeVAO(out vao, out primitiveMode, out vertexCount);

        }

        protected override void DoRender(RenderModes renderMode)
        {
            GL.BindVertexArray(vao[0]);

            //GL.DrawArrays(primitiveMode, 0, vertexCount);
            GL.DrawElements(primitiveMode, faceCount * 2 + 2, GL.GL_UNSIGNED_INT, IntPtr.Zero);

            GL.BindVertexArray(0);
        }
    }
}
