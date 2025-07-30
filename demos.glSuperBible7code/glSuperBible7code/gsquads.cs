
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static CSharpGL.TransformFeedbackObject;

namespace demos.glSuperBible7code {

    public unsafe class gsquads : _glSuperBible7code {
        ~gsquads() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public gsquads(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint program_fans;
        GLuint program_linesadjacency;
        GLuint vao;
        int mode;
        int mvp_loc_fans;
        int mvp_loc_linesadj;
        int vid_offset_loc_fans;
        int vid_offset_loc_linesadj;
        int vid_offset;
        bool paused;
        text_overlay overlay = new text_overlay();

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/gsquads.quadsasfans.vert";
                var fsCodeFile = "media/shaders/gsquads.quadsasfans.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program_fans = programObj.programId;
                gl.glUseProgram(this.program_fans);

                mvp_loc_fans = gl.glGetUniformLocation(program_fans, "mvp");
                vid_offset_loc_fans = gl.glGetUniformLocation(program_fans, "vid_offset");

            }
            {
                var vsCodeFile = "media/shaders/gsquads.quadsaslinesadj.vert";
                var gsCodeFile = "media/shaders/gsquads.quadsaslinesadj.geom";
                var fsCodeFile = "media/shaders/gsquads.quadsaslinesadj.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, gsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program_linesadjacency = programObj.programId;
                gl.glUseProgram(this.program_linesadjacency);

                mvp_loc_linesadj = gl.glGetUniformLocation(program_linesadjacency, "mvp");
                vid_offset_loc_linesadj = gl.glGetUniformLocation(program_fans, "vid_offset");

            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);

                overlay.init(80, 50);
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


            mat4 mv_matrix = glm.translate(0.0f, 0.0f, -2.0f) *
                 glm.rotate((float)t * 5.0f, 0.0f, 0.0f, 1.0f) *
                 glm.rotate((float)t * 30.0f, 1.0f, 0.0f, 0.0f);
            mat4 mvp = proj_matrix * mv_matrix;

            overlay.clear();

            switch (mode) {
            case 0:
            overlay.drawText("Drawing quads using GL.GL_TRIANGLE_FAN", 0, 0);
            gl.glUseProgram(program_fans);
            gl.glUniformMatrix4fv(mvp_loc_fans, 1, false, (float*)&mvp);
            gl.glUniform1i(vid_offset_loc_fans, vid_offset);
            gl.glDrawArrays(GL.GL_TRIANGLE_FAN, 0, 4);
            break;
            case 1:
            overlay.drawText("Drawing quads using geometry shaders and GL.GL_LINES_ADJACENCY", 0, 0);
            gl.glUseProgram(program_linesadjacency);
            gl.glUniformMatrix4fv(mvp_loc_linesadj, 1, false, (float*)&mvp);
            gl.glUniform1i(vid_offset_loc_linesadj, vid_offset);
            gl.glDrawArrays(GL.GL_LINES_ADJACENCY, 0, 4);
            break;
            }

            overlay.drawText("M: Choose mode (M toggles)", 0, 1);
            //overlay.drawText("P: Pause", 0, 2);
            overlay.drawText("W/S: Rotate quad vertices", 0, 2);
            overlay.draw();
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
            case Keys.W:
            vid_offset++;
            break;
            case Keys.S:
            vid_offset--;
            break;
            case Keys.M:
            mode = (mode + 1) % 2;
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.W, Keys.S, Keys.M];
        public override MouseButtons[] ValidButtons => [];

    }
}