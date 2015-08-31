using CSharpGL;
using CSharpGL.Maths;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharpGL
{
    class PyramidDemo
    {
        private ShaderProgram shaderProgram;
        const int vertexCount = 12;
        private uint[] vertexArrayObject;

        public void Initilize()
        {
            InitShaderProgram();

            InitVAO();
        }

        private void InitVAO()
        {
            // reserve a vertex array object(VAO) 预约一个VAO
            this.vertexArrayObject = new uint[1];
            GL.GenVertexArrays(1, this.vertexArrayObject);

            // prepare vertex buffer object(VBO) for vertexes' positions 为顶点位置准备VBO
            uint[] positionBufferObject = new uint[1];
            {
                // specify position array
                var positionArray = new UnmanagedArray<vec3>(vertexCount);
                positionArray[0] = new vec3(0.0f, 1.0f, 0.0f);
                positionArray[1] = new vec3(-1.0f, -1.0f, 1.0f);
                positionArray[2] = new vec3(1.0f, -1.0f, 1.0f);
                positionArray[3] = new vec3(0.0f, 1.0f, 0.0f);
                positionArray[4] = new vec3(1.0f, -1.0f, 1.0f);
                positionArray[5] = new vec3(1.0f, -1.0f, -1.0f);
                positionArray[6] = new vec3(0.0f, 1.0f, 0.0f);
                positionArray[7] = new vec3(1.0f, -1.0f, -1.0f);
                positionArray[8] = new vec3(-1.0f, -1.0f, -1.0f);
                positionArray[9] = new vec3(0.0f, 1.0f, 0.0f);
                positionArray[10] = new vec3(-1.0f, -1.0f, -1.0f);
                positionArray[11] = new vec3(-1.0f, -1.0f, 1.0f);

                // put positions into VBO
                GL.GenBuffers(1, positionBufferObject);
                GL.BindBuffer(BufferTarget.ArrayBuffer, positionBufferObject[0]);
                GL.BufferData(BufferTarget.ArrayBuffer, positionArray, BufferUsage.StaticDraw);

                positionArray.Dispose();
            }

            // prepare vertex buffer object(VBO) for vertexes' colors
            uint[] colorBufferObject = new uint[1];
            {
                // specify color array
                UnmanagedArray<vec3> colorArray = new UnmanagedArray<vec3>(vertexCount);
                colorArray[0] = new vec3(1.0f, 0.0f, 0.0f);
                colorArray[1] = new vec3(0.0f, 1.0f, 0.0f);
                colorArray[2] = new vec3(0.0f, 0.0f, 1.0f);
                colorArray[3] = new vec3(1.0f, 0.0f, 0.0f);
                colorArray[4] = new vec3(0.0f, 0.0f, 1.0f);
                colorArray[5] = new vec3(0.0f, 1.0f, 0.0f);
                colorArray[6] = new vec3(1.0f, 0.0f, 0.0f);
                colorArray[7] = new vec3(0.0f, 1.0f, 0.0f);
                colorArray[8] = new vec3(0.0f, 0.0f, 1.0f);
                colorArray[9] = new vec3(1.0f, 0.0f, 0.0f);
                colorArray[10] = new vec3(0.0f, 0.0f, 1.0f);
                colorArray[11] = new vec3(0.0f, 1.0f, 0.0f);

                // put colors into VBO
                GL.GenBuffers(1, colorBufferObject);
                GL.BindBuffer(BufferTarget.ArrayBuffer, colorBufferObject[0]);
                GL.BufferData(BufferTarget.ArrayBuffer, colorArray, BufferUsage.StaticDraw);

                colorArray.Dispose();
            }

            uint positionLocation = shaderProgram.GetAttributeLocation("in_Position");
            uint colorLocation = shaderProgram.GetAttributeLocation("in_Color");

            {
                // bind the vertex array object(VAO), we are going to specify data for it.
                GL.BindVertexArray(vertexArrayObject[0]);

                // specify vertexes' positions
                GL.BindBuffer(BufferTarget.ArrayBuffer, positionBufferObject[0]);
                GL.VertexAttribPointer(positionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(positionLocation);

                // specify vertexes' colors
                GL.BindBuffer(BufferTarget.ArrayBuffer, colorBufferObject[0]);
                GL.VertexAttribPointer(colorLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(colorLocation);

                //  Unbind the vertex array object(VAO), we've finished specifying data for it.
                GL.BindVertexArray(0);
            }
        }

        private void InitShaderProgram()
        {
            var vertexShaderSource = File.ReadAllText(@"PyramidDemo.vert");
            var fragmentShaderSource = File.ReadAllText(@"PyramidDemo.frag");

            this.shaderProgram = new ShaderProgram();

            this.shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);
            this.shaderProgram.AssertValid();

            //this.MVPLocation = this.shaderProgram.GetUniformLocation("MVP");
        }

        public void Render()
        {
            mat4 mvp;
            {
                // model rotates
                mat4 modelMatrix = glm.rotate(rotation, new vec3(0, 1, 0));

                // same as gluLookAt()
                mat4 viewMatrix = glm.lookAt(new vec3(-5, 5, -5), new vec3(0, 0, 0), new vec3(0, 1, 0));

                // same as gluPerspective()
                int[] viewport = new int[4];
                GL.GetInteger(GetTarget.Viewport, viewport);
                float width = viewport[2];
                float height = viewport[3];
                mat4 projectionMatrix = glm.perspective((float)(60.0f * Math.PI / 180.0f), width / height, 0.01f, 100.0f);

                // get MVP in "uniform mat4 MVP;" in the vertex shader
                mvp = projectionMatrix * viewMatrix * modelMatrix;
            }

            // bind the shader program to setup uniforms
            this.shaderProgram.Bind();
            // setup MVP
            this.shaderProgram.SetUniformMatrix4("MVP", mvp.to_array());
            {
                // bind vertex array object(VAO)
                GL.BindVertexArray(this.vertexArrayObject[0]);
                // draw the model: in GL_TRIANGLES mode, there are 'vertexCount' vertexes
                GL.DrawArrays(GL.GL_TRIANGLES, 0, vertexCount);
                // unbind vertex array object(VAO)
                GL.BindVertexArray(0);
            }
            // unbind the shader program
            this.shaderProgram.Unbind();

            rotation += 3.0f;
        }

        private float rotation;
    }
}
