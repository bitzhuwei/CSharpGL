
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    // failed replace glEdgeFlag()
    public unsafe class modernEdgeFlag : _glGuide7code {

        public modernEdgeFlag(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        public override void init(CSharpGL.GL gl) {
            var vs = Shader.Create(Shader.Kind.vert, vsCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fsCode, out var _);
            Debug.Assert(vs != null && fs != null);
            var (program, log) = GLProgram.Create(vs, fs);
            Debug.Assert(program != null);
            var positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
            var colorBuffer = colors.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
            var edgeFlagBuffer = edgeFlags.GenVertexBuffer(VBOConfig.Int, GLBuffer.Usage.StaticDraw);
            var attrs = new VertexShaderAttribute[3];
            attrs[0] = new VertexShaderAttribute(positionBuffer, "aPos");
            attrs[1] = new VertexShaderAttribute(colorBuffer, "aColor");
            attrs[2] = new VertexShaderAttribute(edgeFlagBuffer, "aEdgeFlag");
            var indexBuffer = indexes.GenIndexBuffer(IndexBuffer.ElementType.UByte, GLBuffer.Usage.StaticDraw);
            var cmd = new DrawElementsCmd(indexBuffer, CSharpGL.DrawMode.Triangles);
            var vao = new VertexArrayObject(cmd, program, attrs);

            program.SetUniform("model", mat4.identity());
            this.program = program;
            this.vao = vao;

            gl.glPolygonMode(GL.GL_FRONT_AND_BACK, GL.GL_LINE);
        }

        public override void display(CSharpGL.GL gl) {
            if (this.program == null || this.camera == null || this.vao == null) { return; }

            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            this.program?.Bind();
            //this.program?.SetUniform("model", mat4.identity());
            //this.program?.SetUniform("view", camera.GetViewMatrix());
            //this.program?.SetUniform("projection", camera.GetProjectionMatrix());
            this.program?.PushUniforms();
            this.vao?.Draw();
            this.program?.Unbind();
        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            var position = new vec3(5, 3, 4) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, w, h);
            this.camera = camera;
            this.program?.SetUniform("view", camera.GetViewMatrix());
            this.program?.SetUniform("projection", camera.GetProjectionMatrix());

        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }

        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [];
        public override MouseButtons[] ValidButtons => [];

        private static readonly string vsCode = @"#version 330 core

layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aColor;
layout (location = 2) in int aEdgeFlag;

out vec3 ourColor;
flat out int edgeFlag;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    gl_Position = projection * view * model * vec4(aPos, 1.0);
    ourColor = aColor;
    edgeFlag = aEdgeFlag;
}";
        private static readonly string fsCode = @"#version 330 core

in vec3 ourColor;
flat in int edgeFlag;

out vec4 FragColor;

void main()
{
    if (edgeFlag == 1) {
        FragColor = vec4(1.0, 1.0, 1.0, 1.0);  // white edge
    } else {
        FragColor = vec4(ourColor, 1.0);
    }
}
        ";
        private GLProgram? program;
        private VertexArrayObject? vao;
        private Camera? camera;
        static readonly vec3[] positions = {
            new(0,0,0),
            new(1,0,0),
            new(1.5f,1.5f,0),
            new(0,0.5f,0),
        };
        static readonly int[] edgeFlags = { 1, 0, 1, 0 };
        //static readonly vec3[] colors = {
        //    new(1,0,0),
        //    new(0,1,0),
        //    new(0,0,1),
        //    new(1,1,0),
        //};
        static readonly vec3[] colors = {
            new(0,0,0),
            new(0,0,0),
            new(0,0,0),
            new(0,0,0),
        };
        static readonly byte[] indexes = { 0, 1, 3, 1, 2, 3, };
    }
}