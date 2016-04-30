
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Scene element that implemented this interface will take part in color-coded picking when using <see cref="MyScene.Draw(RenderMode.HitTest);"/>.
    /// </summary>
    public interface IColorCodedPicking : IRenderable
    {

        /// <summary>
        /// 
        /// </summary>
        mat4 MVP { get; set; }

        /// <summary>
        /// Gets or internal sets how many primitived have been rendered till now during hit test.
        /// <para>This will be set up by <see cref="ColorCodedPickingScene.Draw(RenderMode.HitTest)"/>, so just use it to set shader's uniform variable.</para>
        /// </summary>
        uint PickingBaseID { get; }

        void SetPickingBaseID(uint value);

        /// <summary>
        /// Gets vertices' count in this element's VBO representing positions.
        /// </summary>
        /// <returns></returns>
        uint GetVertexCount();

        /// <summary>
        /// Get the primitive according to vertex's id.
        /// <para>Note: the <paramref name="stageVertexId"/> refers to the last vertex that constructs the primitive. And it's unique in scene's all elements.</para>
        /// <para>You can use <see cref="PickedPrimitiveHelper.TryPick()"/> to simplify your work.</para>
        /// </summary>
        /// <param name="stageVertexId">Refers to the last vertex that constructs the primitive. And it's unique in scene's all elements.</param>
        /// <returns></returns>
        PickedGeometry Pick(RenderEventArgs e, PickingPrimitiveType pickingPrimitiveType, uint stageVertexId, 
            int x, int y, int canvasWidth, int canvasHeight);
    }
}
