using System.Xml.Linq;

namespace Import3D {
    /// <summary>
    /// The root structure of the imported data.
    /// 
    /// Everything that was imported from the given file can be accessed from here.
    /// Objects of this class are generally maintained and owned by Assimp, not
    /// by the caller. You shouldn't want to instance it, nor should you ever try t
    /// delete a given scene on your own.
    /// </summary>
    public unsafe class aiScene {
        /// <summary> Any combination of the AI_SCENE_FLAGS_XXX flags. By default
        /// this value is 0, no flags are set. Most applications will
        /// want to reject all scenes with the AI_SCENE_FLAGS_INCOMPLETE
        /// bit set.
        /// </summary>
        public uint mFlags;

        /// <summary> The root node of the hierarchy.
        /// 
        /// There will always be at least the root node if the import
        /// was successful (and no special flags have been set).
        /// Presence of further nodes depends on the format and content
        /// of the imported file.
        /// </summary>
        public aiNode mRootNode;

        /// <summary> The number of meshes in the scene. /// </summary>
        public uint mNumMeshes;

        /// <summary> The array of meshes.
        /// 
        /// Use the indices given in the aiNode structure to access
        /// this array. The array is mNumMeshes in size. If the
        /// AI_SCENE_FLAGS_INCOMPLETE flag is not set there will always
        /// be at least ONE material.
        /// </summary>
        public aiMesh[]? mMeshes;

        /// <summary> The number of materials in the scene. /// </summary>
        public uint mNumMaterials;

        /// <summary> The array of materials.
        /// 
        /// Use the index given in each aiMesh structure to access this
        /// array. The array is mNumMaterials in size. If the
        /// AI_SCENE_FLAGS_INCOMPLETE flag is not set there will always
        /// be at least ONE material.
        /// </summary>
        public aiMaterial[]? mMaterials;

        /// <summary> The number of animations in the scene. /// </summary>
        public uint mNumAnimations;

        /// <summary> The array of animations.
        /// 
        /// All animations imported from the given file are listed here.
        /// The array is mNumAnimations in size.
        /// </summary>
        public aiAnimation[]? mAnimations;

        /// <summary> The number of textures embedded into the file /// </summary>
        public uint mNumTextures;

        /// <summary> The array of embedded textures.
        /// 
        /// Not many file formats embed their textures into the file.
        /// An example is Quake's MDL format (which is also used by
        /// some GameStudio versions)
        /// </summary>
        public aiTexture[]? mTextures;

        /// <summary> The number of light sources in the scene. Light sources
        /// are fully optional, in most cases this attribute will be 0
        /// </summary>
        public uint mNumLights;

        /// <summary> The array of light sources.
        /// 
        /// All light sources imported from the given file are
        /// listed here. The array is mNumLights in size.
        /// </summary>
        public aiLight[]? mLights;

        /// <summary> The number of cameras in the scene. Cameras
        /// are fully optional, in most cases this attribute will be 0
        /// </summary>
        public uint mNumCameras;

        /// <summary> The array of cameras.
        /// 
        /// All cameras imported from the given file are listed here.
        /// The array is mNumCameras in size. The first camera in the
        /// array (if existing) is the default camera view into
        /// the scene.
        /// </summary>
        public aiCamera[]? mCameras;

        ///  <summary> The global metadata assigned to the scene itself.
        ///
        ///  This data contains global metadata which belongs to the scene like
        ///  unit-conversions, versions, vendors or other model-specific data. This
        ///  can be used to store format-specific metadata as well.
        /// </summary>
        public aiMetadata mMetaData;

        /// <summary> The name of the scene itself.
        /// </summary>
        public string mName = "";


        public uint mNumSkeletons;

        public aiSkeleton[]? mSkeletons;

        public aiScene(string name) {
            this.mRootNode = new aiNode(name);
        }

        public bool HasTextures() {
            return mTextures != null && mNumTextures > 0;
        }
    }
}
