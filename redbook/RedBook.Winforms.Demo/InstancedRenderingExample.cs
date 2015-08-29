using CSharpGL;
using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.Shaders;
using RedBook.Common.FurExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL.Objects.Cameras;
using RedBook.Common;
using System.Runtime.InteropServices;

namespace RedBook.Winforms.Demo
{
    public class InstancedRenderingExample : SceneElementBase, IDisposable
    {

        const int INSTANCE_COUNT = 100;

        static string render_vs =
@"#version 330

// 'position' and 'normal' are regular vertex attributes
layout (location = 0) in vec4 position;
layout (location = 1) in vec3 normal;

// Color is a per-instance attribute
layout (location = 2) in vec4 color;

// model_matrix will be used as a per-instance transformation
// matrix. Note that a mat4 consumes 4 consecutive locations, so
// this will actually sit in locations, 3, 4, 5, and 6.
layout (location = 3) in mat4 model_matrix;

// The view matrix and the projection matrix are constant across a draw
uniform mat4 view_matrix;
uniform mat4 projection_matrix;

// The output of the vertex shader (matched to the fragment shader)
out VERTEX
{
    vec3    normal;
    vec4    color;
} vertex;

// Ok, go!
void main(void)
{
    // Construct a model-view matrix from the uniform view matrix
    // and the per-instance model matrix.
    mat4 model_view_matrix = view_matrix * model_matrix;

    // Transform position by the model-view matrix, then by the
    // projection matrix.
    gl_Position = projection_matrix * (model_view_matrix * position);
    // Transform the normal by the upper-left-3x3-submatrix of the
    // model-view matrix
    vertex.normal = mat3(model_view_matrix) * normal;
    // Pass the per-instance color through to the fragment shader.
    vertex.color = color;
}";

        static string render_fs =
@"#version 330

layout (location = 0) out vec4 color;

in VERTEX
{
    vec3    normal;
    vec4    color;
} vertex;

void main(void)
{
    color = vertex.color * (0.1 + abs(vertex.normal.z)) + vec4(0.8, 0.9, 0.7, 1.0) * pow(abs(vertex.normal.z), 40.0);
}";

        public virtual void Reshape(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
        }


        // Member variables
        uint[] color_buffer = new uint[1];
        uint[] model_matrix_buffer = new uint[1];
        uint render_prog;
        int view_matrix_loc;
        int projection_matrix_loc;

        // Object to render
        VBObject vboObject = new VBObject();


        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        } // end sub

        /// <summary>
        /// Destruct instance of the class.
        /// </summary>
        ~InstancedRenderingExample()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Backing field to track whether Dispose has been called.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Dispose managed and unmanaged resources of this instance.
        /// </summary>
        /// <param name="disposing">If disposing equals true, managed and unmanaged resources can be disposed. If disposing equals false, only unmanaged resources can be disposed. </param>
        protected virtual void Dispose(bool disposing)
        {

            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // TODO: Dispose managed resources.
                    this.vboObject.Dispose();
                } // end if

                // TODO: Dispose unmanaged resources.
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion

