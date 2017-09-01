using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace _3DTextureSlicing
{
    class VolumeDataLoader
    {

        //dimensions of volume data
        const int XDIM = 256;
        const int YDIM = 256;
        const int ZDIM = 256;
        private const string volume_file = "Engine256.raw";

        /// <summary>
        /// load a volume from the given raw data file and generates an OpenGL 3D texture from it
        /// </summary>
        /// <returns></returns>
        public static Texture LoadData()
        {
            var bytes = new byte[XDIM * YDIM * ZDIM];
            // read the volume data file
            using (var file = new System.IO.FileStream(volume_file, System.IO.FileMode.Open))
            {
                file.Read(bytes, 0, bytes.Length);
            }

            // generate OpenGL texture
            var dataProvider = new ByteDataProvider(bytes);
            var storage = new TexImage3D(TexImage3D.Target.Texture3D, 0, GL.GL_RED, XDIM, YDIM, ZDIM, 0, GL.GL_RED, GL.GL_UNSIGNED_BYTE, dataProvider);
            var texture = new Texture(
              TextureTarget.Texture3D, storage, new MipmapBuilder(),
              new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP),
              new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
              new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
              new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR_MIPMAP_LINEAR),
              new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR),
              new TexParameteri(TexParameter.PropertyName.TextrueBaseLevel, 0),
              new TexParameteri(TexParameter.PropertyName.TextureMaxLevel, 4));
            texture.Initialize();

            return texture;
        }

        class ByteDataProvider : LeveledDataProvider
        {
            private byte[] data;

            public ByteDataProvider(byte[] data)
            {
                this.data = data;
            }
            public override IEnumerator<LeveledData> GetEnumerator()
            {
                yield return new ByteData(this.data);
            }
        }

        class ByteData : LeveledData
        {
            private byte[] data;
            private GCHandle pinned;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="data"></param>
            public ByteData(byte[] data)
            {
                this.data = data;
            }

            public override IntPtr LockData()
            {
                this.pinned = GCHandle.Alloc(this.data, GCHandleType.Pinned);
                IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(this.data, 0);
                return header;
                //GL.Instance.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);
                //GL.Instance.TexImage1D((uint)TextureTarget.Texture1D, 0, GL.GL_RGBA8, this.width, 0, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, header);
            }

            public override void FreeData()
            {
                this.pinned.Free();
            }
        }
    }
}
