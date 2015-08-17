using CSharpGL.Maths;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.SceneElements
{
    /// <summary>
    /// 蛇形管道（井）
    /// </summary>
    public class Well : SceneElementBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param textContent="pipe">管道中心点轨迹</param>
        /// <param textContent="radius">圆柱半径</param>
        /// <param textContent="color">颜色</param>
        /// <param textContent="name">井名</param>
        /// <param textContent="position">文字渲染位置，模型坐标</param>
        public Well(List<vec3> pipe, float radius, GLColor color, String name, vec3 position)
        {
            if (pipe == null || pipe.Count < 2 || radius <= 0.0f)
            { throw new ArgumentException(); }

            this.pipe = pipe; this.radius = radius; this.color = color;
            this.textContent = name; this.textPosition = position;
        }

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
        private List<vec3> pipe;
        private float radius;
        private GLColor color;
        private string textContent;
        private vec3 textPosition;
        const int faceCount = 18;


        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.Well.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.Well.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);
            shaderProgram.AssertValid();
        }

        protected void InitializeVAO(out uint[] vao, out PrimitiveModes primitiveMode, out int vertexCount)
        {
            primitiveMode = PrimitiveModes.QuadStrip;
            vertexCount = (faceCount * 2 + 2) * (this.pipe.Count - 1);

            UnmanagedArray<vec3> positionArray = new UnmanagedArray<vec3>(vertexCount);
            {
                int index = 0;
                for (int i = 1; i < this.pipe.Count; i++)
                {
                    vec3 p1 = this.pipe[i - 1];
                    vec3 p2 = this.pipe[i];
                    vec3 vector = p2 - p1;// 从p1到p2的向量
                    // 找到互相垂直的三个向量：vector, orthogontalVector1和orthogontalVector2
                    vec3 orthogontalVector1 = new vec3(vector.y - vector.z, vector.z - vector.x, vector.x - vector.y);
                    vec3 orthogontalVector2 = vector.VectorProduct(orthogontalVector1);
                    orthogontalVector1.Normalize();
                    orthogontalVector2.Normalize();
                    orthogontalVector1 *= (float)Math.Sqrt(this.radius);
                    orthogontalVector2 *= (float)Math.Sqrt(this.radius);
                    for (int faceIndex = 0; faceIndex < faceCount + 1; faceIndex++)
                    {
                        double angle = (Math.PI * 2 * faceIndex) / faceCount;
                        vec3 point = orthogontalVector1 * (float)Math.Cos(angle) + orthogontalVector2 * (float)Math.Sin(angle);
                        positionArray[index++] = p2 + point;
                        positionArray[index++] = p1 + point;
                    }
                }
            }

            UnmanagedArray<vec3> colorArray = new UnmanagedArray<vec3>(vertexCount);
            {
                for (int i = 0; i < colorArray.Length; i++)
                {
                    //colorArray[i] = this.color;
                    if ((i / (faceCount * 2 + 2)) % 3 == 0)
                    {
                        colorArray[i] = new vec3(1, 0, 0);
                    }
                    else if ((i / (faceCount * 2 + 2)) % 3 == 1)
                    {
                        colorArray[i] = new vec3(0, 1, 0);
                    }
                    else
                    {
                        colorArray[i] = new vec3(0, 0, 1);
                    }
                }
            }

            UnmanagedArray<uint> indexArray = new UnmanagedArray<uint>(vertexCount + (this.pipe.Count - 1));
            {
                uint positionIndex = 0;
                for (int i = 0; i < indexArray.Length; i++)
                {
                    if (i % (faceCount * 2 + 2 + 1) == (faceCount * 2 + 2))
                    {
                        indexArray[i] = uint.MaxValue;//分割各个圆柱体
                    }
                    else
                    {
                        indexArray[i] = positionIndex++;
                    }
                }
            }

            vao = new uint[1];
            GL.GenVertexArrays(1, vao);
            GL.BindVertexArray(vao[0]);
            {
                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(GL.GL_ARRAY_BUFFER, ids[0]);

                int location = GL.GetAttribLocation(shaderProgram.ShaderProgramObject, strin_Position);
                if (location < 0) { throw new Exception(); }
                uint positionLocation = (uint)location;

                GL.BufferData(GL.GL_ARRAY_BUFFER, positionArray.ByteLength, positionArray.Header, GL.GL_STATIC_DRAW);
                GL.VertexAttribPointer(positionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(positionLocation);

                positionArray.Dispose();
            }
            {
                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(GL.GL_ARRAY_BUFFER, ids[0]);

                int location = GL.GetAttribLocation(shaderProgram.ShaderProgramObject, strin_Color);
                if (location < 0) { throw new Exception(); }
                uint colorLocation = (uint)location;

                GL.BufferData(GL.GL_ARRAY_BUFFER, colorArray.ByteLength, colorArray.Header, GL.GL_STATIC_DRAW);
                GL.VertexAttribPointer(colorLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(colorLocation);

                colorArray.Dispose();
            }
            {
                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, ids[0]);
                GL.BufferData(GL.GL_ELEMENT_ARRAY_BUFFER, indexArray.ByteLength, indexArray.Header, GL.GL_STATIC_DRAW);

                indexArray.Dispose();
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

            // 启用Primitive restart
            GL.Enable(GL.GL_PRIMITIVE_RESTART);
            GL.PrimitiveRestartIndex(uint.MaxValue);// 截断图元（四边形带、三角形带等）的索引值。

            GL.DrawElements((uint)primitiveMode, vertexCount + (this.pipe.Count - 1), GL.GL_UNSIGNED_INT, IntPtr.Zero);

            GL.BindVertexArray(0);

            GL.Disable(GL.GL_PRIMITIVE_RESTART);
        }
    }
}