        protected override void DoInitialize()
        {
            render_prog = GL.CreateProgram();
            ShaderHelper.vglAttachShaderSource(render_prog, ShaderType.VertexShader, render_vs);
            ShaderHelper.vglAttachShaderSource(render_prog, ShaderType.FragmentShader, render_fs);

            GL.LinkProgram(render_prog);
            GL.UseProgram(render_prog);

            view_matrix_loc = GL.GetUniformLocation(render_prog, "view_matrix");
            projection_matrix_loc = GL.GetUniformLocation(render_prog, "projection_matrix");

            vboObject.LoadFromVBM(@"media\armadillo_low.vbm", 0, 1, 2);

            // Bind its vertex array object so that we can append the instanced attributes
            vboObject.BindVertexArray();

            // Get the locations of the vertex attributes in 'prog', which is the
            // (linked) program object that we're going to be rendering with. Note
            // that this isn't really necessary because we specified locations for
            // all the attributes in our vertex shader. This code could be made
            // more concise by assuming the vertex attributes are where we asked
            // the compiler to put them.
            int position_loc = GL.GetAttribLocation(render_prog, "position");
            int normal_loc = GL.GetAttribLocation(render_prog, "normal");
            int color_loc = GL.GetAttribLocation(render_prog, "color");
            int matrix_loc = GL.GetAttribLocation(render_prog, "model_matrix");
            // Generate the colors of the objects
            var colors = new UnmanagedArray<vec4>(INSTANCE_COUNT);

            for (int n = 0; n < INSTANCE_COUNT; n++)
            {
                float a = (float)(n) / 4.0f;
                float b = (float)(n) / 5.0f;
                float c = (float)(n) / 6.0f;

                colors[n] = new vec4(
                    (float)(0.5f + 0.25f * (Math.Sin(a + 1.0f) + 1.0f)),
                    (float)(0.5f + 0.25f * (Math.Sin(b + 2.0f) + 1.0f)),
                    (float)(0.5f + 0.25f * (Math.Sin(c + 3.0f) + 1.0f)),
                    (float)(1.0f)
                    );
            }

            GL.GenBuffers(1, color_buffer);
            GL.BindBuffer(BufferTarget.ArrayBuffer, color_buffer[0]);
            GL.BufferData(BufferTarget.ArrayBuffer, colors, BufferUsage.DynamicDraw);
            colors.Dispose();

            // Now we set up the color array. We want each instance of our geometry
            // to assume a different color, so we'll just pack colors into a buffer
            // object and make an instanced vertex attribute out of it.
            GL.BindBuffer(BufferTarget.ArrayBuffer, color_buffer[0]);
            GL.VertexAttribPointer((uint)color_loc, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            GL.EnableVertexAttribArray((uint)color_loc);
            // This is the important bit... set the divisor for the color array to
            // 1 to get OpenGL to give us a new value of 'color' per-instance
            // rather than per-vertex.
            GL.VertexAttribDivisor((uint)color_loc, 1);

            // Likewise, we can do the same with the model matrix. Note that a
            // matrix input to the vertex shader consumes N consecutive input
            // locations, where N is the number of columns in the matrix. So...
            // we have four vertex attributes to set up.
            UnmanagedArray<mat4> tmp = new UnmanagedArray<mat4>(INSTANCE_COUNT);
            GL.GenBuffers(1, model_matrix_buffer);
            GL.BindBuffer(BufferTarget.ArrayBuffer, model_matrix_buffer[0]);
            GL.BufferData(BufferTarget.ArrayBuffer, tmp, BufferUsage.DynamicDraw);
            tmp.Dispose();

            // Loop over each column of the matrix...
            for (int i = 0; i < 4; i++)
            {
                // Set up the vertex attribute
                GL.VertexAttribPointer((uint)(matrix_loc + i),              // Location
                                      4, GL.GL_FLOAT, false,       // vec4
                                      Marshal.SizeOf(typeof(mat4)),                // Stride
                                      new IntPtr(Marshal.SizeOf(typeof(vec4)) * i)); // Start offset
                // Enable it
                GL.EnableVertexAttribArray((uint)(matrix_loc + i));
                // Make it instanced
                GL.VertexAttribDivisor((uint)(matrix_loc + i), 1);
            }

            // Done (unbind the object's VAO)
            GL.BindVertexArray(0);

        }

        static float q = 0.0f;
        static readonly vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static readonly vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static readonly vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        const float factor = 0x3FFF;

        protected override void DoRender(RenderEventArgs e)
        {
            float t = (float)(TimerHelper.GetTickCount() & 0x3FFF) / factor;
            int n;


            //// Setup
            //glEnable(GL_CULL_FACE);
            //glEnable(GL_DEPTH_TEST);
            //glDepthFunc(GL_LEQUAL);

            // Bind the weight VBO and change its data
            GL.BindBuffer(BufferTarget.ArrayBuffer, model_matrix_buffer[0]);

            // Set model matrices for each instance
            IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.WriteOnly);

            unsafe
            {
                mat4* matrices = (mat4*)pointer.ToPointer();
                for (n = 0; n < INSTANCE_COUNT; n++)
                {
                    float a = 50.0f * (float)(n) / 4.0f;
                    float b = 50.0f * (float)(n) / 5.0f;
                    float c = 50.0f * (float)(n) / 6.0f;

                    matrices[n] =
                          glm.rotate(a + t * 1.0f, new vec3(1, 0, 0))
                        * glm.rotate(b + t * 1.0f, new vec3(0, 1, 0))
                        * glm.rotate(c + t * 1.0f, new vec3(0, 0, 1))
                        * glm.translate(mat4.identity(), new vec3(10.0f + a, 40.0f + b, 50.0f + c));
                }
            }

            GL.UnmapBuffer(BufferTarget.ArrayBuffer);

            // Activate instancing program
            GL.UseProgram(render_prog);

            // Set up the view and projection matrices
            //mat4 view_matrix(translate(0.0f, 0.0f, -1500.0f) * rotate(t * 360.0f * 2.0f, 0.0f, 1.0f, 0.0f));
            //mat4 projection_matrix(frustum(-1.0f, 1.0f, -aspect, aspect, 1.0f, 5000.0f));
            mat4 view_matrix = e.Camera.GetViewMat4();
            mat4 projection_matrix = e.Camera.GetProjectionMat4();
            GL.UniformMatrix4(view_matrix_loc, 1, false, view_matrix.to_array());
            GL.UniformMatrix4(projection_matrix_loc, 1, false, projection_matrix.to_array());

            // Render INSTANCE_COUNT objects
            vboObject.Render(0, INSTANCE_COUNT);

        }

    }
}

