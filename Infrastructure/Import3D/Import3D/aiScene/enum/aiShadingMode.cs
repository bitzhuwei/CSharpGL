namespace Import3D {
    /// <summary> @brief Defines all shading models supported by the library
    ///
    ///  Property: #AI_MATKEY_SHADING_MODEL
    ///
    ///  The list of shading modes has been taken from Blender.
    ///  See Blender documentation for more information. The API does
    ///  not distinguish between "specular" and "diffuse" shaders (thus the
    ///  specular term for diffuse shading models like Oren-Nayar remains
    ///  undefined). <br>
    ///  Again, this value is just a hint. Assimp tries to select the shader whose
    ///  most common implementation matches the original rendering results of the
    ///  3D modeler which wrote a particular model as closely as possible.
    ///
    /// </summary>
    public enum aiShadingMode {
        /// <summary> Flat shading. Shading is done on per-face base,
        ///  diffuse only. Also known as 'faceted shading'.
        /// </summary>
        aiShadingMode_Flat = 0x1,

        /// <summary> Simple Gouraud shading.
        /// </summary>
        aiShadingMode_Gouraud = 0x2,

        /// <summary> Phong-Shading -
        /// </summary>
        aiShadingMode_Phong = 0x3,

        /// <summary> Phong-Blinn-Shading
        /// </summary>
        aiShadingMode_Blinn = 0x4,

        /// <summary> Toon-Shading per pixel
        ///
        ///  Also known as 'comic' shader.
        /// </summary>
        aiShadingMode_Toon = 0x5,

        /// <summary> OrenNayar-Shading per pixel
        ///
        ///  Extension to standard Lambertian shading, taking the
        ///  roughness of the material into account
        /// </summary>
        aiShadingMode_OrenNayar = 0x6,

        /// <summary> Minnaert-Shading per pixel
        ///
        ///  Extension to standard Lambertian shading, taking the
        ///  "darkness" of the material into account
        /// </summary>
        aiShadingMode_Minnaert = 0x7,

        /// <summary> CookTorrance-Shading per pixel
        ///
        ///  Special shader for metallic surfaces.
        /// </summary>
        aiShadingMode_CookTorrance = 0x8,

        /// <summary> No shading at all. Constant light influence of 1.0.
        /// Also known as "Unlit"
        /// </summary>
        aiShadingMode_NoShading = 0x9,
        aiShadingMode_Unlit = aiShadingMode_NoShading, // Alias

        /// <summary> Fresnel shading
        /// </summary>
        aiShadingMode_Fresnel = 0xa,

        /// <summary> Physically-Based Rendering (PBR) shading using
        /// Bidirectional scattering/reflectance distribution function (BSDF/BRDF)
        /// There are multiple methods under this banner, and model files may provide
        /// data for more than one PBR-BRDF method.
        /// Applications should use the set of provided properties to determine which
        /// of their preferred PBR rendering methods are likely to be available
        /// eg:
        /// - If AI_MATKEY_METALLIC_FACTOR is set, then a Metallic/Roughness is available
        /// - If AI_MATKEY_GLOSSINESS_FACTOR is set, then a Specular/Glossiness is available
        /// Note that some PBR methods allow layering of techniques
        /// </summary>
        aiShadingMode_PBR_BRDF = 0xb,

        //# ifndef SWIG
        //        _aiShadingMode_Force32Bit = INT_MAX
        //#endif
    }
}