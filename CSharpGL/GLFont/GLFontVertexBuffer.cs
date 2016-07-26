using System;

namespace CSharpGL
{
    public class GLFontVertexBuffer : RendererBase, IDisposable
    {
        public uint TextureID { get { return textureID; } internal set { textureID = value; } }
        public uint VaoID { get { return vaoID[0]; } }
        public int VertexCount { get { return vertexCount; } }

        uint textureID;
        uint[] vaoID = new uint[1];
        uint[] vboID = new uint[1];
        UnmanagedArray<float> vertexes;//= new UnmanagedArray<float>(1024);
        int floatCount = 0;
        int vertexCount = 0;

        public GLFontVertexBuffer(uint textureID)
        {
            this.textureID = textureID;

            //TODO: tmp commented.
            //GLGui.usedVertexArrays++;
        }

        ~GLFontVertexBuffer()
        {
            //TODO: tmp commented.
            //lock (GLGui.toDispose)
            //{
            //    GLGui.toDispose.Add(this);
            //}
        }

        public void Dispose()
        {
            OpenGL.GetDelegateFor<OpenGL.glDeleteVertexArrays>()(1, vaoID);
            OpenGL.GetDelegateFor<OpenGL.glDeleteBuffers>()(1, vboID);
            //TODO: tmp commented.
            //GLGui.usedVertexArrays--;
        }

        public void Reset()
        {
            floatCount = 0;
            vertexCount = 0;
        }

        public unsafe void AddQuad(float minx, float miny, float maxx, float maxy, float mintx, float minty, float maxtx, float maxty)
        {
            if (vertexes == null)
            {
                vertexes = new UnmanagedArray<float>(floatCount + 16);
            }
            else if (floatCount + 16 >= vertexes.Length)
            {
                vertexes = new UnmanagedArray<float>(vertexes.Length * 2);
            }

            var array = (float*)vertexes.Header.ToPointer();
            array[floatCount + 0] = minx;
            array[floatCount + 1] = miny;
            array[floatCount + 2] = mintx;
            array[floatCount + 3] = minty;

            array[floatCount + 4] = minx;
            array[floatCount + 5] = maxy;
            array[floatCount + 6] = mintx;
            array[floatCount + 7] = maxty;

            array[floatCount + 8] = maxx;
            array[floatCount + 9] = maxy;
            array[floatCount + 10] = maxtx;
            array[floatCount + 11] = maxty;

            array[floatCount + 12] = maxx;
            array[floatCount + 13] = miny;
            array[floatCount + 14] = maxtx;
            array[floatCount + 15] = minty;
            floatCount += 16;
            vertexCount += 4;
        }

        public void Load()
        {
            if (floatCount == 0)
                return;

            OpenGL.GetDelegateFor<OpenGL.glBindVertexArray>()(vaoID[0]);
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, vboID[0]);
            OpenGL.BufferData(BufferTarget.ArrayBuffer, vertexes, BufferUsage.StaticDraw);

            //TODO: tmp commented.
            //OpenGL.VertexPointer(2, OpenGL.GL_FLOAT, 16, IntPtr.Zero);
            //OpenGL.EnableClientState(OpenGL.GL_VERTEX_ARRAY);
            //OpenGL.TexCoordPointer(2, OpenGL.GL_FLOAT, 16, new IntPtr(8));
            //OpenGL.EnableClientState(OpenGL.GL_TEXTURE_COORD_ARRAY);
            OpenGL.GetDelegateFor<OpenGL.glBindVertexArray>()(0);
        }

        protected override void DoInitialize()
        {
            OpenGL.GetDelegateFor<OpenGL.glGenVertexArrays>()(1, vaoID);
            OpenGL.GetDelegateFor<OpenGL.glGenBuffers>()(1, vboID);

            Load();
        }

        protected override void DoRender(RenderEventArg arg)
        {
            if (vertexCount == 0)
                return;

            OpenGL.Enable(OpenGL.GL_TEXTURE_2D);
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, textureID);

            OpenGL.GetDelegateFor<OpenGL.glBindVertexArray>()(vaoID[0]);
            OpenGL.DrawArrays(DrawMode.Quads, 0, vertexCount);
            OpenGL.GetDelegateFor<OpenGL.glBindVertexArray>()(0);

            OpenGL.Disable(OpenGL.GL_TEXTURE_2D);
        }
    }
}
