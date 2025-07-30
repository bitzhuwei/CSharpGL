
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe struct VBM_HEADER {
        public uint magic;
        public uint size;
        public fixed byte name[64];
        public uint num_attribs;
        public uint num_frames;
        public uint num_vertices;
        public uint num_indices;
        public uint index_type;
    }

    public unsafe struct VBM_ATTRIB_HEADER {
        public fixed byte name[64];
        public uint type;
        public uint components;
        public uint flags;
    }

    public struct VBM_FRAME_HEADER {
        public uint first;
        public uint count;
        public uint flags;
    }

    public struct VBM_VEC4F {
        public float x;
        public float y;
        public float z;
        public float w;
    }

    public unsafe class VBObject {
        GLuint m_vao;
        GLuint m_attribute_buffer;
        GLuint m_index_buffer;

        VBM_HEADER m_header;
        VBM_ATTRIB_HEADER[] m_attrib;
        VBM_FRAME_HEADER[] m_frame;
        public bool LoadFromVBM(string filename, int vertexIndex, int normalIndex, int texCoord0Index) {
            byte[] data = File.ReadAllBytes(filename);
            fixed (byte* pData = data) {
                var header = (VBM_HEADER*)pData;
                var raw_data = pData + sizeof(VBM_HEADER) + header->num_attribs * sizeof(VBM_ATTRIB_HEADER) + header->num_frames * sizeof(VBM_FRAME_HEADER);
                VBM_ATTRIB_HEADER* attrib_header = (VBM_ATTRIB_HEADER*)(pData + sizeof(VBM_HEADER));
                VBM_FRAME_HEADER* frame_header = (VBM_FRAME_HEADER*)(pData + sizeof(VBM_HEADER) + header->num_attribs * sizeof(VBM_ATTRIB_HEADER));

                m_header = *header;//memcpy(&m_header, header, sizeof(VBM_HEADER));
                m_attrib = new VBM_ATTRIB_HEADER[header->num_attribs];
                //memcpy(m_attrib, attrib_header, header->num_attribs * sizeof(VBM_ATTRIB_HEADER));
                for (int i = 0; i < m_attrib.Length; i++) { m_attrib[i] = attrib_header[i]; }

                m_frame = new VBM_FRAME_HEADER[header->num_frames];
                //memcpy(m_frame, frame_header, header->num_frames * sizeof(VBM_FRAME_HEADER));
                for (int i = 0; i < m_frame.Length; i++) { m_frame[i] = frame_header[i]; }

                var gl = GL.Current; if (gl == null) { return false; }
                var vao = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, vao); this.m_vao = vao[0];
                gl.glBindVertexArray(vao[0]);
                var buffer = stackalloc GLuint[1];
                gl.glGenBuffers(1, buffer); this.m_attribute_buffer = buffer[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, buffer[0]);


                uint total_data_size = 0;
                for (var i = 0; i < header->num_attribs; i++) {
                    int attribIndex = i;

                    if (attribIndex == 0) attribIndex = vertexIndex;
                    else if (attribIndex == 1) attribIndex = normalIndex;
                    else if (attribIndex == 2) attribIndex = texCoord0Index;
                    //if (0 <= attribIndex && attribIndex <= 2) {
                    gl.glVertexAttribPointer((uint)attribIndex, (int)m_attrib[i].components, m_attrib[i].type, false, 0, (IntPtr)total_data_size);
                    gl.glEnableVertexAttribArray((uint)attribIndex);
                    //}
                    total_data_size += m_attrib[i].components * sizeof(GLfloat) * header->num_vertices;
                }

                gl.glBufferData(GL.GL_ARRAY_BUFFER, (int)total_data_size, (IntPtr)raw_data, GL.GL_STATIC_DRAW);

                if (header->num_indices != 0) {
                    var indexBuffer = stackalloc GLuint[1];
                    gl.glGenBuffers(1, indexBuffer); this.m_index_buffer = indexBuffer[0];
                    gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, indexBuffer[0]);
                    uint element_size;
                    switch (header->index_type) {
                    case GL.GL_UNSIGNED_BYTE: element_size = sizeof(GLubyte); break;
                    case GL.GL_UNSIGNED_SHORT: element_size = sizeof(GLushort); break;
                    default: element_size = sizeof(GLuint); break;
                    }
                    gl.glBufferData(GL.GL_ELEMENT_ARRAY_BUFFER,
                        (int)(header->num_indices * element_size), (IntPtr)(pData + total_data_size), GL.GL_STATIC_DRAW);
                }

                gl.glBindVertexArray(0);
            }

            return true;
        }

        public void Render(uint frame_index = 0, uint instances = 0) {
            if (frame_index >= m_header.num_frames) return;

            var gl = GL.Current; if (gl == null) { return; }

            gl.glBindVertexArray(m_vao);
            if (instances != 0) {
                if (m_header.num_indices != 0)
                    gl.glDrawElementsInstanced(GL.GL_TRIANGLES, (int)m_frame[frame_index].count, GL.GL_UNSIGNED_INT,
                        (IntPtr)(m_frame[frame_index].first * sizeof(GLuint)), (int)instances);
                else
                    gl.glDrawArraysInstanced(GL.GL_TRIANGLES, (int)m_frame[frame_index].first,
                        (int)m_frame[frame_index].count, (int)instances);
            }
            else {
                if (m_header.num_indices != 0)
                    gl.glDrawElements(GL.GL_TRIANGLES, (int)m_frame[frame_index].count, GL.GL_UNSIGNED_INT,
                        (IntPtr)(m_frame[frame_index].first * sizeof(GLuint)));
                else
                    gl.glDrawArrays(GL.GL_TRIANGLES, (int)m_frame[frame_index].first, (int)m_frame[frame_index].count);
            }
            gl.glBindVertexArray(0);
        }
        public bool Free() {
            var gl = GL.Current; if (gl == null) { return false; }

            var id = m_index_buffer;
            gl.glDeleteBuffers(1, &id);
            m_index_buffer = 0;
            id = m_attribute_buffer;
            gl.glDeleteBuffers(1, &id);
            m_attribute_buffer = 0;
            id = m_vao;
            gl.glDeleteVertexArrays(1, &id);
            m_vao = 0;

            //delete[] m_attrib;
            //m_attrib = NULL;

            //delete[] m_frame;
            //m_frame = NULL;

            return true;
        }

        public uint GetVertexCount(uint frame = 0) {
            return frame < m_header.num_frames ? m_frame[frame].count : 0;
        }

        public uint GetAttributeCount() {
            return m_header.num_attribs;
        }

        public string GetAttributeName(uint index) {
            //return index < m_header.num_attribs ? m_attrib[index].name : 0;
            if (index < m_header.num_attribs) {
                fixed (byte* p = m_attrib[index].name) {
                    var result = Marshal.PtrToStringAnsi((IntPtr)p);
                    if (result != null) { return result; }
                    else { return ""; }
                }
            }
            else { return ""; }
        }

        public void BindVertexArray(GL gl) {
            gl.glBindVertexArray(m_vao);
        }

        ~VBObject() {
            Free();
        }
    }
}