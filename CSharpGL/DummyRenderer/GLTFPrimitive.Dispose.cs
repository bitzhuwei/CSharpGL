using bitzhuwei.GLTF2;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Security.Cryptography;

namespace CSharpGL {
    unsafe partial class GLTFPrimitive {
        private bool disposedValue;
        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并重写终结器
                var gl = CSharpGL.GL.Current;
                if (gl != null) {
                    var name = this.vaoId;
                    gl.glDeleteVertexArrays(1, &name);
                }
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~GLPrimitive()
        // {
        //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        //     Dispose(disposing: false);
        // }

        public void Dispose() {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}