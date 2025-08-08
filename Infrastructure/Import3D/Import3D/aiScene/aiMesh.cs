
namespace Import3D {
    /// <summary>
    /// @brief A mesh represents a geometry or model with a single material.
    ///
    /// It usually consists of a number of vertices and a series of primitives/faces
    /// referencing the vertices. In addition there might be a series of bones, each
    /// of them addressing a number of vertices with a certain weight. Vertex data
    /// is presented in channels with each channel containing a single per-vertex
    /// information such as a set of texture coordinates or a normal vector.
    /// If a data pointer is non-null, the corresponding data stream is present.
    /// From C++-programs you can also use the comfort functions Has*() to
    /// test for the presence of various data streams.
    ///
    /// A Mesh uses only a single material which is referenced by a material ID.
    /// @note The mPositions member is usually not optional. However, vertex positions
    /// ///could* be missing if the #AI_SCENE_FLAGS_INCOMPLETE flag is set in
    /// @code
    /// aiScene::mFlags
    /// @endcode
    /// </summary>
    public unsafe class aiMesh {
        /// <summary>
        /// Bitwise combination of the members of the #aiPrimitiveType enum.
        /// This specifies which types of primitives are present in the mesh.
        /// The "SortByPrimitiveType"-Step can be used to make sure the
        /// output meshes consist of one primitive type each.
        /// </summary>
        public aiPrimitiveType mPrimitiveTypes;

        /// <summary>
        /// The number of vertices in this mesh.
        /// This is also the size of all of the per-vertex data arrays.
        /// The maximum value for this member is #AI_MAX_VERTICES.
        /// </summary>
        public int mNumVertices;

        /// <summary>
        /// The number of primitives (triangles, polygons, lines) in this  mesh.
        /// This is also the size of the mFaces array.
        /// The maximum value for this member is #AI_MAX_FACES.
        /// </summary>
        public int mNumFaces;

        /// <summary>
        /// @brief Vertex positions.
        ///
        /// This array is always present in a mesh. The array is
        /// mNumVertices in size.
        /// </summary>
        public vec3[]? mVertices;

        /// <summary>
        /// @brief Vertex normals.
        ///
        /// The array contains normalized vectors, nullptr if not present.
        /// The array is mNumVertices in size. Normals are undefined for
        /// point and line primitives. A mesh consisting of points and
        /// lines only may not have normal vectors. Meshes with mixed
        /// primitive types (i.e. lines and triangles) may have normals,
        /// but the normals for vertices that are only referenced by
        /// point or line primitives are undefined and set to QNaN (WARN:
        /// qNaN compares to inequal to ///everything*, even to qNaN itself.
        /// Using code like this to check whether a field is qnan is:
        /// @code
        /// #define IS_QNAN(f) (f != f)
        /// @endcode
        /// still dangerous because even 1.f == 1.f could evaluate to false! (
        /// remember the subtleties of IEEE754 artithmetics). Use stuff like
        /// @c fpclassify instead.
        /// @note Normal vectors computed by Assimp are always unit-length.
        /// However, this needn't apply for normals that have been taken
        /// directly from the model file.
        /// </summary>
        public vec3[]? mNormals;

        /// <summary>
        /// @brief Vertex tangents.
        ///
        /// The tangent of a vertex points in the direction of the positive
        /// X texture axis. The array contains normalized vectors, nullptr if
        /// not present. The array is mNumVertices in size. A mesh consisting
        /// of points and lines only may not have normal vectors. Meshes with
        /// mixed primitive types (i.e. lines and triangles) may have
        /// normals, but the normals for vertices that are only referenced by
        /// point or line primitives are undefined and set to qNaN.  See
        /// the #mNormals member for a detailed discussion of qNaNs.
        /// @note If the mesh contains tangents, it automatically also
        /// contains bitangents.
        /// </summary>
        public vec3[]? mTangents;

        /// <summary>
        /// @brief Vertex bitangents.
        ///
        /// The bitangent of a vertex points in the direction of the positive
        /// Y texture axis. The array contains normalized vectors, nullptr if not
        /// present. The array is mNumVertices in size.
        /// @note If the mesh contains tangents, it automatically also contains
        /// bitangents.
        /// </summary>
        public vec3[]? mBitangents;

