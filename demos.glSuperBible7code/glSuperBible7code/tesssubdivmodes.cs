
using CSharpGL;
using demos.glSuperBible7code;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class tesssubdivmodes : _glSuperBible7code {
        ~tesssubdivmodes() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public tesssubdivmodes(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint[] programs = new uint[3];
        int program_index;
        GLuint vao;

        static string[] vsCodeFiles = [
            "media/shaders/tesssubdivmodes.vert",
            "media/shaders/tesssubdivmodes.vert",
            "media/shaders/tesssubdivmodes.vert"];

        static string[] tcCodeFiles = [
            "media/shaders/tesssubdivmodes.triangles.tesc",
            "media/shaders/tesssubdivmodes.triangles.tesc",
            "media/shaders/tesssubdivmodes.triangles.tesc"];

        static string[] teCodeFiles = [
            "media/shaders/tesssubdivmodes.equal.tese",
            "media/shaders/tesssubdivmodes.fract_even.tese",
            "media/shaders/tesssubdivmodes.fract_odd.tese"];

        static string[] fsCodeFiles = [
            "media/shaders/tessmodes.frag",
            "media/shaders/tessmodes.frag",
            "media/shaders/tessmodes.frag"];
        public override void init(CSharpGL.GL gl) {
            for (int i = 0; i < programs.Length; i++) {
                var vsCodeFile = vsCodeFiles[i];
                var tcCodeFile = tcCodeFiles[i];
                var teCodeFile = teCodeFiles[i];
                var fsCodeFile = fsCodeFiles[i];
                var programObj = Utility.LoadShaders(vsCodeFile, tcCodeFile, teCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.programs[i] = programObj.programId;
                //gl.glUseProgram(this.programs[i]);
            }
            {

                GLuint id;
                gl.glGenVertexArrays(1, &id); vao = id;
                gl.glBindVertexArray(vao);

                gl.glPatchParameteri(GL.GL_PATCH_VERTICES, 4);
                gl.glPolygonMode(GL.GL_FRONT_AND_BACK, GL.GL_LINE);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float t = 0;// time
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            t += 0.01f;

            var proj_matrix = this.proj_matrix;

            gl.glUseProgram(programs[program_index]);
            // glUniform1f(0, (float)Math.Sin((float)currentTime) * 5.0f + 6.0f);
            gl.glUniform1f(0, 5.3f);
            gl.glDrawArrays(GL.GL_PATCHES, 0, 4);
        }

        int width, height;
        mat4 proj_matrix;
        public override void reshape(CSharpGL.GL gl, int width, int height) {
            this.width = width; this.height = height;
            gl.glViewport(0, 0, width, height);

            //aspect = (float)height / (float)width;
            this.proj_matrix = glm.perspective(50.0f * (float)Math.PI / 180.0f, (float)width / (float)height, 0.1f, 1000.0f);
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }

        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.M:
            program_index = (program_index + 1) % 3;
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.M];
        public override MouseButtons[] ValidButtons => [];

    }
}