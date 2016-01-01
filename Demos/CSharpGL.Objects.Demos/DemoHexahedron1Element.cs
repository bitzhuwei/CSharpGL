using GLM;
using CSharpGL.ColorCodedPicking;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Demos
{
    /// <summary>
    /// 用GL.DrawElements()的方式绘制多个六面体。
    /// </summary>
    public class DemoHexahedron1Element : SceneElementBase, IMVP
    {
        const float unitSpace = 6f;
        private static readonly vec3[] unitCubePos;
        private static readonly uint[] unitCubeIndex;
        /// <summary>
        /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/482613/o_Cube-small.jpg
        /// </summary>
        static DemoHexahedron1Element()
        {
            unitCubePos = new vec3[8];
            unitCubePos[0] = new vec3(1, 1, 1);
            unitCubePos[1] = new vec3(-1, 1, 1);
            unitCubePos[2] = new vec3(1, -1, 1);
            unitCubePos[3] = new vec3(-1, -1, 1);
            unitCubePos[4] = new vec3(1, 1, -1);
            unitCubePos[5] = new vec3(-1, 1, -1);
            unitCubePos[6] = new vec3(1, -1, -1);
            unitCubePos[7] = new vec3(-1, -1, -1);

            unitCubeIndex = new uint[14];
            unitCubeIndex[0] = 0;
            unitCubeIndex[1] = 2;
            unitCubeIndex[2] = 4;
            unitCubeIndex[3] = 6;
            unitCubeIndex[4] = 7;
            unitCubeIndex[5] = 2;
            unitCubeIndex[6] = 3;
            unitCubeIndex[7] = 0;
            unitCubeIndex[8] = 1;
            unitCubeIndex[9] = 4;
            unitCubeIndex[10] = 5;
            unitCubeIndex[11] = 7;
            unitCubeIndex[12] = 1;
            unitCubeIndex[13] = 3;
        }


        private ShaderProgram shaderProgram;
        private ShaderProgram currentShaderProgram;
        const string strin_Position = "in_Position";
        const string strin_Color = "in_Color";
        const string strMVP = "MVP";
        private uint[] vao;
        private int size;

        public DemoHexahedron1Element(int size)
        {
            this.size = size;
            this.pickingShaderProgram = PickingShaderHelper.GetPickingShaderProgram();
        }

        protected override void DoInitialize()
        {
            this.shaderProgram = InitializeShader();

            InitVAO();

            this.BeforeRendering += DemoColorCodedPickingElement_BeforeRendering;
            this.BeforeRendering += this.GetIMVPElement_BeforeRendering();
            this.AfterRendering += DemoColorCodedPickingElement_AfterRendering;
            this.AfterRendering += this.GetIMVPElement_AfterRendering();
        }

        void DemoColorCodedPickingElement_AfterRendering(object sender, RenderEventArgs e)
        {
        }

        void DemoColorCodedPickingElement_BeforeRendering(object sender, RenderEventArgs e)
        {
            if (e.RenderMode == RenderModes.HitTest)
            {
                this.currentShaderProgram = this.pickingShaderProgram;

            }
            else
            {
                this.currentShaderProgram = this.shaderProgram;
            }
        }
        uint positionBuffer, colorBuffer, indexBuffer;

        private void InitVAO()
        {
            int size = this.size;

            // prepare positions
            {
                var positionArray = new UnmanagedArray<vec3>(size * size * size * 8);
                int index = 0;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            for (int cubeIndex = 0; cubeIndex < 8; cubeIndex++)
                            {
                                positionArray[index++] = unitCubePos[cubeIndex]
                                    + new vec3((i - size / 2) * unitSpace, (j - size / 2) * unitSpace, (k - size / 2) * unitSpace);
                            }
                        }
                    }
                }

                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                GL.BufferData(BufferTarget.ArrayBuffer, positionArray, BufferUsage.StaticDraw);

                positionArray.Dispose();
                positionBuffer = ids[0];
            }
            // prepare colors
            {
                var colorArray = new UnmanagedArray<vec3>(size * size * size * 8);
                Random random = new Random();
                int index = 0;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            //vec3 color = new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
                            for (int cubeIndex = 0; cubeIndex < 8; cubeIndex++)
                            {
                                vec3 color = new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
                                colorArray[index++] = color;
                            }
                        }
                    }
                }

                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                GL.BufferData(BufferTarget.ArrayBuffer, colorArray, BufferUsage.StaticDraw);

                colorArray.Dispose();
                colorBuffer = ids[0];
            }

            // prepare index
            {
                var indexArray = new UnmanagedArray<uint>(size * size * size * (14 + 1));
                int index = 0;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            for (int cubeIndex = 0; cubeIndex < 14; cubeIndex++)
                            {
                                long posIndex = unitCubeIndex[cubeIndex] + (i * size * size + j * size + k) * 8;
                                indexArray[index++] = (uint)posIndex;
                            }

                            indexArray[index++] = uint.MaxValue;
                        }
                    }
                }

                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, ids[0]);
                GL.BufferData(BufferTarget.ElementArrayBuffer, indexArray, BufferUsage.StaticDraw);

                indexArray.Dispose();
                indexBuffer = ids[0];
            }

            // create vao
            {
                this.vao = new uint[1];
                GL.GenVertexArrays(1, vao);
                GL.BindVertexArray(vao[0]);

                // prepare positions
                {
                    GL.BindBuffer(BufferTarget.ArrayBuffer, positionBuffer);
                    GL.VertexAttribPointer(in_PositionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                    GL.EnableVertexAttribArray(in_PositionLocation);
                }
                // prepare colors
                {
                    GL.BindBuffer(BufferTarget.ArrayBuffer, colorBuffer);
                    GL.VertexAttribPointer(in_ColorLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                    GL.EnableVertexAttribArray(in_ColorLocation);
                }
                // prepare index
                {
                    GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBuffer);
                }

                //  Unbind the vertex array, we've finished specifying data for it.
                GL.BindVertexArray(0);
            }
        }

        protected ShaderProgram InitializeShader()
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"DemoHexahedron1Element.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"DemoHexahedron1Element.frag");

            var shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            this.in_PositionLocation = shaderProgram.GetAttributeLocation(strin_Position);
            this.in_ColorLocation = shaderProgram.GetAttributeLocation(strin_Color);
            this.renderWireframeLocation = shaderProgram.GetUniformLocation("renderWirframe");

            return shaderProgram;
        }

        private int count = 3;
        private ShaderProgram pickingShaderProgram;
        private uint in_PositionLocation;
        private uint in_ColorLocation;
        private int renderWireframeLocation;

        public int Count
        {
            get { return count; }
            set
            {
                int size = this.size;
                int count = size * size * size * 15;
                if (3 <= value && value <= count)
                { this.count = value; }
            }
        }

        protected override void DoRender(RenderEventArgs e)
        {
            GL.Enable(GL.GL_PRIMITIVE_RESTART);
            GL.PrimitiveRestartIndex(uint.MaxValue);

            GL.PolygonMode(PolygonModeFaces.FrontAndBack, PolygonModes.Lines);

            GL.Uniform1(renderWireframeLocation, 1.0f);// shader绘制白色

            // the way with VAO:
            GL.BindVertexArray(vao[0]);
            GL.DrawElements(DrawMode.TriangleStrip, this.count, GL.GL_UNSIGNED_INT, IntPtr.Zero);
            GL.BindVertexArray(0);

            GL.Enable(GL.GL_PRIMITIVE_RESTART);
            GL.PrimitiveRestartIndex(uint.MaxValue);

            GL.PolygonMode(PolygonModeFaces.FrontAndBack, PolygonModes.Filled);

            GL.Uniform1(renderWireframeLocation, 0.0f);// shader绘制color buffer中的颜色

            // the way with VAO:
            GL.BindVertexArray(vao[0]);
            GL.DrawElements(DrawMode.TriangleStrip, this.count, GL.GL_UNSIGNED_INT, IntPtr.Zero);
            GL.BindVertexArray(0);

            // the way without vAO:
            //// prepare positions
            //{
            //    uint in_PositionLocation = shaderProgram.GetAttributeLocation(strin_Position);
            //    GL.BindBuffer(BufferTarget.ArrayBuffer, positionBuffer);
            //    GL.VertexAttribPointer(in_PositionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            //    GL.EnableVertexAttribArray(in_PositionLocation);
            //}
            //// prepare colors
            //{
            //    uint in_ColorLocation = shaderProgram.GetAttributeLocation(strin_Color);
            //    GL.BindBuffer(BufferTarget.ArrayBuffer, colorBuffer);
            //    GL.VertexAttribPointer(in_ColorLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            //    GL.EnableVertexAttribArray(in_ColorLocation);
            //}
            //// prepare index
            //{
            //    GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBuffer);
            //}

            GL.Disable(GL.GL_PRIMITIVE_RESTART);
        }


        void IMVP.SetShaderProgram(mat4 mvp)
        {
            ShaderProgram shaderProgram = this.currentShaderProgram;

            shaderProgram.Bind();
            if (shaderProgram == this.pickingShaderProgram)
            {
                shaderProgram.SetUniform("pickingBaseID", ((IColorCodedPicking)this).PickingBaseID);
                shaderProgram.SetUniformMatrix4(strMVP, mvp.to_array());
            }
            else
            {
                shaderProgram.SetUniformMatrix4(strMVP, mvp.to_array());
            }
        }


        void IMVP.ResetShaderProgram()
        {
            ShaderProgram shaderProgram = this.currentShaderProgram;

            shaderProgram.Unbind();
        }

        ShaderProgram IMVP.GetShaderProgram()
        {
            return this.currentShaderProgram;
        }
    }
}
