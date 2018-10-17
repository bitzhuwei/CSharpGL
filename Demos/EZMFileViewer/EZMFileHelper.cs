using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    public static class EZMFileHelper
    {
        /// <summary>
        /// Load textures and attach them to materials' tag property.
        /// </summary>
        /// <param name="ezmFile"></param>
        public static void LoadTextures(this EZMFile ezmFile)
        {
            if (ezmFile != null)
            {
                string directory = (new FileInfo(ezmFile.Fullname)).DirectoryName;
                foreach (var material in ezmFile.MeshSystem.Materials)
                {
                    string filename = Path.Combine(directory, material.MetaData);
                    var bitmap = new Bitmap(filename);
                    var storage = new TexImageBitmap(bitmap);
                    var texture = new Texture(storage,
                          new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                          new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                          new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                          new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                    texture.Initialize();
                    material.Tag = texture;
                }
            }
        }
    }
}
