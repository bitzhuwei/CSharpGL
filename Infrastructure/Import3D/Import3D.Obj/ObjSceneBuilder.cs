using Import3D;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Import3D.Obj {
    public unsafe class ObjSceneBuilder {
        public static void BuildScene(ObjFileModel model, aiScene scene) {
            scene.mRootNode = new aiNode(model.modelName);
            if (model.objects.Count > 0) {
                int meshCount = 0;
                int childCount = 0;

                foreach (var item in model.objects) {
                    if (item != null) {
                        ++childCount;
                        meshCount += item.meshes.Count;
                    }
                }

                // Allocate space for the child nodes on the root node
                scene.mRootNode.mChildren = new aiNode[childCount];

                // Create nodes for the whole scene
                var MeshArray = new List<aiMesh>(meshCount);
                for (int index = 0; index < model.objects.Count; index++) {
                    CreateNodes(model, model.objects[index], scene.mRootNode, scene, MeshArray);
                }

                Debug.Assert(scene.mRootNode.mNumChildren == childCount);

                // Create mesh pointer buffer for this scene
                if (scene.mNumMeshes > 0) {
                    scene.mMeshes = MeshArray.ToArray();
                }

                // Create all materials
                CreateMaterials(model, scene);
            }
            else {
                if (model.mVertices.Count == 0) { return; }

                var mesh = new aiMesh();
                mesh.mPrimitiveTypes = aiPrimitiveType.aiPrimitiveType_POINT;
                var n = model.mVertices.Count;
                mesh.mNumVertices = n;

                mesh.mVertices = model.mVertices.ToArray();

                if (model.mNormals.Count > 0) {
                    if (model.mNormals.Count < n) {
                        throw new Exception("OBJ: vertex normal index out of range");
                    }
                    mesh.mNormals = model.mNormals.ToArray();
                }

                if (model.mVertexColors.Count > 0) {
                    mesh.mColors[0] = new vec4[mesh.mNumVertices];
                    for (int i = 0; i < n; ++i) {
                        if (i < model.mVertexColors.Count) {
                            var color = model.mVertexColors[i];
                            mesh.mColors[0][i] = new vec4(color.x, color.y, color.z, 1.0f);
                        }
                        else {
                            throw new Exception("OBJ: vertex color index out of range");
                        }
                    }
                }

                scene.mRootNode.mNumMeshes = 1;
                scene.mRootNode.mMeshes = new uint[1];
                scene.mRootNode.mMeshes[0] = 0;
                scene.mNumMeshes = 1;
                scene.mMeshes = new aiMesh[1];
                scene.mMeshes[0] = mesh;
            }
        }

        private static void CreateMaterials(ObjFileModel model, aiScene scene) {
            if (null == scene) { return; }

            uint numMaterials = (uint)model.materialLib.Count;
            scene.mNumMaterials = 0;
            if (numMaterials == 0) {
                Log.WriteLine("OBJ: no materials specified");
                return;
            }

            scene.mMaterials = new aiMaterial[numMaterials];
            for (var matIndex = 0; matIndex < numMaterials; matIndex++) {
                // Store material name
                if (!model.materialMap.TryGetValue(model.materialLib[matIndex], out var material)) {
                    // No material found, use the default material
                    continue;
                }
                else {
                    var mat = new aiMaterial();
                    var pCurrentMaterial = material;
                    mat.AddProperty(pCurrentMaterial.materialName, /*AI_MATKEY_NAME*/"?mat.name", 0, 0);

                    // convert illumination model
                    aiShadingMode sm = 0;
                    switch (pCurrentMaterial.illumination_model) {
                    case 0:
                    sm = aiShadingMode.aiShadingMode_NoShading;
                    break;
                    case 1:
                    sm = aiShadingMode.aiShadingMode_Gouraud;
                    break;
                    case 2:
                    sm = aiShadingMode.aiShadingMode_Phong;
                    break;
                    default:
                    sm = aiShadingMode.aiShadingMode_Gouraud;
                    Log.WriteLine("OBJ: unexpected illumination model (0-2 recognized)");
                    break;
                    }

                    mat.AddProperty((int)sm, 1, /*AI_MATKEY_SHADING_MODEL*/"$mat.shadingm", 0, 0);

                    // Preserve the original illum value
                    mat.AddProperty(pCurrentMaterial.illumination_model, 1, /*AI_MATKEY_OBJ_ILLUM*/"$mat.illum", 0, 0);

                    // Adding material colors
                    mat.AddProperty(pCurrentMaterial.ambient, 1, /*AI_MATKEY_COLOR_AMBIENT*/"$clr.ambient", 0, 0);
                    mat.AddProperty(pCurrentMaterial.diffuse, 1, /*AI_MATKEY_COLOR_DIFFUSE*/"$clr.diffuse", 0, 0);
                    mat.AddProperty(pCurrentMaterial.specular, 1, /*AI_MATKEY_COLOR_SPECULAR*/"$clr.specular", 0, 0);
                    mat.AddProperty(pCurrentMaterial.emissive, 1, /*AI_MATKEY_COLOR_EMISSIVE*/"$clr.emissive", 0, 0);
                    mat.AddProperty(pCurrentMaterial.shineness, 1, /*AI_MATKEY_SHININESS*/"$mat.shininess", 0, 0);
                    mat.AddProperty(pCurrentMaterial.alpha, 1, /*AI_MATKEY_OPACITY*/"$mat.opacity", 0, 0);
                    mat.AddProperty(pCurrentMaterial.transparent, 1, /*AI_MATKEY_COLOR_TRANSPARENT*/"$clr.transparent", 0, 0);
                    if (pCurrentMaterial.roughness.HasValue)
                        mat.AddProperty(pCurrentMaterial.roughness.Value, 1, /*AI_MATKEY_ROUGHNESS_FACTOR*/"$mat.roughnessFactor", 0, 0);
                    if (pCurrentMaterial.metallic.HasValue)
                        mat.AddProperty(pCurrentMaterial.metallic.Value, 1, /*AI_MATKEY_METALLIC_FACTOR*/"$mat.metallicFactor", 0, 0);
                    if (pCurrentMaterial.sheen.HasValue)
                        mat.AddProperty(pCurrentMaterial.sheen.Value, 1, /*AI_MATKEY_SHEEN_COLOR_FACTOR*/"$clr.sheen.factor", 0, 0);
                    if (pCurrentMaterial.clearcoat_thickness.HasValue)
                        mat.AddProperty(pCurrentMaterial.clearcoat_thickness.Value, 1, /*AI_MATKEY_CLEARCOAT_FACTOR*/"$mat.clearcoat.factor", 0, 0);
                    if (pCurrentMaterial.clearcoat_roughness.HasValue)
                        mat.AddProperty(pCurrentMaterial.clearcoat_roughness.Value, 1, /*AI_MATKEY_CLEARCOAT_ROUGHNESS_FACTOR*/"$mat.clearcoat.roughnessFactor", 0, 0);
                    mat.AddProperty(pCurrentMaterial.anisotropy, 1, /*AI_MATKEY_ANISOTROPY_FACTOR*/"$mat.anisotropyFactor", 0, 0);

                    // Adding refraction index
                    mat.AddProperty(pCurrentMaterial.ior, 1, /*AI_MATKEY_REFRACTI*/"$mat.refracti", 0, 0);

                    // Adding textures
                    const int uvwIndex = 0;

                    if (pCurrentMaterial.texture != null) {
                        mat.AddProperty(pCurrentMaterial.texture, /*AI_MATKEY_TEXTURE_DIFFUSE(0)*/"$tex.file", (int)aiTextureType.aiTextureType_DIFFUSE, 0);
                        mat.AddProperty(uvwIndex, 1, /*AI_MATKEY_UVWSRC_DIFFUSE(0)*/"$tex.uvwsrc", (int)aiTextureType.aiTextureType_DIFFUSE, 0);
                        if (pCurrentMaterial.clamp[(int)ObjMaterial.TextureType.TextureDiffuseType]) {
                            addTextureMappingModeProperty(mat, aiTextureType.aiTextureType_DIFFUSE);
                        }
                    }

                    if (pCurrentMaterial.textureAmbient != null) {
                        mat.AddProperty(pCurrentMaterial.textureAmbient, /*AI_MATKEY_TEXTURE_AMBIENT(0)*/"$tex.file", (int)aiTextureType.aiTextureType_AMBIENT, 0);
                        mat.AddProperty(uvwIndex, 1, /*AI_MATKEY_UVWSRC_AMBIENT(0)*/"$tex.uvwsrc", (int)aiTextureType.aiTextureType_AMBIENT, 0);
                        if (pCurrentMaterial.clamp[(int)ObjMaterial.TextureType.TextureAmbientType]) {
                            addTextureMappingModeProperty(mat, aiTextureType.aiTextureType_AMBIENT);
                        }
                    }

                    if (pCurrentMaterial.textureEmissive != null) {
                        mat.AddProperty(pCurrentMaterial.textureEmissive, /*AI_MATKEY_TEXTURE_EMISSIVE(0)*/"$tex.file", (int)aiTextureType.aiTextureType_EMISSIVE, 0);
                        mat.AddProperty(uvwIndex, 1, /*AI_MATKEY_UVWSRC_EMISSIVE(0)*/"$tex.uvwsrc", (int)aiTextureType.aiTextureType_EMISSIVE, 0);
                    }

                    if (pCurrentMaterial.textureSpecular != null) {
                        mat.AddProperty(pCurrentMaterial.textureSpecular, /*AI_MATKEY_TEXTURE_SPECULAR(0)*/"$tex.file", (int)aiTextureType.aiTextureType_SPECULAR, 0);
                        mat.AddProperty(uvwIndex, 1, /*AI_MATKEY_UVWSRC_SPECULAR(0)*/"$tex.uvwsrc", (int)aiTextureType.aiTextureType_SPECULAR, 0);
                        if (pCurrentMaterial.clamp[(int)ObjMaterial.TextureType.TextureSpecularType]) {
                            addTextureMappingModeProperty(mat, aiTextureType.aiTextureType_SPECULAR);
                        }
                    }

                    if (pCurrentMaterial.textureBump != null) {
                        mat.AddProperty(pCurrentMaterial.textureBump, /*AI_MATKEY_TEXTURE_HEIGHT(0)*/"$tex.file", (int)aiTextureType.aiTextureType_HEIGHT, 0);
                        mat.AddProperty(uvwIndex, 1, /*AI_MATKEY_UVWSRC_HEIGHT(0)*/"$tex.uvwsrc", (int)aiTextureType.aiTextureType_HEIGHT, 0);
                        if (pCurrentMaterial.bump_multiplier != 1.0) {
                            mat.AddProperty(pCurrentMaterial.bump_multiplier, 1, /*AI_MATKEY_OBJ_BUMPMULT_HEIGHT(0)*/"$tex.bumpmult", (int)aiTextureType.aiTextureType_HEIGHT, 0);
                        }
                        if (pCurrentMaterial.clamp[(int)ObjMaterial.TextureType.TextureBumpType]) {
                            addTextureMappingModeProperty(mat, aiTextureType.aiTextureType_HEIGHT);
                        }
                    }

                    if (pCurrentMaterial.textureNormal != null) {
                        mat.AddProperty(pCurrentMaterial.textureNormal, /*AI_MATKEY_TEXTURE_NORMALS(0)*/"$tex.file", (int)aiTextureType.aiTextureType_NORMALS, 0);
                        mat.AddProperty(uvwIndex, 1, /*AI_MATKEY_UVWSRC_NORMALS(0)*/"$tex.uvwsrc", (int)aiTextureType.aiTextureType_NORMALS, 0);
                        if (pCurrentMaterial.bump_multiplier != 1.0) {
                            mat.AddProperty(pCurrentMaterial.bump_multiplier, 1, /*AI_MATKEY_OBJ_BUMPMULT_NORMALS(0)*/"$tex.bumpmult", (int)aiTextureType.aiTextureType_NORMALS, 0);
                        }
                        if (pCurrentMaterial.clamp[(int)ObjMaterial.TextureType.TextureNormalType]) {
                            addTextureMappingModeProperty(mat, aiTextureType.aiTextureType_NORMALS);
                        }
                    }

                    if (pCurrentMaterial.textureReflection[0] != null) {
                        ObjMaterial.TextureType type = pCurrentMaterial.textureReflection[1] != null ?
                            ObjMaterial.TextureType.TextureReflectionCubeTopType :
                            ObjMaterial.TextureType.TextureReflectionSphereType;

                        var count = type == ObjMaterial.TextureType.TextureReflectionSphereType ? 1 : 6;
                        for (var i = 0; i < count; i++) {
                            mat.AddProperty(pCurrentMaterial.textureReflection[i], /*AI_MATKEY_TEXTURE_REFLECTION(i)*/"$tex.file", (int)aiTextureType.aiTextureType_REFLECTION, i);
                            mat.AddProperty(uvwIndex, 1, /*AI_MATKEY_UVWSRC_REFLECTION(i)*/"$tex.uvwsrc", (int)aiTextureType.aiTextureType_REFLECTION, i);

                            if (pCurrentMaterial.clamp[(int)type])
                                addTextureMappingModeProperty(mat, aiTextureType.aiTextureType_REFLECTION, 1, i);
                        }
                    }

                    if (pCurrentMaterial.textureDisp != null) {
                        mat.AddProperty(pCurrentMaterial.textureDisp, /*AI_MATKEY_TEXTURE_DISPLACEMENT(0)*/"$tex.file", (int)aiTextureType.aiTextureType_DISPLACEMENT, 0);
                        mat.AddProperty(uvwIndex, 1, /*AI_MATKEY_UVWSRC_DISPLACEMENT(0)*/"$tex.uvwsrc", (int)aiTextureType.aiTextureType_DISPLACEMENT, 0);
                        if (pCurrentMaterial.clamp[(int)ObjMaterial.TextureType.TextureDispType]) {
                            addTextureMappingModeProperty(mat, aiTextureType.aiTextureType_DISPLACEMENT);
                        }
                    }

                    if (pCurrentMaterial.textureOpacity != null) {
                        mat.AddProperty(pCurrentMaterial.textureOpacity, /*AI_MATKEY_TEXTURE_OPACITY(0)*/"$tex.file", (int)aiTextureType.aiTextureType_OPACITY, 0);
                        mat.AddProperty(uvwIndex, 1, /*AI_MATKEY_UVWSRC_OPACITY(0)*/"$tex.uvwsrc", (int)aiTextureType.aiTextureType_OPACITY, 0);
                        if (pCurrentMaterial.clamp[(int)ObjMaterial.TextureType.TextureOpacityType]) {
                            addTextureMappingModeProperty(mat, aiTextureType.aiTextureType_OPACITY);
                        }
                    }

                    if (pCurrentMaterial.textureSpecularity != null) {
                        mat.AddProperty(pCurrentMaterial.textureSpecularity, /*AI_MATKEY_TEXTURE_SHININESS(0)*/"$tex.file", (int)aiTextureType.aiTextureType_SHININESS, 0);
                        mat.AddProperty(uvwIndex, 1, /*AI_MATKEY_UVWSRC_SHININESS(0)*/ "$tex.uvwsrc", (int)aiTextureType.aiTextureType_SHININESS, 0);
                        if (pCurrentMaterial.clamp[(int)ObjMaterial.TextureType.TextureSpecularityType]) {
                            addTextureMappingModeProperty(mat, aiTextureType.aiTextureType_SHININESS);
                        }
                    }

                    if (pCurrentMaterial.textureRoughness != null) {
                        mat.AddProperty(pCurrentMaterial.textureRoughness, /*_AI_MATKEY_TEXTURE_BASE*/"$tex.file", (int)aiTextureType.aiTextureType_DIFFUSE_ROUGHNESS, 0);
                        mat.AddProperty(uvwIndex, 1, /*_AI_MATKEY_UVWSRC_BASE*/"$tex.uvwsrc", (int)aiTextureType.aiTextureType_DIFFUSE_ROUGHNESS, 0);
                        if (pCurrentMaterial.clamp[(int)ObjMaterial.TextureType.TextureRoughnessType]) {
                            addTextureMappingModeProperty(mat, aiTextureType.aiTextureType_DIFFUSE_ROUGHNESS);
                        }
                    }

                    if (pCurrentMaterial.textureMetallic != null) {
                        mat.AddProperty(pCurrentMaterial.textureMetallic, /*_AI_MATKEY_TEXTURE_BASE*/"$tex.file", (int)aiTextureType.aiTextureType_METALNESS, 0);
                        mat.AddProperty(uvwIndex, 1, /*_AI_MATKEY_UVWSRC_BASE*/"$tex.uvwsrc", (int)aiTextureType.aiTextureType_METALNESS, 0);
                        if (pCurrentMaterial.clamp[(int)ObjMaterial.TextureType.TextureMetallicType]) {
                            addTextureMappingModeProperty(mat, aiTextureType.aiTextureType_METALNESS);
                        }
                    }

                    if (pCurrentMaterial.textureSheen != null) {
                        mat.AddProperty(pCurrentMaterial.textureSheen, /*_AI_MATKEY_TEXTURE_BASE*/"$tex.file", (int)aiTextureType.aiTextureType_SHEEN, 0);
                        mat.AddProperty(uvwIndex, 1, /*_AI_MATKEY_UVWSRC_BASE*/"$tex.uvwsrc", (int)aiTextureType.aiTextureType_SHEEN, 0);
                        if (pCurrentMaterial.clamp[(int)ObjMaterial.TextureType.TextureSheenType]) {
                            addTextureMappingModeProperty(mat, aiTextureType.aiTextureType_SHEEN);
                        }
                    }

                    if (pCurrentMaterial.textureRMA != null) {
                        // NOTE: glTF importer places Rough/Metal/AO texture in Unknown so doing the same here for consistency.
                        mat.AddProperty(pCurrentMaterial.textureRMA, /*_AI_MATKEY_TEXTURE_BASE*/"$tex.file", (int)aiTextureType.aiTextureType_UNKNOWN, 0);
                        mat.AddProperty(uvwIndex, 1, /*_AI_MATKEY_UVWSRC_BASE*/"$tex.uvwsrc", (int)aiTextureType.aiTextureType_UNKNOWN, 0);
                        if (pCurrentMaterial.clamp[(int)ObjMaterial.TextureType.TextureRMAType]) {
                            addTextureMappingModeProperty(mat, aiTextureType.aiTextureType_UNKNOWN);
                        }
                    }

                    // Store material property info in material array in scene
                    scene.mMaterials[scene.mNumMaterials] = mat;
                    scene.mNumMaterials++;
                }


            }

            // Test number of created materials.
            Debug.Assert(scene.mNumMaterials == numMaterials);

        }

        //   Add clamp mode property to material if necessary
        private static void addTextureMappingModeProperty(
            aiMaterial mat, aiTextureType type, int clampMode = 1, int index = 0) {
            //if (null == mat) {
            //    return;
            //}

            mat.AddProperty(clampMode, 1, /*AI_MATKEY_MAPPINGMODE_U(type, index)*//*_AI_MATKEY_MAPPINGMODE_U_BASE*/"$tex.mapmodeu", (int)type, index);
            mat.AddProperty(clampMode, 1, /*AI_MATKEY_MAPPINGMODE_V(type, index)*//*_AI_MATKEY_MAPPINGMODE_V_BASE*/"$tex.mapmodev", (int)type, index);
        }

        private static aiNode CreateNodes(
            ObjFileModel pModel, ObjObject pObject,
            aiNode pParent, aiScene pScene, List<aiMesh> MeshArray) {
            if (null == pObject || pModel == null) {
                return null;
            }

            // Store older mesh size to be able to computes mesh offsets for new mesh instances
            var oldMeshSize = MeshArray.Count;
            var pNode = new aiNode(pObject.objName);

            // If we have a parent node, store it
            Debug.Assert(null != pParent);
            appendChildToParentNode(pParent, pNode);

            for (var i = 0; i < pObject.meshes.Count; ++i) {
                var meshId = pObject.meshes[i];
                aiMesh pMesh = createTopology(pModel, pObject, meshId);
                if (pMesh != null) {
                    if (pMesh.mNumFaces > 0) {
                        MeshArray.Add(pMesh);
                    }
                }
            }

            // Create all nodes from the sub-objects stored in the current object
            if (pObject.subObjects.Count > 0) {
                var numChilds = pObject.subObjects.Count;
                pNode.mNumChildren = numChilds;
                pNode.mChildren = new aiNode[numChilds];
                pNode.mNumMeshes = 1;
                pNode.mMeshes = new uint[1];
            }

            // Set mesh instances into scene- and node-instances
            var meshSizeDiff = MeshArray.Count - oldMeshSize;
            if (meshSizeDiff > 0) {
                pNode.mMeshes = new uint[meshSizeDiff];
                pNode.mNumMeshes = meshSizeDiff;
                var index = 0;
                for (var i = oldMeshSize; i < MeshArray.Count; ++i) {
                    pNode.mMeshes[index] = pScene.mNumMeshes;
                    pScene.mNumMeshes++;
                    ++index;
                }
            }

            return pNode;

        }

        //  Create topology data
        private static unsafe aiMesh createTopology(ObjFileModel pModel, ObjObject pData, int meshIndex) {
            if (null == pData || pModel == null) {
                return null;
            }

            // Create faces
            var pObjMesh = pModel.meshes[meshIndex];
            if (pObjMesh == null) {
                return null;
            }

            if (pObjMesh.m_Faces.Count == 0) {
                return null;
            }

            var pMesh = new aiMesh();
            if (pObjMesh.name != null) {
                pMesh.mName = pObjMesh.name;
            }

            for (var index = 0; index < pObjMesh.m_Faces.Count; index++) {
                var inp = pObjMesh.m_Faces[index];
                if (inp == null) {
                    continue;
                }

                if (inp.mPrimitiveType == aiPrimitiveType.aiPrimitiveType_LINE) {
                    pMesh.mNumFaces += (inp.m_vertices.Count - 1);
                    pMesh.mPrimitiveTypes |= aiPrimitiveType.aiPrimitiveType_LINE;
                }
                else if (inp.mPrimitiveType == aiPrimitiveType.aiPrimitiveType_POINT) {
                    pMesh.mNumFaces += (inp.m_vertices.Count);
                    pMesh.mPrimitiveTypes |= aiPrimitiveType.aiPrimitiveType_POINT;
                }
                else {
                    ++pMesh.mNumFaces;
                    if (inp.m_vertices.Count > 3) {
                        pMesh.mPrimitiveTypes |= aiPrimitiveType.aiPrimitiveType_POLYGON;
                    }
                    else {
                        pMesh.mPrimitiveTypes |= aiPrimitiveType.aiPrimitiveType_TRIANGLE;
                    }
                }
            }

            int uiIdxCount = 0;
            if (pMesh.mNumFaces > 0) {
                pMesh.mFaces = new aiFace[pMesh.mNumFaces];
                if (pObjMesh.materialIndex != ObjMesh.NoMaterial) {
                    pMesh.mMaterialIndex = pObjMesh.materialIndex;
                }

                int outIndex = 0;

                // Copy all data from all stored meshes
                foreach (var face in pObjMesh.m_Faces) {
                    var inp = face;
                    if (inp.mPrimitiveType == aiPrimitiveType.aiPrimitiveType_LINE) {
                        for (var i = 0; i < inp.m_vertices.Count - 1; ++i) {
                            var f = pMesh.mFaces[outIndex++];
                            f.mNumIndices = 2;
                            uiIdxCount += f.mNumIndices;
                            f.mIndices = new int[2];
                        }
                        continue;
                    }
                    else if (inp.mPrimitiveType == aiPrimitiveType.aiPrimitiveType_POINT) {
                        for (var i = 0; i < inp.m_vertices.Count; ++i) {
                            aiFace f = pMesh.mFaces[outIndex++];
                            f.mNumIndices = 1;
                            uiIdxCount += f.mNumIndices;
                            f.mIndices = new int[1];
                        }
                        continue;
                    }

                    //var pin = GCHandle.Alloc(pMesh.mFaces);
                    //var pFace = Marshal.UnsafeAddrOfPinnedArrayElement(pMesh.mFaces, outIndex++);
                    var uiNumIndices = face.m_vertices.Count;
                    //{
                    //    var pFace = pMesh.mFaces[outIndex];
                    //    pFace.mNumIndices = uiNumIndices;
                    //    uiIdxCount += pFace.mNumIndices;
                    //    if (pFace.mNumIndices > 0) {
                    //        pFace.mIndices = new int[uiNumIndices];
                    //    }
                    //    pMesh.mFaces[outIndex] = pFace; outIndex++;
                    //}
                    {
                        pMesh.mFaces[outIndex].mNumIndices = uiNumIndices;
                        uiIdxCount += uiNumIndices;
                        if (uiNumIndices > 0) {
                            pMesh.mFaces[outIndex].mIndices = new int[uiNumIndices];
                        }
                        outIndex++;
                    }
                }
            }

            // Create mesh vertices
            CreateVertexArray(pModel, pData, meshIndex, pMesh, uiIdxCount);

            return pMesh;

        }

        private static void CreateVertexArray(
            ObjFileModel pModel, ObjObject pCurrentObject, int uiMeshIndex, aiMesh pMesh, int numIndices) {
            // Checking preconditions
            if (pCurrentObject == null || pModel == null || pMesh == null) {
                return;
            }

            // Break, if no faces are stored in object
            if (pCurrentObject.meshes.Count == 0) {
                return;
            }

            // Get current mesh
            var pObjMesh = pModel.meshes[uiMeshIndex];
            if (null == pObjMesh || pObjMesh.m_uiNumIndices < 1) {
                return;
            }

            // Copy vertices of this mesh instance
            pMesh.mNumVertices = numIndices;
            if (pMesh.mNumVertices == 0) {
                throw new Exception("OBJ: no vertices");
            }
            else if (pMesh.mNumVertices > int.MaxValue) {
                throw new Exception("OBJ: Too many vertices");
            }
            pMesh.mVertices = new vec3[pMesh.mNumVertices];

            // Allocate buffer for normal vectors
            if (pModel.mNormals.Count > 0 && pObjMesh.m_hasNormals)
                pMesh.mNormals = new vec3[pMesh.mNumVertices];

            // Allocate buffer for vertex-color vectors
            if (pModel.mVertexColors.Count > 0)
                pMesh.mColors[0] = new vec4[pMesh.mNumVertices];

            // Allocate buffer for texture coordinates
            if (pModel.mTextureCoord.Count > 0 && pObjMesh.m_uiUVCoordinates[0] != 0) {
                pMesh.mNumUVComponents[0] = pModel.mTextureCoordDim;
                pMesh.mTextureCoords[0] = new vec3[pMesh.mNumVertices];
            }

            // Copy vertices, normals and textures into aiMesh instance
            bool normalsok = true, uvok = true;
            int newIndex = 0, outIndex = 0;
            foreach (var sourceFace in pObjMesh.m_Faces) {
                // Copy all index arrays
                for (int vertexIndex = 0, outVertexIndex = 0; vertexIndex < sourceFace.m_vertices.Count; vertexIndex++) {
                    var vertex = sourceFace.m_vertices[vertexIndex];
                    if (vertex >= pModel.mVertices.Count) {
                        throw new Exception("OBJ: vertex index out of range");
                    }

                    if (pMesh.mNumVertices <= newIndex) {
                        throw new Exception("OBJ: bad vertex index");
                    }

                    pMesh.mVertices[newIndex] = pModel.mVertices[vertex];

                    // Copy all normals
                    if (normalsok && pModel.mNormals.Count > 0 && vertexIndex < sourceFace.m_normals.Count) {
                        var normal = sourceFace.m_normals[vertexIndex];
                        if (normal >= pModel.mNormals.Count) {
                            normalsok = false;
                        }
                        else {
                            pMesh.mNormals[newIndex] = pModel.mNormals[normal];
                        }
                    }

                    // Copy all vertex colors
                    if (vertex < pModel.mVertexColors.Count) {
                        var color = pModel.mVertexColors[vertex];
                        pMesh.mColors[0][newIndex] = new vec4(color.x, color.y, color.z, 1.0f);
                    }

                    // Copy all texture coordinates
                    if (uvok && pModel.mTextureCoord.Count > 0 && vertexIndex < sourceFace.m_texturCoords.Count) {
                        var tex = sourceFace.m_texturCoords[vertexIndex];

                        if (tex >= pModel.mTextureCoord.Count) {
                            uvok = false;
                        }
                        else {
                            var coord3d = pModel.mTextureCoord[tex];
                            pMesh.mTextureCoords[0][newIndex] = coord3d;
                        }
                    }

                    // Get destination face
                    var pDestFace = pMesh.mFaces[outIndex]; var destFaceIndex = outIndex;

                    bool last = (vertexIndex == sourceFace.m_vertices.Count - 1);
                    if (sourceFace.mPrimitiveType != aiPrimitiveType.aiPrimitiveType_LINE || !last) {
                        pDestFace.mIndices[outVertexIndex] = newIndex;
                        outVertexIndex++;
                    }

                    if (sourceFace.mPrimitiveType == aiPrimitiveType.aiPrimitiveType_POINT) {
                        outIndex++;
                        outVertexIndex = 0;
                    }
                    else if (sourceFace.mPrimitiveType == aiPrimitiveType.aiPrimitiveType_LINE) {
                        outVertexIndex = 0;

                        if (!last)
                            outIndex++;

                        if (vertexIndex != 0) {
                            if (!last) {
                                if (pMesh.mNumVertices <= newIndex + 1) {
                                    throw new Exception("OBJ: bad vertex index");
                                }

                                pMesh.mVertices[newIndex + 1] = pMesh.mVertices[newIndex];
                                if (sourceFace.m_normals.Count > 0 && pModel.mNormals.Count > 0) {
                                    pMesh.mNormals[newIndex + 1] = pMesh.mNormals[newIndex];
                                }
                                if (pModel.mTextureCoord.Count > 0) {
                                    for (var i = 0; i < pMesh.GetNumUVChannels(); i++) {
                                        pMesh.mTextureCoords[i][newIndex + 1] = pMesh.mTextureCoords[i][newIndex];
                                    }
                                }
                                ++newIndex;
                            }

                            //pDestFace[-1].mIndices[1] = newIndex;
                            pMesh.mFaces[destFaceIndex - 1].mIndices[1] = newIndex;
                        }
                    }
                    else if (last) {
                        outIndex++;
                    }
                    ++newIndex;
                }
            }

            if (!normalsok) {
                //delete[] pMesh.mNormals;
                pMesh.mNormals = null;
            }

            if (!uvok) {
                //delete[] pMesh.mTextureCoords[0];
                pMesh.mTextureCoords = null;
            }

        }

        //  Appends this node to the parent node
        private static void appendChildToParentNode(aiNode pParent, aiNode pChild) {
            // Checking preconditions
            Debug.Assert(pParent != null && pChild != null);

            // Assign parent to child
            pChild.mParent = pParent;

            // Copy node instances into parent node
            pParent.mNumChildren++;
            pParent.mChildren[pParent.mNumChildren - 1] = pChild;

        }
    }
}
