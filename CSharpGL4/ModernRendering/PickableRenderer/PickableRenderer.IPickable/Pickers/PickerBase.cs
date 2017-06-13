using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    abstract class PickerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public abstract PickedGeometry GetPickedGeometry(PickableRenderer renderer, PickEventArgs arg, uint stageVertexId, int x, int y);
    }
}
