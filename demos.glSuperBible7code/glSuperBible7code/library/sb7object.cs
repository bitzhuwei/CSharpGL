using CSharpGL;
using System;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace demos.glSuperBible7code {
    struct SB6M_SUB_OBJECT_DECL {
        public uint first;
        public uint count;
    }
    [StructLayout(LayoutKind.Explicit)]
    unsafe struct SB6M_HEADER {
        [FieldOffset(0)]
        public uint magic;
        [FieldOffset(0)]
        public fixed byte magic_name[4];
        [FieldOffset(sizeof(uint))]
        public uint size;
        [FieldOffset(sizeof(uint) * 2)]
        public uint num_chunks;
        [FieldOffset(sizeof(uint) * 3)]
        public uint flags;
    }
    unsafe struct SB6M_VERTEX_ATTRIB_CHUNK {
        public SB6M_CHUNK_HEADER header;
        public uint attrib_count;
        public SB6M_VERTEX_ATTRIB_DECL attrib_data;
        //public IntPtr attrib_data;
    }
    [StructLayout(LayoutKind.Explicit)]
    unsafe struct SB6M_CHUNK_HEADER {
        [FieldOffset(0)]
        public uint chunk_type;
        [FieldOffset(0)]
        public fixed byte chunk_name[4];
        [FieldOffset(sizeof(uint))]
        public uint size;
    }

    unsafe struct SB6M_VERTEX_ATTRIB_DECL {
        public fixed byte name[64];
        public uint size;
        public uint type;
        public uint stride;
        public uint flags;
        public uint data_offset;
    }
    struct SB6M_CHUNK_VERTEX_DATA {
        public SB6M_CHUNK_HEADER header;
        public uint data_size;
        public uint data_offset;
        public uint total_vertices;
    }
    struct SB6M_CHUNK_INDEX_DATA {
        public SB6M_CHUNK_HEADER header;
        public uint index_type;
        public uint index_count;
        public uint index_data_offset;
    }
    unsafe struct SB6M_CHUNK_SUB_OBJECT_LIST {
        public SB6M_CHUNK_HEADER header;
        public uint count;
        public SB6M_SUB_OBJECT_DECL sub_object;
        //public IntPtr sub_object;
    }
    struct SB6M_DATA_CHUNK {
        public SB6M_CHUNK_HEADER header;
        public uint encoding;
        public uint data_offset;
        public uint data_length;
    }


    public unsafe class sb7object {
        const uint SB6M_CHUNK_TYPE_INDEX_DATA = (((uint)('I') << 0) | ((uint)('N') << 8) | ((uint)('D') << 16) | ((uint)('X') << 24));
        const uint SB6M_CHUNK_TYPE_VERTEX_DATA = (((uint)('V') << 0) | ((uint)('R') << 8) | ((uint)('T') << 16) | ((uint)('X') << 24));
        const uint SB6M_CHUNK_TYPE_VERTEX_ATTRIBS = (((uint)('A') << 0) | ((uint)('T') << 8) | ((uint)('R') << 16) | ((uint)('B') << 24));
        const uint SB6M_CHUNK_TYPE_SUB_OBJECT_LIST = (((uint)('O') << 0) | ((uint)('L') << 8) | ((uint)('S') << 16) | ((uint)('T') << 24));
        const uint SB6M_CHUNK_TYPE_COMMENT = (((uint)('C') << 0) | ((uint)('M') << 8) | ((uint)('N') << 16) | ((uint)('T') << 24));
        const uint SB6M_CHUNK_TYPE_DATA = (((uint)('D') << 0) | ((uint)('A') << 8) | ((uint)('T') << 16) | ((uint)('A') << 24));

        const int SB6M_VERTEX_ATTRIB_FLAG_NORMALIZED = 0x00000001;
        const int SB6M_VERTEX_ATTRIB_FLAG_INTEGER = 0x00000002;

        GLuint data_buffer;
        GLuint vao;
        GLuint index_type;
        GLuint index_offset;

        const int MAX_SUB_OBJECTS = 256;

        uint num_sub_objects;
        SB6M_SUB_OBJECT_DECL* sub_object = (SB6M_SUB_OBJECT_DECL*)Marshal.AllocHGlobal(sizeof(SB6M_SUB_OBJECT_DECL) * MAX_SUB_OBJECTS);

        public void render(uint instance_count = 1,
                uint base_instance = 0) {
            render_sub_object(0, instance_count, base_instance);
        }

        public void render_sub_object(uint object_index,
            uint instance_count = 1,
            uint base_instance = 0) {
            var gl = GL.Current; if (gl == null) return;

            gl.glBindVertexArray(vao);

            if (index_type != GL.GL_NONE) {
                gl.glDrawElementsInstancedBaseInstance(GL.GL_TRIANGLES,
                    (int)sub_object[object_index].count,
                    index_type,
                    (IntPtr)sub_object[object_index].first,
                    (int)instance_count,
                    base_instance);
            }
            else {
                gl.glDrawArraysInstancedBaseInstance(GL.GL_TRIANGLES,
                    (int)sub_object[object_index].first,
                    (int)sub_object[object_index].count,
                    (int)instance_count,
                    base_instance);
            }
        }

        public void get_sub_object_info(uint index, GLuint* first, GLuint* count) {
            if (index >= num_sub_objects) {
                first = null;
                count = null;
            }
            else {
                *first = (sub_object[index].first);
                *count = (sub_object[index].count);
            }
        }

        public uint get_sub_object_count() { return num_sub_objects; }
        public GLuint get_vao() { return vao; }
        public void load(string filename) {
            this.free();

            using (var reader = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
                var filesize = reader.Length;
                var data = new byte[filesize];
                reader.Read(data, 0, (int)filesize);
                fixed (byte* p = data) {
                    var ptr = p;
                    var header = (SB6M_HEADER*)ptr;
                    ptr += header->size;
                    SB6M_VERTEX_ATTRIB_CHUNK* vertex_attrib_chunk = null;
                    SB6M_CHUNK_VERTEX_DATA* vertex_data_chunk = null;
                    SB6M_CHUNK_INDEX_DATA* index_data_chunk = null;
                    SB6M_CHUNK_SUB_OBJECT_LIST* sub_object_chunk = null;
                    SB6M_DATA_CHUNK* data_chunk = null;
                    for (var i = 0; i < header->num_chunks; i++) {
                        SB6M_CHUNK_HEADER* chunk = (SB6M_CHUNK_HEADER*)ptr;
                        ptr += chunk->size;
                        switch (chunk->chunk_type) {
                        case SB6M_CHUNK_TYPE_VERTEX_ATTRIBS:
                        vertex_attrib_chunk = (SB6M_VERTEX_ATTRIB_CHUNK*)chunk;
                        break;
                        case SB6M_CHUNK_TYPE_VERTEX_DATA:
                        vertex_data_chunk = (SB6M_CHUNK_VERTEX_DATA*)chunk;
                        break;
                        case SB6M_CHUNK_TYPE_INDEX_DATA:
                        index_data_chunk = (SB6M_CHUNK_INDEX_DATA*)chunk;
                        break;
                        case SB6M_CHUNK_TYPE_SUB_OBJECT_LIST:
                        sub_object_chunk = (SB6M_CHUNK_SUB_OBJECT_LIST*)chunk;
                        break;
                        case SB6M_CHUNK_TYPE_DATA:
                        data_chunk = (SB6M_DATA_CHUNK*)chunk;
                        break;
                        default:
                        break; // goto failed;
                        }
                    }

                    // failed:
                    var gl = GL.Current; if (gl == null) { return; }
                    var id = stackalloc GLuint[1];
                    gl.glGenVertexArrays(1, id); vao = id[0];
                    gl.glBindVertexArray(vao);

                    if (data_chunk != null) {
                        gl.glGenBuffers(1, id); data_buffer = id[0];
                        gl.glBindBuffer(GL.GL_ARRAY_BUFFER, data_buffer);
                        gl.glBufferData(GL.GL_ARRAY_BUFFER,
                            (int)data_chunk->data_length, (IntPtr)(data_chunk + data_chunk->data_offset), GL.GL_STATIC_DRAW);
                    }
                    else {
                        uint data_size = 0;
                        uint size_used = 0;

                        if (vertex_data_chunk != null) {
                            data_size += vertex_data_chunk->data_size;
                        }

                        if (index_data_chunk != null) {
                            data_size += (uint)(index_data_chunk->index_count * (index_data_chunk->index_type == GL.GL_UNSIGNED_SHORT ? sizeof(GLushort) : sizeof(GLubyte)));
                        }

                        gl.glGenBuffers(1, id); data_buffer = id[0];
                        gl.glBindBuffer(GL.GL_ARRAY_BUFFER, data_buffer);
                        gl.glBufferData(GL.GL_ARRAY_BUFFER, (int)data_size, IntPtr.Zero, GL.GL_STATIC_DRAW);

                        if (vertex_data_chunk != null) {
                            gl.glBufferSubData(GL.GL_ARRAY_BUFFER, 0,
                                (int)vertex_data_chunk->data_size, (IntPtr)(p + vertex_data_chunk->data_offset));
                            size_used += vertex_data_chunk->data_offset;
                        }

                        if (index_data_chunk != null) {
                            gl.glBufferSubData(GL.GL_ARRAY_BUFFER,
                                (int)size_used,
                                (int)(index_data_chunk->index_count * (index_data_chunk->index_type == GL.GL_UNSIGNED_SHORT ? sizeof(GLushort) : sizeof(GLubyte))),
                                (IntPtr)(p + index_data_chunk->index_data_offset));
                        }
                    }

                    for (uint i = 0; i < vertex_attrib_chunk->attrib_count; i++) {
                        var pData = &vertex_attrib_chunk->attrib_data;
                        var attrib_decl = pData[i]; // (&(vertex_attrib_chunk->attrib_data))[i];
                        gl.glVertexAttribPointer(i,
                            (int)attrib_decl.size,
                            attrib_decl.type,
                            (attrib_decl.flags & SB6M_VERTEX_ATTRIB_FLAG_NORMALIZED) != 0,
                            (int)attrib_decl.stride,
                            (IntPtr)attrib_decl.data_offset);
                        gl.glEnableVertexAttribArray(i);
                    }

                    if (index_data_chunk != null) {
                        gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, data_buffer);
                        index_type = index_data_chunk->index_type;
                        index_offset = index_data_chunk->index_data_offset;
                    }
                    else { index_type = GL.GL_NONE; }

                    if (sub_object_chunk != null) {
                        if (sub_object_chunk->count > MAX_SUB_OBJECTS) {
                            sub_object_chunk->count = MAX_SUB_OBJECTS;
                        }

                        for (var i = 0; i < sub_object_chunk->count; i++) {
                            var pData = &sub_object_chunk->sub_object;
                            sub_object[i] = pData[i]; // sub_object_chunk->sub_object[i];
                        }

                        num_sub_objects = sub_object_chunk->count;
                    }
                    else {
                        sub_object[0].first = 0;
                        sub_object[0].count = index_type != GL.GL_NONE ? index_data_chunk->index_count : vertex_data_chunk->total_vertices;
                        num_sub_objects = 1;
                    }

                    gl.glBindVertexArray(0);
                    gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, 0);
                }
            }
        }

        public void free() {
            var gl = GL.Current; if (gl == null) return;

            var id = get_vao();
            gl.glDeleteVertexArrays(1, &id);
            id = data_buffer;
            gl.glDeleteBuffers(1, &id);

            vao = 0;
            data_buffer = 0;
        }
    }
}
