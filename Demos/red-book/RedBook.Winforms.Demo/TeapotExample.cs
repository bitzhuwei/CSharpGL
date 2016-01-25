using CSharpGL;
using GLM;
using CSharpGL.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL.Objects.Cameras;
using RedBook.Common;

namespace RedBook.Winforms.Demo
{
    class TeapotExample : RendererBase
    {
        /// <summary>
        /// Projection matrix
        /// </summary>
        int PLoc;
        /// <summary>
        /// Inner tessellation paramter
        /// </summary>
        int InnerLoc;
        /// <summary>
        /// Outer tessellation paramter
        /// </summary>
        int OuterLoc;

        float Inner = 1.0f;
        float Outer = 1.0f;

        const int ArrayBuffer = 0;
        const int ElementBuffer = 1;
        const int NumVertexBuffers = 2;
        private uint shaderProgramObject;
        protected override void DoInitialize()
        {
            // Create a vertex array object
            uint[] vao = new uint[1];
            GL.GenVertexArrays(1, vao);
            GL.BindVertexArray(vao[0]);

            // Create and initialize a buffer object
            uint[] buffers = new uint[NumVertexBuffers];
            GL.GenBuffers(NumVertexBuffers, buffers);
            GL.BindBuffer(GL.GL_ARRAY_BUFFER, buffers[ArrayBuffer]);
            //GL.BufferData( GL.GL_ARRAY_BUFFER, sizeof(TeapotVertices), TeapotVertices, GL_STATIC_DRAW );
            UnmanagedArray<vec3> positions = new UnmanagedArray<vec3>(TeapotExampleHelper.NumTeapotVertices);
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = TeapotExampleHelper.TeapotVertices[i];
            }
            GL.BufferData(BufferTarget.ArrayBuffer, positions, BufferUsage.StaticDraw);

            GL.BindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, buffers[ElementBuffer]);
            //GL.BufferData( GL_ELEMENT_ARRAY_BUFFER, sizeof(TeapotIndices), TeapotIndices, GL_STATIC_DRAW );
            UnmanagedArray<uint> indexes = new UnmanagedArray<uint>(TeapotExampleHelper.NumTeapotPatches * 4 * 4);
            for (int i = 0; i < indexes.Length; i++)
            {
                indexes[i] = TeapotExampleHelper.TeapotIndices[i];
            }
            GL.BufferData(BufferTarget.ElementArrayBuffer, indexes, BufferUsage.StaticDraw);

            // Load shaders and use the resulting shader program
            ShaderInfo[] shaders = new ShaderInfo[]
            {
                new ShaderInfo(){ type= ShaderType.VertexShader, shaderSource=ManifestResourceLoader.LoadTextFile("teapot.vert"),},
                new ShaderInfo(){ type= ShaderType.TessellationControlShader, shaderSource=ManifestResourceLoader.LoadTextFile("teapot.cont"),},
                //new ShaderInfo(){ type= ShaderType.TessellationEvaluationShader, shaderSource=ManifestResourceLoader.LoadTextFile("teapot.eval"),},
                new ShaderInfo(){ type= ShaderType.FragmentShader, shaderSource=ManifestResourceLoader.LoadTextFile("teapot.frag"),},
            };

            //uint program = LoadShaders( shaders );
            shaderProgramObject = shaders.LoadShaders();
            GL.UseProgram(shaderProgramObject);

            // set up vertex arrays
            int vPosition = GL.GetAttribLocation(shaderProgramObject, "vPosition");
            GL.EnableVertexAttribArray((uint)vPosition);
            GL.VertexAttribPointer((uint)vPosition, 3, GL.GL_DOUBLE, false, 0, new IntPtr(0));

            PLoc = GL.GetUniformLocation(shaderProgramObject, "P");
            InnerLoc = GL.GetUniformLocation(shaderProgramObject, "Inner");
            OuterLoc = GL.GetUniformLocation(shaderProgramObject, "Outer");

            GL.Uniform1(InnerLoc, Inner);
            GL.Uniform1(OuterLoc, Outer);

            mat4 modelview = glm.translate(mat4.identity(), new vec3(-0.2625f, -1.575f, -1.0f));
            modelview *= glm.translate(modelview, new vec3(0.0f, 0.0f, -7.5f));
            GL.UniformMatrix4(GL.GetUniformLocation(shaderProgramObject, "MV"), 1, true, modelview.to_array());

            GL.PatchParameter(PatchParameterName.PatchVertices, TeapotExampleHelper.NumTeapotVerticesPerPatch);
        }

        protected override void DoRender(RenderEventArgs e)
        {
            GL.UseProgram(shaderProgramObject);

            mat4 view = e.Camera.GetViewMat4();
            mat4 projection = e.Camera.GetProjectionMat4();
            PLoc = GL.GetUniformLocation(shaderProgramObject, "P");
            GL.UniformMatrix4(PLoc, 1, true, projection.to_array());
            GL.UniformMatrix4(GL.GetUniformLocation(shaderProgramObject, "MV"), 1, true, view.to_array());

            GL.DrawElements(DrawMode.Patches, TeapotExampleHelper.NumTeapotVertices, GL.GL_UNSIGNED_INT, new IntPtr(0));

            GL.UseProgram(0);
        }

        protected override void DisposeManagedResources()
        {
        }

        protected override void DisposeUnmanagedResources()
        {
        }
    }
}
