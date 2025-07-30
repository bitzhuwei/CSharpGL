
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace demos.glSuperBible7code {
    public unsafe class text_overlay {
        GLuint text_buffer;
        GLuint font_texture;
        GLuint vao;

        GLuint text_program;
        byte[] screen_buffer;
        int buffer_width;
        int buffer_height;
        bool dirty;
        int cursor_x;
        int cursor_y;

        public void init(int width, int height, string? font = null) {
            var gl = GL.Current; Debug.Assert(gl != null);

            buffer_width = width;
            buffer_height = height;

            {
                var vs = Shader.Create(Shader.Kind.vert, vs_source, out var _);
                var fs = Shader.Create(Shader.Kind.frag, fs_source, out var _);
                Debug.Assert(vs != null && fs != null);
                var (programObj, log) = GLProgram.Create(vs, fs);
                Debug.Assert(programObj != null); this.text_program = programObj.programId;
                gl.glUseProgram(this.text_program);

            }

            var id = stackalloc GLuint[1];
            // glCreateVertexArrays(1, &vao);
            gl.glGenVertexArrays(1, id); vao = id[0];
            gl.glBindVertexArray(vao);

            // glCreateTextures(GL.GL_TEXTURE_2D, 1, &text_buffer);
            gl.glGenTextures(1, id); text_buffer = id[0];
            gl.glBindTexture(GL.GL_TEXTURE_2D, text_buffer);
            gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_R8UI, width, height);

            if (string.IsNullOrEmpty(font)) { font = "media/textures/cp437_9x16.ktx"; }
            font_texture = sb7ktx.load(font);

            screen_buffer = new byte[width * height];
            //memset(screen_buffer, 0, width * height);
        }

        public void teardown() {
            var gl = GL.Current; Debug.Assert(gl != null);

            //delete[] screen_buffer;
            var id = font_texture;
            gl.glDeleteTextures(1, &id);
            id = text_buffer;
            gl.glDeleteTextures(1, &id);
            id = vao;
            gl.glDeleteVertexArrays(1, &id);
            gl.glDeleteProgram(text_program);
        }

        public void draw() {
            var gl = GL.Current; Debug.Assert(gl != null);
            gl.glUseProgram(text_program);
            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, text_buffer);
            if (dirty) {
                fixed (byte* p = screen_buffer) {
                    gl.glTexSubImage2D(GL.GL_TEXTURE_2D, 0, 0, 0,
                        buffer_width, buffer_height, GL.GL_RED_INTEGER, GL.GL_UNSIGNED_BYTE, (IntPtr)p);
                }
                dirty = false;
            }
            gl.glActiveTexture(GL.GL_TEXTURE1);
            gl.glBindTexture(GL.GL_TEXTURE_2D_ARRAY, font_texture);

            gl.glBindVertexArray(vao);
            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);
        }

        public void drawText(string str, int x, int y) {
            //char* dst = screen_buffer + y * buffer_width + x;
            //strcpy(dst, str);
            var src = (byte*)Marshal.StringToHGlobalAnsi(str);
            var start = y * buffer_width + x;
            for (int i = 0; i < str.Length; i++) {
                screen_buffer[start + i] = src[i];
            }
            Marshal.FreeHGlobal((IntPtr)src);
            dirty = true;
        }

        public void scroll(int lines) {
            fixed (byte* p = screen_buffer) {
                byte* src = p + lines * buffer_width;
                byte* dst = p;

                Utility.memmove(dst, src, (buffer_height - lines) * buffer_width);
            }

            dirty = true;
        }

        public void print(string str) {
            var src = (byte*)Marshal.StringToHGlobalAnsi(str);
            var pSrc = src;
            fixed (byte* pDest = screen_buffer) {
                var dst = pDest + cursor_y * buffer_width + cursor_x;

                while (*pSrc != 0) {
                    byte c = *pSrc++;
                    if (c == '\n') {
                        cursor_y++;
                        cursor_x = 0;
                        if (cursor_y >= buffer_height) {
                            cursor_y--;
                            scroll(1);
                        }
                        dst = pDest + cursor_y * buffer_width + cursor_x;
                    }
                    else {
                        *dst++ = c;
                        cursor_x++;
                        if (cursor_x >= buffer_width) {
                            cursor_y++;
                            cursor_x = 0;
                            if (cursor_y >= buffer_height) {
                                cursor_y--;
                                scroll(1);
                            }
                            dst = pDest + cursor_y * buffer_width + cursor_x;
                        }
                    }
                }
            }
            Marshal.FreeHGlobal((IntPtr)src);

            dirty = true;
        }

        public void moveCursor(int x, int y) {
            cursor_x = x;
            cursor_y = y;
        }

        public void clear() {
            //memset(screen_buffer, 0, buffer_width * buffer_height);
            Array.Clear(this.screen_buffer);
            dirty = true;
            cursor_x = 0;
            cursor_y = 0;
        }

        const string vs_source = @"#version 440 core

void main(void) {
    gl_Position = vec4(float((gl_VertexID >> 1) & 1) * 2.0 - 1.0,
                       float((gl_VertexID & 1)) * 2.0 - 1.0,
                       0.0, 1.0);
}";
        const string fs_source = @"#version 440 core

layout (origin_upper_left) in vec4 gl_FragCoord;
layout (location = 0) out vec4 o_color;
layout (binding = 0) uniform isampler2D text_buffer;
layout (binding = 1) uniform isampler2DArray font_texture;

void main(void) {
    ivec2 frag_coord = ivec2(gl_FragCoord.xy);
    ivec2 char_size = textureSize(font_texture, 0).xy;
    ivec2 char_location = frag_coord / char_size;
    ivec2 texel_coord = frag_coord % char_size;
    int character = texelFetch(text_buffer, char_location, 0).x;
    float val = texelFetch(font_texture, ivec3(texel_coord, character), 0).x;
    if (val == 0.0) discard;

    o_color = vec4(1.0);
}";

    }
}
