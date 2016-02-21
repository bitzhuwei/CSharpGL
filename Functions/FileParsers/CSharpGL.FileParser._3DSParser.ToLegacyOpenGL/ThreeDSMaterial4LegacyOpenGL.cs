// Title:	Material.cs
// Author: 	Scott Ellington <scott.ellington@gmail.com>
//
// Copyright (C) 2006 Scott Ellington and authors
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using CSharpGL.Objects;
using System;


namespace CSharpGL.FileParser._3DSParser.ToLegacyOpenGL
{
    public class ThreeDSMaterial4LegacyOpenGL
    {
        public string MaterialName;

        // Set Default values
        public float[] Ambient = new float[] { 0.5f, 0.5f, 0.5f };
        public float[] Diffuse = new float[] { 0.5f, 0.5f, 0.5f };
        public float[] Specular = new float[] { 0.5f, 0.5f, 0.5f };
        public ushort Shininess = 50;

        public override string ToString()
        {
            //return base.ToString();
            return string.Format("{0}: {1}", this.MaterialName, this.TextureFilename);
        }

        bool textureInitialized = false;
        public Texture2D GetTexture()
        {
            if (!textureInitialized)
            {
                lock (synObj)
                {
                    if (!textureInitialized)
                    {
                        if (!string.IsNullOrEmpty(this.TextureFilename))
                        {
                            var texture = new Texture2D();
                            var bitmap = new System.Drawing.Bitmap(this.TextureFilename);
                            texture.Initialize(bitmap);
                            this.texture = texture;
                        }

                        textureInitialized = true;
                    }
                }
            }

            return this.texture;
        }

        bool bumpTextureInitialized = false;
        public Texture2D GetBumpTexture()
        {
            if (!bumpTextureInitialized)
            {
                lock (synObj)
                {
                    if (!bumpTextureInitialized)
                    {
                        if (!string.IsNullOrEmpty(this.BumpFilename))
                        {
                            var texture = new Texture2D();
                            var bitmap = new System.Drawing.Bitmap(this.BumpFilename);
                            texture.Initialize(bitmap);
                            this.BumpTexture = texture;
                        }

                        bumpTextureInitialized = true;
                    }
                }
            }

            return this.BumpTexture;
        }

        bool reflectionTextureInitialized = false;
        public Texture2D GetReflectionTexture()
        {
            if (!reflectionTextureInitialized)
            {
                lock (synObj)
                {
                    if (!reflectionTextureInitialized)
                    {
                        if (!string.IsNullOrEmpty(this.ReflectionFilename))
                        {
                            var texture = new Texture2D();
                            var bitmap = new System.Drawing.Bitmap(this.ReflectionFilename);
                            texture.Initialize(bitmap);
                            this.ReflectionTexture = texture;
                        }

                        reflectionTextureInitialized = true;
                    }
                }
            }

            return this.ReflectionTexture;
        }

        private static readonly object synObj = new object();
        private Texture2D texture;
        private Texture2D BumpTexture;
        private Texture2D ReflectionTexture;
        public string TextureFilename;
        public string BumpFilename;
        public string ReflectionFilename;
    }
}
