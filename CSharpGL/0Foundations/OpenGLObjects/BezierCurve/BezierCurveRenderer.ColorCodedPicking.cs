using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class BezierCurveRenderer
    {
        /// <summary>
        /// 
        /// </summary>
        public mat4 MVP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public uint PickingBaseId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint GetVertexCount()
        {
            return (uint)this.ControlPoints.Length;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public PickedGeometry GetPickedGeometry(RenderEventArgs arg, uint stageVertexId, int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}
