using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RaycastVolumeRendering
{
    public partial class RaycastNode
    {
        private Texture transferFunc1DTexture;
        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.transferFunc1DTexture = InitTFF1DTexture(@"tff.dat");

        }

        private Texture InitTFF1DTexture(string filename)
        {
            byte[] tff;
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var br = new BinaryReader(fs))
            {
                tff = br.ReadBytes((int)fs.Length);
            }

            const int width = 256;
            var storage = new TexImage1D(0, GL.GL_RGBA8, width, 0, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, new ByteDataProvider(tff));
            var texture = new Texture(
                TextureTarget.Texture1D, storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST));
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
            private int width;
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
