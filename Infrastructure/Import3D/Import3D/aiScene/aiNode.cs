namespace Import3D {
    /// <summary>
    /// A node in the imported hierarchy.
    /// 
    /// Each node has name, a parent node (except for the root node),
    /// a transformation relative to its parent and possibly several child nodes.
    /// Simple file formats don't support hierarchical structures - for these formats
    /// the imported scene does consist of only a single root node without children.
    /// </summary>
    public unsafe class aiNode {
        /// <summary>The name of the node.
        ///
        /// The name might be empty (length of zero) but all nodes which
        /// need to be referenced by either bones or animations are named.
        /// Multiple nodes may have the same name, except for nodes which are referenced
        /// by bones (see #aiBone and #aiMesh::mBones). Their names *must* be unique.
        ///
        /// Cameras and lights reference a specific node by name - if there
        /// are multiple nodes with this name, they are assigned to each of them.
        /// <br />
        /// There are no limitations with regard to the characters contained in
        /// the name string as it is usually taken directly from the source file.
        ///
        /// Implementations should be able to handle tokens such as whitespace, tabs,
        /// line feeds, quotation marks, ampersands etc.
        ///
        /// Sometimes assimp introduces new nodes not present in the source file
        /// into the hierarchy (usually out of necessity because sometimes the
        /// source hierarchy format is simply not compatible). Their names are
        /// surrounded by @verbatim &lt;&gt; @endverbatim e.g.
        ///  @verbatim&lt;DummyRootNode&gt; @endverbatim.
        /// </summary>
        public string mName;

        /// <summary>The transformation relative to the node's parent. /// </summary>
        public mat4 mTransformation;

        /// <summary>Parent node. nullptr if this node is the root node. /// </summary>
        public aiNode mParent;

        /// <summary>The number of child nodes of this node. /// </summary>
        public int mNumChildren;

        /// <summary>The child nodes of this node. nullptr if mNumChildren is 0. /// </summary>
        public aiNode[] mChildren;

        /// <summary>The number of meshes of this node. /// </summary>
        public int mNumMeshes;

        /// <summary>The meshes of this node. Each entry is an index into the
        /// mesh list of the #aiScene.
        /// </summary>
        public uint[] mMeshes;

        /// <summary>Metadata associated with this node or nullptr if there is no metadata.
        ///  Whether any metadata is generated depends on the source file format. See the
        /// @link importer_notes @endlink page for more information on every source file
        /// format. Importers that don't document any metadata don't write any.
        /// </summary>
        public aiMetadata mMetaData;

        public aiNode(string name) {
            this.mName = name;
        }
    }
}