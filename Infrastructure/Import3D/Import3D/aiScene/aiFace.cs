namespace Import3D {
    /// <summary>
    /// @brief A single face in a mesh, referring to multiple vertices.
    ///
    /// If mNumIndices is 3, we call the face 'triangle', for mNumIndices > 3
    /// it's called 'polygon' (hey, that's just a definition!).
    /// <br>
    /// aiMesh::mPrimitiveTypes can be queried to quickly examine which types of
    /// primitive are actually present in a mesh. The #aiProcess_SortByPType flag
    /// executes a special post-processing algorithm which splits meshes with
    /// *different* primitive types mixed up (e.g. lines and triangles) in several
    /// 'clean' sub-meshes. Furthermore there is a configuration option (
    /// #AI_CONFIG_PP_SBP_REMOVE) to force #aiProcess_SortByPType to remove
    /// specific kinds of primitives from the imported scene, completely and forever.
    /// In many cases you'll probably want to set this setting to
    /// @code
    /// aiPrimitiveType_LINE|aiPrimitiveType_POINT
    /// @endcode
    /// Together with the #aiProcess_Triangulate flag you can then be sure that
    /// #aiFace::mNumIndices is always 3.
    /// @note Take a look at the @link data Data Structures page @endlink for
    /// more information on the layout and winding order of a face.
    /// </summary>
    public unsafe struct aiFace {
        /// <summary> Number of indices defining this face.
        /// The maximum value for this member is #AI_MAX_FACE_INDICES.
        /// </summary>
        public int mNumIndices;

        /// <summary> Pointer to the indices array. Size of the array is given in numIndices.
        /// </summary>
        public int[] mIndices;
    }
}