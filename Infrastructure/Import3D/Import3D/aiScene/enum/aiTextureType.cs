namespace Import3D {

    /// <summary> @brief Defines the purpose of a texture
    ///
    ///  This is a very difficult topic. Different 3D packages support different
    ///  kinds of textures. For very common texture types, such as bumpmaps, the
    ///  rendering results depend on implementation details in the rendering
    ///  pipelines of these applications. Assimp loads all texture references from
    ///  the model file and tries to determine which of the predefined texture
    ///  types below is the best choice to match the original use of the texture
    ///  as closely as possible.<br>
    ///
    ///  In content pipelines you'll usually define how textures have to be handled,
    ///  and the artists working on models have to conform to this specification,
    ///  regardless which 3D tool they're using.
    /// </summary>
    public enum aiTextureType {
        /// <summary> Dummy value.
        ///
        ///  No texture, but the value to be used as 'texture semantic'
        ///  (#aiMaterialProperty::mSemantic) for all material properties
        /// ///not* related to textures.
        /// </summary>
        aiTextureType_NONE = 0,

        /// <summary> LEGACY API MATERIALS
        /// Legacy refers to materials which
        /// Were originally implemented in the specifications around 2000.
        /// These must never be removed, as most engines support them.
        /// </summary>

        /// <summary> The texture is combined with the result of the diffuse
        ///  lighting equation.
        ///  OR
        ///  PBR Specular/Glossiness
        /// </summary>
        aiTextureType_DIFFUSE = 1,

        /// <summary> The texture is combined with the result of the specular
        ///  lighting equation.
        ///  OR
        ///  PBR Specular/Glossiness
        /// </summary>
        aiTextureType_SPECULAR = 2,

        /// <summary> The texture is combined with the result of the ambient
        ///  lighting equation.
        /// </summary>
        aiTextureType_AMBIENT = 3,

        /// <summary> The texture is added to the result of the lighting
        ///  calculation. It isn't influenced by incoming light.
        /// </summary>
        aiTextureType_EMISSIVE = 4,

        /// <summary> The texture is a height map.
        ///
        ///  By convention, higher gray-scale values stand for
        ///  higher elevations from the base height.
        /// </summary>
        aiTextureType_HEIGHT = 5,

        /// <summary> The texture is a (tangent space) normal-map.
        ///
        ///  Again, there are several conventions for tangent-space
        ///  normal maps. Assimp does (intentionally) not
        ///  distinguish here.
        /// </summary>
        aiTextureType_NORMALS = 6,

        /// <summary> The texture defines the glossiness of the material.
        ///
        ///  The glossiness is in fact the exponent of the specular
        ///  (phong) lighting equation. Usually there is a conversion
        ///  function defined to map the linear color values in the
        ///  texture to a suitable exponent. Have fun.
        /// </summary>
        aiTextureType_SHININESS = 7,

        /// <summary> The texture defines per-pixel opacity.
        ///
        ///  Usually 'white' means opaque and 'black' means
        ///  'transparency'. Or quite the opposite. Have fun.
        /// </summary>
        aiTextureType_OPACITY = 8,

        /// <summary> Displacement texture
        ///
        ///  The exact purpose and format is application-dependent.
        ///  Higher color values stand for higher vertex displacements.
        /// </summary>
        aiTextureType_DISPLACEMENT = 9,

        /// <summary> Lightmap texture (aka Ambient Occlusion)
        ///
        ///  Both 'Lightmaps' and dedicated 'ambient occlusion maps' are
        ///  covered by this material property. The texture contains a
        ///  scaling value for the final color value of a pixel. Its
        ///  intensity is not affected by incoming light.
        /// </summary>
        aiTextureType_LIGHTMAP = 10,

        /// <summary> Reflection texture
        ///
        /// Contains the color of a perfect mirror reflection.
        /// Rarely used, almost never for real-time applications.
        /// </summary>
        aiTextureType_REFLECTION = 11,

        /// <summary> PBR Materials
        /// PBR definitions from maya and other modelling packages now use this standard.
        /// This was originally introduced around 2012.
        /// Support for this is in game engines like Godot, Unreal or Unity3D.
        /// Modelling packages which use this are very common now.
        /// </summary>

        aiTextureType_BASE_COLOR = 12,
        aiTextureType_NORMAL_CAMERA = 13,
        aiTextureType_EMISSION_COLOR = 14,
        aiTextureType_METALNESS = 15,
        aiTextureType_DIFFUSE_ROUGHNESS = 16,
        aiTextureType_AMBIENT_OCCLUSION = 17,

        /// <summary> Unknown texture
        ///
        ///  A texture reference that does not match any of the definitions
        ///  above is considered to be 'unknown'. It is still imported,
        ///  but is excluded from any further post-processing.
        /// </summary>
        aiTextureType_UNKNOWN = 18,

        /// <summary> PBR Material Modifiers
        /// Some modern renderers have further PBR modifiers that may be overlaid
        /// on top of the 'base' PBR materials for additional realism.
        /// These use multiple texture maps, so only the base type is directly defined
        /// </summary>

        /// <summary> Sheen
        /// Generally used to simulate textiles that are covered in a layer of microfibers
        /// eg velvet
        /// https://github.com/KhronosGroup/glTF/tree/master/extensions/2.0/Khronos/KHR_materials_sheen
        /// </summary>
        aiTextureType_SHEEN = 19,

        /// <summary> Clearcoat
        /// Simulates a layer of 'polish' or 'lacquer' layered on top of a PBR substrate
        /// https://autodesk.github.io/standard-surface/#closures/coating
        /// https://github.com/KhronosGroup/glTF/tree/master/extensions/2.0/Khronos/KHR_materials_clearcoat
        /// </summary>
        aiTextureType_CLEARCOAT = 20,

        /// <summary> Transmission
        /// Simulates transmission through the surface
        /// May include further information such as wall thickness
        /// </summary>
        aiTextureType_TRANSMISSION = 21,

        /// <summary>
        /// Maya material declarations
        /// </summary>
        aiTextureType_MAYA_BASE = 22,
        aiTextureType_MAYA_SPECULAR = 23,
        aiTextureType_MAYA_SPECULAR_COLOR = 24,
        aiTextureType_MAYA_SPECULAR_ROUGHNESS = 25,

        /// <summary> Anisotropy
        /// Simulates a surface with directional properties
        /// </summary>
        aiTextureType_ANISOTROPY = 26,

        /// <summary>
        /// gltf material declarations
        /// Refs: https://registry.khronos.org/glTF/specs/2.0/glTF-2.0.html#metallic-roughness-material
        ///           "textures for metalness and roughness properties are packed together in a single
        ///           texture called metallicRoughnessTexture. Its green channel contains roughness
        ///           values and its blue channel contains metalness values..."
        ///       https://registry.khronos.org/glTF/specs/2.0/glTF-2.0.html#_material_pbrmetallicroughness_metallicroughnesstexture
        ///           "The metalness values are sampled from the B channel. The roughness values are
        ///           sampled from the G channel..."
        /// </summary>
        aiTextureType_GLTF_METALLIC_ROUGHNESS = 27,

        //# ifndef SWIG
        //        _aiTextureType_Force32Bit = INT_MAX
        //#endif
    }

}
