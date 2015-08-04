using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Winforms
{
    /// <summary>
    /// 圆柱体
    /// </summary>
    public class CylinderVAOElement : VAOElement
    {

        /// <summary>
        /// shader program
        /// </summary>
        protected ShaderProgram shaderProgram;
        uint positionLocation;
        uint colorLocation;
        mat4 projectionMatrix;
        mat4 viewMatrix;
        mat4 modelMatrix;

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

        private float rotation;

        private float radius;
        private float height;
        private int faceCount;

        public CylinderVAOElement(float radius, float height, int faceCount = 18)
        {
            this.radius = radius;
            this.height = height;
            this.faceCount = faceCount;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"Cylinder.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"Cylinder.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            int position = shaderProgram.GetAttributeLocation("in_Position");
            if (position >= 0) { positionLocation = (uint)position; }
            else { throw new Exception(); }

            int color = shaderProgram.GetAttributeLocation("in_Color");
            if (color >= 0) { colorLocation = (uint)color; }
            else { throw new Exception(); }

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

        public override void Render(RenderModes renderMode)
        {
            if (!initialized) { Initialize(); }

            BeforeRendering(renderMode);

            GL.BindVertexArray(vao[0]);

            //GL.DrawArrays(primitiveMode, 0, vertexCount);
            GL.DrawElements(primitiveMode, faceCount * 2 + 2, GL.GL_UNSIGNED_INT, IntPtr.Zero);

            GL.BindVertexArray(0);

            AfterRendering(renderMode);
        }
        protected void BeforeRendering(Objects.RenderModes renderMode)
        {
            shaderProgram.Bind();

            rotation += 0.05f;
            modelMatrix = glm.rotate(rotation, new vec3(1, 1, 1));

            const float distance = 1f;
            viewMatrix = glm.lookAt(new vec3(-distance, 0, -distance), new vec3(0, 0, 0), new vec3(0, -1, 0));

            int[] viewport = new int[4];
            GL.GetInteger(GetTarget.Viewport, viewport);
            projectionMatrix = glm.perspective(60.0f, (float)viewport[2] / (float)viewport[3], 0.01f, 100.0f);

            shaderProgram.SetUniformMatrix4("projectionMatrix", projectionMatrix.to_array());
            shaderProgram.SetUniformMatrix4("viewMatrix", viewMatrix.to_array());
            shaderProgram.SetUniformMatrix4("modelMatrix", modelMatrix.to_array());
        }

        protected void AfterRendering(Objects.RenderModes renderMode)
        {
            shaderProgram.Unbind();
        }
    }
}
