using System.ComponentModel;
namespace CSharpGL
{
    public partial class PickableRenderer
    {
        #region IPickable 成员

        private PickerBase picker;

        PickedGeometry IPickable.GetPickedGeometry(PickEventArgs arg, uint stageVertexId, int x, int y)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}