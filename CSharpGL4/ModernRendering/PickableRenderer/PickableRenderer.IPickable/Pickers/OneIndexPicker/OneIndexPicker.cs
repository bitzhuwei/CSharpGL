using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    class OneIndexPicker : PickerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderer"></param>
        public OneIndexPicker(PickableRenderer renderer) : base(renderer) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override PickedGeometry GetPickedGeometry(PickEventArgs arg, uint stageVertexId, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
