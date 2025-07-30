
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    // note: this is from doubao
    public unsafe class ch10_viewport_array2 : _glGuide8code {
        ~ch10_viewport_array2() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public ch10_viewport_array2(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint shaderProgram;
        float aspect;
        GLuint vao;


        // 设置顶点数据
        static readonly float[] vertices = {
        // 位置                // 颜色
        -0.5f, -0.5f, 0.0f,     1.0f, 0.0f, 0.0f, // 左下
         0.5f, -0.5f, 0.0f,     0.0f, 1.0f, 0.0f, // 右下
         0.0f,  0.5f, 0.0f,     0.0f, 0.0f, 1.0f  // 顶部
        };
        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "10/ch10_viewport_array2/render.vert";
                var gsCodeFile = "10/ch10_viewport_array2/render.geom";
                var fsCodeFile = "10/ch10_viewport_array2/render.frag";
                var program = Utility.LoadShaders(vsCodeFile, gsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.shaderProgram = program.programId;
                gl.glUseProgram(this.shaderProgram);
            }
            {
                // 创建和配置VAO、VBO
                GLuint VAO, VBO;
                gl.glGenVertexArrays(1, &VAO); this.vao = VAO;
                gl.glGenBuffers(1, &VBO);

                gl.glBindVertexArray(VAO);

                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, VBO);
                fixed (float* p = vertices) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER,
                        sizeof(float) * vertices.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }

                // 位置属性
                gl.glVertexAttribPointer(0, 3, GL.GL_FLOAT, false, 6 * sizeof(float), IntPtr.Zero);
                gl.glEnableVertexAttribArray(0);

                // 颜色属性
                gl.glVertexAttribPointer(1, 3, GL.GL_FLOAT, false, 6 * sizeof(float), (IntPtr)(3 * sizeof(float)));
                gl.glEnableVertexAttribArray(1);

                gl.glBindVertexArray(0);

                // 查询最大支持的视口数量
                GLint maxViewports;
                gl.glGetIntegerv(0x825B/*GL_MAX_VIEWPORTS*/, &maxViewports);
                //std::cout << "最大支持视口数量: " << maxViewports << std::endl;

                // 设置两个视口
                gl.glEnable(GL.GL_SCISSOR_TEST);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            // 激活着色器
            gl.glUseProgram(shaderProgram);

            // 绘制三角形
            gl.glBindVertexArray(vao);

            // 启用多视口渲染
            GLuint[] viewports = { 0, 1 };
            gl.glDrawArraysInstancedBaseInstance(GL.GL_TRIANGLES, 0, 3, 1, 0);

            gl.glBindVertexArray(0);
        }

        public override void reshape(CSharpGL.GL gl, int width, int height) {
            //gl.glViewport(0, 0, width, height);

            aspect = (float)height / (float)width;
            // 设置视口0 - 左半部分
            gl.glViewportIndexedf(0, 0.0f, 0.0f, width / 2.0f, height);
            gl.glScissorIndexed(0, 0, 0, width / 2, height);

            // 设置视口1 - 右半部分
            gl.glViewportIndexedf(1, width / 2.0f, 0.0f, width / 2.0f, height);
            gl.glScissorIndexed(1, width / 2, 0, width / 2, height);
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

    }
}