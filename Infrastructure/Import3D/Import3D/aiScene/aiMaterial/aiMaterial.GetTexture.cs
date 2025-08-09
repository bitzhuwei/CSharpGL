
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Import3D {
    unsafe partial class aiMaterial {

        public aiReturn GetTexture(int type,
                                   int index,
                                   out string path,
                                   aiTextureMapping* mapping = null,
                                   int* uvindex = null,
                                   float* blend = null,
                                   aiTextureOp* op = null,
                                   aiTextureMapMode* mapmode = null) {
            return aiGetMaterialTexture(this, type, index, out path, mapping, uvindex, blend, op, mapmode);
        }

        private static aiReturn aiGetMaterialTexture(
            aiMaterial material, int type, int index, out string path,
            aiTextureMapping* _mapping, int* uvindex, float* blend, aiTextureOp* op, aiTextureMapMode* mapmode, int* flags = null) {
            Debug.Assert(null != material);
            //Debug.Assert(null != path);

            // Get the path to the texture
            if (aiReturn.aiReturn_SUCCESS != aiGetMaterialString(material, /*AI_MATKEY_TEXTURE(type, index)*/"$tex.mapping", type, index, out path)) {
                return aiReturn.aiReturn_FAILURE;
            }

            // Determine mapping type
            int mapping_ = (int)aiTextureMapping.aiTextureMapping_UV;
            material.aiGetMaterialInteger(/*AI_MATKEY_MAPPING(type, index)*/"$tex.mapping", type, index, &mapping_);
            var mapping = (aiTextureMapping)(mapping_);
            if (_mapping != null)
                _mapping[0] = mapping;

            // Get UV index
            if (aiTextureMapping.aiTextureMapping_UV == mapping && uvindex != null) {
                material.aiGetMaterialInteger(/*AI_MATKEY_UVWSRC(type, index)*/"$tex.uvwsrc", type, index, uvindex);
            }
            // Get blend factor
            if (blend != null) {
                material.aiGetMaterialFloat(/*AI_MATKEY_TEXBLEND(type, index)*/"$tex.blend", type, index, blend);
            }
            // Get texture operation
            if (op != null) {
                material.aiGetMaterialInteger(/*AI_MATKEY_TEXOP(type, index)*/"$tex.op", type, index, (int*)op);
            }
            // Get texture mapping modes
            if (mapmode != null) {
                material.aiGetMaterialInteger(/*AI_MATKEY_MAPPINGMODE_U(type, index)*/"$tex.mapmodeu", type, index, (int*)&mapmode[0]);
                material.aiGetMaterialInteger(/*AI_MATKEY_MAPPINGMODE_V(type, index)*/"$tex.mapmodev", type, index, (int*)&mapmode[1]);
            }
            // Get texture flags
            if (flags != null) {
                material.aiGetMaterialInteger(/*AI_MATKEY_TEXFLAGS(type, index)*/"$tex.flags", type, index, (int*)flags);
            }

            return aiReturn.aiReturn_SUCCESS;

        }
    }
}