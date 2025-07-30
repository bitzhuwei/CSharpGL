﻿namespace CSharpGL {
    /// <summary>
    /// The picked geometry of color-coded picking.
    /// <para>Representing a basic geometry.</para>
    /// </summary>
    public interface IPickedGeometry {
        /// <summary>
        /// Gets or sets primitive's geometry type.
        /// </summary>
        GeometryType Type { get; set; }

        /// <summary>
        /// Gets or sets positions of this primitive's vertices.
        /// </summary>
        vec3[] Positions { get; set; }

        /// <summary>
        /// Gets or sets indexes of this primitive's vertexes' index in the VBO.
        /// </summary>
        uint[] VertexIds { get; set; }

        /// <summary>
        /// Node of the scene from which this <see cref="IPickedGeometry"/>'s instance is picked.
        /// </summary>
        IPickable FromObject { get; set; }

        /// <summary>
        /// The last vertex's id that constructs the picked primitive.
        /// <para>This id is in scene's all <see cref="IPickable"/>s' order.</para>
        /// </summary>
        uint StageVertexId { get; set; }
    }
}