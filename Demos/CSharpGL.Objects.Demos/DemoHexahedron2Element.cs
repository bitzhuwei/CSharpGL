using GLM;
using CSharpGL.ColorCodedPicking;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL.Objects.Cameras;

namespace CSharpGL.Objects.Demos
{
    /// <summary>
    /// 用GL.MultiDrawArrays()的方式绘制多个六面体。
    /// </summary>
    public class DemoHexahedron2Element : SceneElementBase, IMVP
    {
        const float unitSpace = 6f;
        private static readonly vec3[] unitCubePos;
        /// <summary>
        /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/482613/o_Cube-small.jpg
        /// </summary>
        static DemoHexahedron2Element()
        {
            vec3[] vertexes = new vec3[8];
            vertexes[0] = new vec3(1, 1, 1);
            vertexes[1] = new vec3(-1, 1, 1);
            vertexes[2] = new vec3(1, -1, 1);
            vertexes[3] = new vec3(-1, -1, 1);
            vertexes[4] = new vec3(1, 1, -1);
            vertexes[5] = new vec3(-1, 1, -1);
            vertexes[6] = new vec3(1, -1, -1);
            vertexes[7] = new vec3(-1, -1, -1);

            unitCubePos = new vec3[14];
            unitCubePos[0] = vertexes[0];
            unitCubePos[1] = vertexes[2];
            unitCubePos[2] = vertexes[4];
            unitCubePos[3] = vertexes[6];
            unitCubePos[4] = vertexes[7];
            unitCubePos[5] = vertexes[2];
            unitCubePos[6] = vertexes[3];
            unitCubePos[7] = vertexes[0];
            unitCubePos[8] = vertexes[1];
            unitCubePos[9] = vertexes[4];
            unitCubePos[10] = vertexes[5];
            unitCubePos[11] = vertexes[7];
            unitCubePos[12] = vertexes[1];
            unitCubePos[13] = vertexes[3];

        }

        private ShaderProgram shaderProgram;
        private ShaderProgram currentShaderProgram;
        const string strin_Position = "in_Position";
        const string strin_Color = "in_Color";
        const string strMVP = "MVP";
        private uint[] vao;
        private int[] firsts;
        private int[] counts;
        private int size;

        public DemoHexahedron2Element(int size)
        {
            this.size = size;
            this.pickingShaderProgram = PickingShaderHelper.GetPickingShaderProgram();
        }

        protected override void DoInitialize()
        {
            this.shaderProgram = InitializeShader();

            InitVAO();

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

        private void InitVAO()
        {
            int size = this.size;

            this.vao = new uint[1];

            GL.GenVertexArrays(1, vao);

            GL.BindVertexArray(vao[0]);

            // prepare positions
            {
                var positionArray = new UnmanagedArray<vec3>(size * size * size * 14);
                int index = 0;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            for (int cubeIndex = 0; cubeIndex < 14; cubeIndex++)
                            {
                                positionArray[index++] = unitCubePos[cubeIndex]
                                    + new vec3((i - size / 2) * unitSpace, (j - size / 2) * unitSpace, (k - size / 2) * unitSpace);
                            }
                        }
                    }
                }

                uint in_PositionLocation = shaderProgram.GetAttributeLocation(strin_Position);

                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                GL.BufferData(BufferTarget.ArrayBuffer, positionArray, BufferUsage.StaticDraw);
                GL.VertexAttribPointer(in_PositionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(in_PositionLocation);

                positionArray.Dispose();
            }
            // prepare colors
            {
                var colorArray = new UnmanagedArray<vec3>(size * size * size * 14);
                Random random = new Random();
                int index = 0;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            //vec3 color = new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
                            for (int cubeIndex = 0; cubeIndex < 14; cubeIndex++)
                            {
                                vec3 color = new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
                                colorArray[index++] = color;
                            }
                        }
                    }
                }

                uint in_ColorLocation = shaderProgram.GetAttributeLocation(strin_Color);

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

            // prepare firsts and counts
            {
                // todo: rename 'size'
                this.firsts = new int[size * size * size];
                for (int i = 0; i < this.firsts.Length; i++)
                {
                    this.firsts[i] = i * 14;
                }

                this.counts = new int[size * size * size];
                for (int i = 0; i < this.counts.Length; i++)
                {
                    this.counts[i] = 14;
                }
            }
        }

        protected ShaderProgram InitializeShader()
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"DemoHexahedron2Element.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"DemoHexahedron2Element.frag");

            var shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            return shaderProgram;
        }

        private int primCount = 1;
        private ShaderProgram pickingShaderProgram;

        public int PrimCount
        {
            get { return primCount; }
            set
            {
                int size = this.size;
                int count = size * size * size;
                if (0 <= value && value <= count)
                { this.primCount = value; }
            }
        }

        protected override void DoRender(RenderEventArgs e)
        {
            {
                // 三维场景中所有的元素都应在Camera的照耀下现形，没有Camera就不知道元素该放哪儿。
                // UI元素不在三维场景中，所以其Camera可以是null。
                if (e.Camera == null)
                {
                    throw new ArgumentNullException();
                    //const float distance = 0.7f;
                    //viewMatrix = glm.lookAt(new vec3(-distance, distance, -distance), new vec3(0, 0, 0), new vec3(0, -1, 0));

                    //int[] viewport = new int[4];
                    //GL.GetInteger(GetTarget.Viewport, viewport);
                    //projectionMatrix = glm.perspective(60.0f, (float)viewport[2] / (float)viewport[3], 0.01f, 100.0f);
                }

                mat4 projectionMatrix, viewMatrix, modelMatrix;
                viewMatrix = ((IViewCamera)e.Camera).GetViewMat4();
                projectionMatrix = e.Camera.GetProjectionMat4();
                modelMatrix = mat4.identity();

                mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

                IMVP element = this as IMVP;
                element.SetShaderProgram(projectionMatrix * viewMatrix * modelMatrix);
            }
            DemoColorCodedPickingElement_BeforeRendering(this, e);

            GL.Enable(GL.GL_PRIMITIVE_RESTART);
            GL.PrimitiveRestartIndex(uint.MaxValue);

            GL.BindVertexArray(vao[0]);

            //int size = this.size;
            //int count = size * size * size * 15;
            //GL.DrawElements(PrimitiveModes.TriangleStrip, count, GL.GL_UNSIGNED_INT, IntPtr.Zero);
            //GL.DrawElements(DrawMode.TriangleStrip, this.count, GL.GL_UNSIGNED_INT, IntPtr.Zero);
            GL.MultiDrawArrays(DrawMode.TriangleStrip, this.firsts, this.counts, this.PrimCount);

            GL.BindVertexArray(0);

            GL.Disable(GL.GL_PRIMITIVE_RESTART);

            DemoColorCodedPickingElement_AfterRendering(this, e);
            {
                IMVP element = this as IMVP;
                element.ResetShaderProgram();
            }

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
