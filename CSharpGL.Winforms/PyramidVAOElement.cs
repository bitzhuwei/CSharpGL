using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.GLSLShader;
using CSharpGL.Objects.VertexArrayObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Winforms
{
    public class PyramidVAOElement : VAOElement
    {
        mat4 projectionMatrix;
        mat4 viewMatrix;
        mat4 modelMatrix;

        uint positionLocation;

        uint colorLocation;

        static vec3[] positions = new vec3[]
		{
			new vec3(0.0f, 1.0f, 0.0f),
			new vec3(-1.0f, -1.0f, 1.0f),
			new vec3(1.0f, -1.0f, 1.0f),
			new vec3(0.0f, 1.0f, 0.0f),
			new vec3(1.0f, -1.0f, 1.0f),
			new vec3(1.0f, -1.0f, -1.0f),
			new vec3(0.0f, 1.0f, 0.0f),
			new vec3(1.0f, -1.0f, -1.0f),
			new vec3(-1.0f, -1.0f, -1.0f),
			new vec3(0.0f, 1.0f, 0.0f),
			new vec3(-1.0f, -1.0f, -1.0f),
			new vec3(-1.0f, -1.0f, 1.0f),   
		};
        static vec3[] colors = new vec3[]
		{ 
			new vec3(1.0f, 0.0f, 0.0f),
			new vec3(0.0f, 1.0f, 0.0f),          
			new vec3(0.0f, 0.0f, 1.0f),          
			new vec3(1.0f, 0.0f, 0.0f),          
			new vec3(0.0f, 0.0f, 1.0f),          
			new vec3(0.0f, 1.0f, 0.0f),          
			new vec3(1.0f, 0.0f, 0.0f),          
			new vec3(0.0f, 1.0f, 0.0f),          
			new vec3(0.0f, 0.0f, 1.0f),          
			new vec3(1.0f, 0.0f, 0.0f),          
			new vec3(0.0f, 0.0f, 1.0f),          
			new vec3(0.0f, 1.0f, 0.0f),
		};

        private float rotation;


        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"GLCanvas.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"GLCanvas.frag");

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

        protected void InitializeVAO(out uint[] vao, out PrimitiveMode primitiveMode, out int vertexCount)
        {
            primitiveMode = PrimitiveMode.Triangles;
            vertexCount = positions.Length;

            vao = new uint[1];
            GL.GenVertexArrays(1, vao);
            GL.BindVertexArray(vao[0]);

            //  Create a vertex buffer for the vertex data.
            {
                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(GL.GL_ARRAY_BUFFER, ids[0]);
                UnmanagedArray<vec3> positionArray = new UnmanagedArray<vec3>(positions.Length);
                for (int i = 0; i < positions.Length; i++)
                {
                    positionArray[i] = positions[i];
                }
                GL.BufferData(BufferDataTarget.ArrayBuffer, positionArray, BufferDataUsage.StaticDraw);
                GL.VertexAttribPointer(positionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(positionLocation);
            }

            //  Now do the same for the colour data.
            {
                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(GL.GL_ARRAY_BUFFER, ids[0]);
                UnmanagedArray<vec3> colorArray = new UnmanagedArray<vec3>(positions.Length);
                for (int i = 0; i < colors.Length; i++)
                {
                    colorArray[i] = colors[i];
                }
                GL.BufferData(BufferDataTarget.ArrayBuffer, colorArray, BufferDataUsage.StaticDraw);
                GL.VertexAttribPointer(colorLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(colorLocation);
            }

            //  Unbind the vertex array, we've finished specifying data for it.
            GL.BindVertexArray(0);
        }

        protected override void DoInitialize(out ShaderProgram shaderProgram, out uint[] vao, out PrimitiveMode primitiveMode, out int vertexCount)
        {
            InitializeShader(out shaderProgram);

            InitializeVAO(out vao, out primitiveMode, out vertexCount);

        }

        protected override void BeforeRendering(Objects.RenderModes renderMode)
        {
            shaderProgram.Bind();

            rotation += 3.0f;
            modelMatrix = glm.rotate(rotation, new vec3(0, 1, 0));

            const float distance = 0.2f;
            viewMatrix = glm.lookAt(new vec3(-distance, distance, -distance), new vec3(0, 0, 0), new vec3(0, -1, 0));

            int[] viewport = new int[4];
            GL.GetInteger(GetTarget.Viewport, viewport);
            projectionMatrix = glm.perspective(60.0f, (float)viewport[2] / (float)viewport[3], 0.01f, 100.0f);

            shaderProgram.SetUniformMatrix4("projectionMatrix", projectionMatrix.to_array());
            shaderProgram.SetUniformMatrix4("viewMatrix", viewMatrix.to_array());
            shaderProgram.SetUniformMatrix4("modelMatrix", modelMatrix.to_array());
        }

        protected override void AfterRendering(Objects.RenderModes renderMode)
        {
            shaderProgram.Unbind();
        }
    }
}
