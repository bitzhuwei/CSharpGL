using System;

namespace CSharpGL
{
    public class GLFontVertexBuffer : IDisposable
    {
        public int TextureID { get { return textureID; } internal set { textureID = value; } }
        public int VaoID { get { return vaoID; } }
        public int VertexCount { get { return vertexCount; } }

        int textureID;
        int vaoID, vboID;
        float[] vertices = new float[1024];
        int floatCount = 0;
        int vertexCount = 0;

        public GLFontVertexBuffer(int textureID)
        {
            this.textureID = textureID;
            vaoID = OpenGL.GenVertexArray();
            vboID = OpenGL.GenBuffer();
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
            OpenGL.DeleteVertexArray(vaoID);
            OpenGL.DeleteBuffer(vboID);
            //TODO: tmp commented.
            //GLGui.usedVertexArrays--;
        }

        public void Reset()
        {
            floatCount = 0;
            vertexCount = 0;
        }

        public void AddQuad(float minx, float miny, float maxx, float maxy, float mintx, float minty, float maxtx, float maxty)
        {
            if (floatCount + 16 >= vertices.Length)
                Array.Resize(ref vertices, vertices.Length * 2);

            vertices[floatCount + 0] = minx;
            vertices[floatCount + 1] = miny;
            vertices[floatCount + 2] = mintx;
            vertices[floatCount + 3] = minty;

            vertices[floatCount + 4] = minx;
            vertices[floatCount + 5] = maxy;
            vertices[floatCount + 6] = mintx;
            vertices[floatCount + 7] = maxty;

            vertices[floatCount + 8] = maxx;
            vertices[floatCount + 9] = maxy;
            vertices[floatCount + 10] = maxtx;
            vertices[floatCount + 11] = maxty;

            vertices[floatCount + 12] = maxx;
            vertices[floatCount + 13] = miny;
            vertices[floatCount + 14] = maxtx;
            vertices[floatCount + 15] = minty;
            floatCount += 16;
            vertexCount += 4;
        }

        public void Load()
        {
            if (floatCount == 0)
                return;

            OpenGL.BindVertexArray(vaoID);
            OpenGL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            OpenGL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(floatCount * 4), vertices, BufferUsageHint.StaticDraw);

            OpenGL.VertexPointer(2, VertexPointerType.Float, 16, 0);
            OpenGL.EnableClientState(ArrayCap.VertexArray);
            OpenGL.TexCoordPointer(2, TexCoordPointerType.Float, 16, 8);
            OpenGL.EnableClientState(ArrayCap.TextureCoordArray);
            OpenGL.BindVertexArray(0);
        }

        public void Draw()
        {
            if (vertexCount == 0)
                return;

            OpenGL.Enable(EnableCap.Texture2D);
            OpenGL.BindTexture(TextureTarget.Texture2D, textureID);

            OpenGL.BindVertexArray(vaoID);
            OpenGL.DrawArrays(PrimitiveType.Quads, 0, vertexCount);
            OpenGL.BindVertexArray(0);

            OpenGL.Disable(EnableCap.Texture2D);
        }
    }
}
