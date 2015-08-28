using CSharpGL;
using CSharpGL.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadBook.Common
{
    public class VBObject
    {


        #region simple functions

        public uint GetVertexCount(uint frame = 0)
        {
            return frame < m_header.num_frames ? m_frame[frame].count : 0;
        }

        public uint GetAttributeCount()
        {
            return m_header.num_attribs;
        }

        public string GetAttributeName(uint index)
        {
            return index < m_header.num_attribs ? m_attrib[index].name : string.Empty;
        }

        public uint GetFrameCount()
        {
            return m_header.num_frames;
        }

        public uint GetMaterialCount()
        {
            return m_header.num_materials;
        }

        public string GetMaterialName(uint material_index)
        {
            return m_material[material_index].name;
        }

        public vec3 GetMaterialAmbient(uint material_index)
        {
            return new vec3(m_material[material_index].ambient.x, m_material[material_index].ambient.y, m_material[material_index].ambient.z);
        }

        public vec3 GetMaterialDiffuse(uint material_index)
        {
            return new vec3(m_material[material_index].diffuse.x, m_material[material_index].diffuse.y, m_material[material_index].diffuse.z);
        }

        public string GetMaterialDiffuseMapName(uint material_index)
        {
            return m_material[material_index].diffuse_map;
        }

        public string GetMaterialSpecularMapName(uint material_index)
        {
            return m_material[material_index].specular_map;
        }

        public string GetMaterialNormalMapName(uint material_index)
        {
            return m_material[material_index].normal_map;
        }

        public void SetMaterialDiffuseTexture(uint material_index, uint texname)
        {
            m_material_textures[material_index].diffuse = texname;
        }

        public void SetMaterialSpecularTexture(uint material_index, uint texname)
        {
            m_material_textures[material_index].specular = texname;
        }

        public void SetMaterialNormalTexture(uint material_index, uint texname)
        {
            m_material_textures[material_index].normal = texname;
        }

        public void BindVertexArray()
        {
            GL.BindVertexArray(m_vao);
        }

        #endregion simple functions

        protected uint m_vao;
        protected uint m_attribute_buffer;
        protected uint m_index_buffer;

        protected VBM_HEADER m_header;
        protected VBM_ATTRIB_HEADER[] m_attrib;
        protected VBM_FRAME_HEADER[] m_frame;
        protected VBM_MATERIAL[] m_material;
        protected VBM_RENDER_CHUNK m_chunks;

        protected struct material_texture
        {
            public uint diffuse;
            public uint specular;
            public uint normal;
        };

        protected material_texture[] m_material_textures;
    }
}
