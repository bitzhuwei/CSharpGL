﻿using bitzhuwei.GLTF2;
using bitzhuwei.GLTFJsonFormat;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace CSharpGL {
    partial class GLTFBufferView {

        private bool disposedValue;
        protected unsafe virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并重写终结器
                var gl = GL.Current;
                if (gl != null) {
                    var name = this.bufferId;
                    gl.glDeleteBuffers(1, &name);
                }
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~GLBufferView()
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