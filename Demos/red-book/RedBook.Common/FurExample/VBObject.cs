using CSharpGL;
using GLM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RedBook.Common.FurExample
{
    public class VBObject : IDisposable
    {
        public VBObject()
        {
            //m_vao = 0;
            //m_attribute_buffer = 0;
            //m_index_buffer = 0;
            //m_attrib=0;
            //m_frame=0;
            //m_material=0;
        }

        public bool LoadFromVBM(string filename, int vertexIndex, int normalIndex, int texCoord0Index)
        {
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(f);

            long filesize = f.Length;

            byte[] data = new byte[filesize];
            UnmanagedArray<byte> raw_data;
            f.Read(data, 0, (int)filesize);
            f.Seek(0, SeekOrigin.Begin);

            VBM_HEADER header = br.ReadStruct<VBM_HEADER>();
            VBM_ATTRIB_HEADER attrib_header = br.ReadStruct<VBM_ATTRIB_HEADER>();
            {
                long offset = header.size + header.num_attribs * Marshal.SizeOf(typeof(VBM_ATTRIB_HEADER));
                f.Seek(offset, SeekOrigin.Begin);
            }
            VBM_FRAME_HEADER frame_header = br.ReadStruct<VBM_FRAME_HEADER>();

            uint total_data_size = 0;

            this.m_header = header;

            {
                long offset = header.size;// +header.num_attribs * Marshal.SizeOf(typeof(VBM_ATTRIB_HEADER));
                f.Seek(offset, SeekOrigin.Begin);
            }
            this.m_attrib = new VBM_ATTRIB_HEADER[header.num_attribs];
            for (int i = 0; i < header.num_attribs; i++)
            {
                this.m_attrib[i] = br.ReadStruct<VBM_ATTRIB_HEADER>();
            }

            {
                long offset = header.size + header.num_attribs * Marshal.SizeOf(typeof(VBM_ATTRIB_HEADER));// +header.num_frames * Marshal.SizeOf(typeof(VBM_FRAME_HEADER));
                f.Seek(offset, SeekOrigin.Begin);
            }
            this.m_frame = new VBM_FRAME_HEADER[header.num_frames];
            for (int i = 0; i < header.num_frames; i++)
            {
                this.m_frame[i] = br.ReadStruct<VBM_FRAME_HEADER>();
            }

            GL.GenVertexArrays(1, m_vao);
            GL.BindVertexArray(m_vao[0]);
            GL.GenBuffers(1, m_attribute_buffer);
            GL.BindBuffer(BufferTarget.ArrayBuffer, m_attribute_buffer[0]);

            //uint i;

            for (uint i = 0; i < header.num_attribs; i++)
            {
                total_data_size += m_attrib[i].components * sizeof(float) * header.num_vertices;
            }
            {
                long offset = header.size + header.num_attribs * Marshal.SizeOf(typeof(VBM_ATTRIB_HEADER)) + header.num_frames * Marshal.SizeOf(typeof(VBM_FRAME_HEADER));
                raw_data = new UnmanagedArray<byte>((int)total_data_size);
                for (int i = 0; i < raw_data.Length; i++)
                {
                    raw_data[i] = data[offset + i];
                }
            }
            //GL.BufferData(GL_ARRAY_BUFFER, total_data_size, raw_data, GL_STATIC_DRAW);
            GL.BufferData(BufferTarget.ArrayBuffer, raw_data, BufferUsage.StaticDraw);

            total_data_size = 0;

            for (uint i = 0; i < header.num_attribs; i++)
            {
                uint attribIndex = i;

                if (attribIndex == 0)
                    attribIndex = (uint)vertexIndex;
                else if (attribIndex == 1)
                    attribIndex = (uint)normalIndex;
                else if (attribIndex == 2)
                    attribIndex = (uint)texCoord0Index;

                GL.VertexAttribPointer(attribIndex, (int)m_attrib[i].components, m_attrib[i].type, false, 0, new IntPtr(total_data_size));
                GL.EnableVertexAttribArray(attribIndex);
                total_data_size += m_attrib[i].components * sizeof(float) * header.num_vertices;
            }

            if (header.num_indices > 0)
            {
                GL.GenBuffers(1, m_index_buffer);
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, m_index_buffer[0]);
                uint element_size;
                if (header.indexype == 0x1403)
                {
                    element_size = sizeof(ushort);
                }
                else
                {
                    element_size = sizeof(uint);
                }
                //GL.BufferData(GL_ELEMENT_ARRAY_BUFFER, header.num_indices * element_size, raw_data + total_data_size, GL_STATIC_DRAW);
                UnmanagedArray<byte> tmp = new UnmanagedArray<byte>((int)(header.num_indices * element_size));
                for (int t = 0; t < tmp.Length; t++)
                {
                    tmp[t] = raw_data[(int)(t + total_data_size)];
                }
                GL.BufferData(BufferTarget.ElementArrayBuffer, tmp, BufferUsage.StaticDraw);
                tmp.Dispose();
            }

            GL.BindVertexArray(0);

            raw_data.Dispose();

            return true;
        }

        public bool Free()
        {
            if (m_index_buffer[0] != 0)
            {
                GL.DeleteBuffers(1, m_index_buffer);
            }
            //m_index_buffer = 0;
            if (m_attribute_buffer[0] != 0)
            {
                GL.DeleteBuffers(1, m_attribute_buffer);
            }
            //m_attribute_buffer = 0;
            if (m_vao[0] != 0)
            {
                GL.DeleteVertexArrays(1, m_vao);
            }
            //m_vao = 0;

            //delete[] m_attrib;
            //m_attrib = NULL;

            //delete[] m_frame;
            //m_frame = NULL;

            //delete[] m_material;
            //m_material = NULL;

            return true;
        }

        public void Render(uint frame_index = 0, uint instances = 0)
        {
            //uint t = GetTickCount();

            if (frame_index >= m_header.num_frames)
                return;

            GL.BindVertexArray(m_vao[0]);

            if (instances != 0)
            {
                if (m_header.num_indices != 0)
                    GL.DrawElementsInstanced(GL.GL_TRIANGLES, (int)m_frame[frame_index].count, GL.GL_UNSIGNED_INT, new IntPtr(m_frame[frame_index].first * sizeof(uint)), (int)instances);
                else
                    GL.DrawArraysInstanced(GL.GL_TRIANGLES, (int)m_frame[frame_index].first, (int)m_frame[frame_index].count, (int)instances);
            }
            else
            {
                if (m_header.num_indices != 0)
                    GL.DrawElements(GL.GL_TRIANGLES, (int)m_frame[frame_index].count, GL.GL_UNSIGNED_INT, new IntPtr(m_frame[frame_index].first * sizeof(uint)));
                else
                    GL.DrawArrays(GL.GL_TRIANGLES, (int)m_frame[frame_index].first, (int)m_frame[frame_index].count);
            }

            GL.BindVertexArray(0);
        }

        #region simple functions

        public uint GetAttributeCount()
        {
            return m_header.num_attribs;
        }

        public string GetAttributeName(uint index)
        {
            return index < m_header.num_attribs ? m_attrib[index].name : string.Empty;
        }

        public void BindVertexArray()
        {
            GL.BindVertexArray(m_vao[0]);
        }

        #endregion simple functions

        protected uint[] m_vao = new uint[1];
        protected uint[] m_attribute_buffer = new uint[1];
        protected uint[] m_index_buffer = new uint[1];

        protected VBM_HEADER m_header;
        protected VBM_ATTRIB_HEADER[] m_attrib;
        protected VBM_FRAME_HEADER[] m_frame;

        protected struct material_texture
        {
            public uint diffuse;
            public uint specular;
            public uint normal;
        };

        protected material_texture[] m_material_textures;


        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        } // end sub

        /// <summary>
        /// Destruct instance of the class.
        /// </summary>
        ~VBObject()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Backing field to track whether Dispose has been called.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Dispose managed and unmanaged resources of this instance.
        /// </summary>
        /// <param name="disposing">If disposing equals true, managed and unmanaged resources can be disposed. If disposing equals false, only unmanaged resources can be disposed. </param>
        protected virtual void Dispose(bool disposing)
        {

            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // TODO: Dispose managed resources.
                    Free();
                } // end if

                // TODO: Dispose unmanaged resources.
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion
    }

}
