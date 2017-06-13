using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    class ZeroIndexPicker : PickerBase
    {
        public override PickedGeometry GetPickedGeometry(PickableRenderer renderer, PickEventArgs arg, uint stageVertexId, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
