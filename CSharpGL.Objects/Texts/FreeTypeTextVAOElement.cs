using CSharpGL.Maths;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Texts.FreeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Texts
{
    public class FreeTypeTextVAOElement : VAOElement
    {
        ScientificCamera camera;

        //uint program;
        Shaders.ShaderProgram shaderProgram;
        uint attribute_coord;
        int uniform_tex;
        int uniform_color;

        struct point
        {
            float x;
            float y;
            float s;
            float t;

            public point(float x, float y, float s, float t)
            {
                this.x = x; this.y = y;
                this.s = s; this.t = t;
            }
        };

        uint[] vbo = new uint[1];

        private string fontFilename;
        private FreeTypeLibrary library;
        FreeTypeFace face;

        private atlas a48;
        //private atlas a24;
        //private atlas a12;

        public FreeTypeTextVAOElement(ScientificCamera camera, string fontFilename)
        {
            this.camera = camera;
            this.fontFilename = fontFilename;
        }

        protected override void DoInitialize()
        {
            InitShaderProgram();

            /* Initialize the FreeType2 library */
            library = new FreeTypeLibrary();

            /* Load a font */
            face = new FreeTypeFace(this.library, fontFilename);//, size);

            // Create the vertex buffer object
            GL.GenBuffers(1, vbo);

            /* Create texture atlasses for several font sizes */
            a48 = new atlas(face, 48, shaderProgram);
            //a24 = new atlas(pface, face, 24, shaderProgram);
            //a12 = new atlas(pface, face, 12, shaderProgram);
        }

        private void InitShaderProgram()
        {
            this.shaderProgram = new Shaders.ShaderProgram();

            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"Texts.freetype.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"Texts.freetype.frag");

            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            {
                int location = shaderProgram.GetAttributeLocation("coord");
                if (location >= 0) { this.attribute_coord = (uint)location; }
                else { throw new Exception(); }
            }
            {
                int location = shaderProgram.GetUniformLocation("tex");
                if (location >= 0) { this.uniform_tex = (int)location; }
                else { throw new Exception(); }
            }
            {
                int location = shaderProgram.GetUniformLocation("color");
                if (location >= 0) { this.uniform_color = (int)location; }
                else { throw new Exception(); }
            }

            shaderProgram.AssertValid();
        }

        static Random random = new Random();
        public bool blend;

        public override void Render(RenderModes renderMode)
        {
            int[] viewport = new int[4];
            GL.GetInteger(GetTarget.Viewport, viewport);

            float sx = 2.0f / (float)viewport[2];//glutGet(GLUT_WINDOW_WIDTH);
            float sy = 2.0f / (float)viewport[3];//glutGet(GLUT_WINDOW_HEIGHT);

            //glUseProgram(program);
            shaderProgram.Bind();

            mat4 projectionMatrix = this.camera.GetProjectionMat4();
            //IPerspectiveCamera perspectiveCamera = this.camera as IPerspectiveCamera;
            //mat4 projectionMatrix = perspectiveCamera.GetProjectionMat4();
            //IOrthoCamera orthoCamera = this.camera as IOrthoCamera;
            //mat4 projectionMatrix = orthoCamera.GetProjectionMat4();
            mat4 viewMatrix = this.camera.GetViewMat4();
            mat4 matrix = projectionMatrix * viewMatrix;
            shaderProgram.SetUniformMatrix4("transformMatrix", matrix.to_array());

            /* White background */
            //glClearColor(1, 1, 1, 1);
            //glClear(GL_COLOR_BUFFER_BIT);

            /* Enable blending, necessary for our alpha texture */
            if (this.blend)
            {
                GL.Enable(GL.GL_BLEND);
                GL.BlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            }

            //GLfloat black[4] = { 0, 0, 0, 1 }
            //GLfloat red[4] = { 1, 0, 0, 1 };
            //GLfloat transparent_green[4] = { 0, 1, 0, 0.5 };
            float[] black = { 0, 0, 0, 1 };
            float[] red = { 1, 0, 0, 1 };
            float[] transparent_green = { 0, 1, 0, 0.5f };


            /* Set color to black */
            //glUniform4fv(uniform_color, 1, black);
            //GL.Uniform4(uniform_color, 1, black);
            shaderProgram.SetUniformMatrix4("color", black);

            /* Effects of alignment */
            //render_text("The Quick Brown Fox Jumps Over The Lazy Dog", ref a48, 320, 240,10, 10);
            render_text("The Quick Brown Fox Jumps Over The Lazy Dog", ref a48, random.Next(0, 1000), random.Next(0, 1000), random.Next(0, 100), random.Next(0, 100));

            render_text("The Quick Brown Fox Jumps Over The Lazy Dog", ref a48, -1 + 8 * sx, 1 - 50 * sy, sx, sy);

            render_text("The Misaligned Fox Jumps Over The Lazy Dog", ref a48, -1 + 8.5f * sx, 1 - 100.5f * sy, sx, sy);

            /* Scaling the texture versus changing the font size */
            render_text("The Small Texture Scaled Fox Jumps Over The Lazy Dog", ref a48, -1 + 8 * sx, 1 - 175 * sy, sx * 0.5f, sy * 0.5f);
            //render_text("The Small Font Sized Fox Jumps Over The Lazy Dog", ref a24, -1 + 8 * sx, 1 - 200 * sy, sx, sy);
            render_text("The Tiny Texture Scaled Fox Jumps Over The Lazy Dog", ref a48, -1 + 8 * sx, 1 - 235 * sy, sx * 0.25f, sy * 0.25f);
            //render_text("The Tiny Font Sized Fox Jumps Over The Lazy Dog", ref  a12, -1 + 8 * sx, 1 - 250 * sy, sx, sy);

            /* Colors and transparency */
            render_text("The Solid Black Fox Jumps Over The Lazy Dog", ref a48, -1 + 8 * sx, 1 - 430 * sy, sx, sy);

            //glUniform4fv(uniform_color, 1, red);
            //GL.Uniform4(uniform_color, 1, red);
            shaderProgram.SetUniformMatrix4("color", red);
            render_text("The Solid Red Fox Jumps Over The Lazy Dog", ref  a48, -1 + 8 * sx, 1 - 330 * sy, sx, sy);
            render_text("The Solid Red Fox Jumps Over The Lazy Dog", ref  a48, -1 + 28 * sx, 1 - 450 * sy, sx, sy);

            //glUniform4fv(uniform_color, 1, transparent_green);
            //GL.Uniform4(uniform_color, 1, transparent_green);
            shaderProgram.SetUniformMatrix4("color", transparent_green);
            render_text("The Transparent Green Fox Jumps Over The Lazy Dog", ref a48, -1 + 8 * sx, 1 - 380 * sy, sx, sy);
            render_text("The Transparent Green Fox Jumps Over The Lazy Dog", ref  a48, -1 + 18 * sx, 1 - 440 * sy, sx, sy);
            if (this.blend)
            {
                GL.Disable(GL.GL_BLEND);
            }
        }

        /**
 * Render text using the currently loaded font and currently set font size.
 * Rendering starts at coordinates (x, y), z is always 0.
 * The pixel coordinates that the FreeType2 library uses are scaled by (sx, sy).
 */
        void render_text(string text, ref atlas a, float x, float y, float sx, float sy)
        {
            /* Use the texture containing the atlas */
            GL.BindTexture(GL.GL_TEXTURE_2D, a.tex[0]);
            shaderProgram.SetUniform1("tex", 0);

            /* Set up the VBO for our vertex data */
            GL.EnableVertexAttribArray(attribute_coord);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo[0]);
            GL.VertexAttribPointer(attribute_coord, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);


            UnmanagedArray<point> coords = new UnmanagedArray<point>(6 * text.Length);
            int c = 0;

            /* Loop through all characters */
            foreach (var p in text)
            {
                /* Calculate the vertex and texture coordinates */
                float x2 = x + a.characterInfos[p].bl * sx;
                float y2 = -y - a.characterInfos[p].bt * sy;
                float w = a.characterInfos[p].bw * sx;
                float h = a.characterInfos[p].bh * sy;

                /* Advance the cursor to the start of the next character */
                x += a.characterInfos[p].ax * sx;
                y += a.characterInfos[p].ay * sy;

                /* Skip glyphs that have no pixels */
                if (w == 0 || h == 0) { continue; }

                coords[c++] = new point(x2, -y2, a.characterInfos[p].tx, a.characterInfos[p].ty);
                coords[c++] = new point(x2 + w, -y2, a.characterInfos[p].tx + a.characterInfos[p].bw / a.widthOfTexture, a.characterInfos[p].ty);
                coords[c++] = new point(x2, -y2 - h, a.characterInfos[p].tx, a.characterInfos[p].ty + a.characterInfos[p].bh / a.heightOfTexture);
                coords[c++] = new point(x2 + w, -y2, a.characterInfos[p].tx + a.characterInfos[p].bw / a.widthOfTexture, a.characterInfos[p].ty);
                coords[c++] = new point(x2, -y2 - h, a.characterInfos[p].tx, a.characterInfos[p].ty + a.characterInfos[p].bh / a.heightOfTexture);
                coords[c++] = new point(x2 + w, -y2 - h, a.characterInfos[p].tx + a.characterInfos[p].bw / a.widthOfTexture, a.characterInfos[p].ty + a.characterInfos[p].bh / a.heightOfTexture);
            }

            /* Draw all the character on the screen in one go */
            GL.BufferData(BufferTarget.ArrayBuffer, coords, BufferUsage.DynamicDraw);
            GL.DrawArrays(PrimitiveMode.Triangles, 0, c);

            GL.DisableVertexAttribArray(attribute_coord);
        }
    }
}