        /// <summary>
        /// @brief Vertex color sets.
        ///
        /// A mesh may contain 0 to #AI_MAX_NUMBER_OF_COLOR_SETS vertex
        /// colors per vertex. nullptr if not present. Each array is
        /// mNumVertices in size if present.
        /// </summary>
        public vec4[][] mColors = new vec4[/*AI_MAX_NUMBER_OF_COLOR_SETS*/0x8][];

        /// <summary>
        /// @brief Vertex texture coordinates, also known as UV channels.
        ///
        /// A mesh may contain 0 to AI_MAX_NUMBER_OF_TEXTURECOORDS channels per
        /// vertex. Used and unused (nullptr) channels may go in any order.
        /// The array is mNumVertices in size.
        /// </summary>
        public vec3[][] mTextureCoords = new vec3[/*AI_MAX_NUMBER_OF_TEXTURECOORDS*/0x8][];

        /// <summary>
        /// @brief Specifies the number of components for a given UV channel.
        ///
        /// Up to three channels are supported (UVW, for accessing volume
        /// or cube maps). If the value is 2 for a given channel n, the
        /// component p.z of mTextureCoords[n][p] is set to 0.0f.
        /// If the value is 1 for a given channel, p.y is set to 0.0f, too.
        /// @note 4D coordinates are not supported
        /// </summary>
        public uint[] mNumUVComponents = new uint[/*AI_MAX_NUMBER_OF_TEXTURECOORDS*/0x8];

        /// <summary>
        /// @brief The faces the mesh is constructed from.
        ///
        /// Each face refers to a number of vertices by their indices.
        /// This array is always present in a mesh, its size is given
        ///  in mNumFaces. If the #AI_SCENE_FLAGS_NON_VERBOSE_FORMAT
        /// is NOT set each face references an unique set of vertices.
        /// </summary>
        public aiFace[]? mFaces;

        /// <summary>
        /// The number of bones this mesh contains. Can be 0, in which case the mBones array is nullptr.
        /// </summary>
        public uint mNumBones;

        /// <summary>
        /// @brief The bones of this mesh.
        ///
        /// A bone consists of a name by which it can be found in the
        /// frame hierarchy and a set of vertex weights.
        /// </summary>
        public aiBone[]? mBones;

        /// <summary>
        /// @brief The material used by this mesh.
        ///
        /// A mesh uses only a single material. If an imported model uses
        /// multiple materials, the import splits up the mesh. Use this value
        /// as index into the scene's material list.
        /// </summary>
        public uint mMaterialIndex;

        /// <summary>
        ///  Name of the mesh. Meshes can be named, but this is not a
        ///  requirement and leaving this field empty is totally fine.
        ///  There are mainly three uses for mesh names:
        ///   - some formats name nodes and meshes independently.
        ///   - importers tend to split meshes up to meet the
        ///      one-material-per-mesh requirement. Assigning
        ///      the same (dummy) name to each of the result meshes
        ///      aids the caller at recovering the original mesh
        ///      partitioning.
        ///   - Vertex animations refer to meshes by their names.
        /// </summary>
        public string mName = "";

        /// <summary>
        /// The number of attachment meshes.
        /// Currently known to work with loaders:
        /// - Collada
        /// - gltf
        /// </summary>
        public uint mNumAnimMeshes;

        /// <summary>
        /// Attachment meshes for this mesh, for vertex-based animation.
        /// Attachment meshes carry replacement data for some of the
        /// mesh'es vertex components (usually positions, normals).
        /// Currently known to work with loaders:
        /// - Collada
        /// - gltf
        /// </summary>
        public aiAnimMesh[]? mAnimMeshes;

        /// <summary>
        ///  Method of morphing when anim-meshes are specified.
        ///  @see aiMorphingMethod to learn more about the provided morphing targets.
        /// </summary>
        public aiMorphingMethod mMethod;

        /// <summary>
        ///  The bounding box.
        /// </summary>
        public aiAABB mAABB;

        /// <summary>
        /// Vertex UV stream names. Pointer to array of size AI_MAX_NUMBER_OF_TEXTURECOORDS
        /// </summary>
        public string[] mTextureCoordsNames = new string[/*AI_MAX_NUMBER_OF_TEXTURECOORDS*/0x8];

        public aiMesh() {
        }

        public int GetNumUVChannels() {
            int n = 0;
            for (var i = 0; i < /*AI_MAX_NUMBER_OF_TEXTURECOORDS*/0x8; i++) {
                if (this.mTextureCoords[i] != null) {
                    ++n;
                }
            }

            return n;
        }
    }
}