using System.ComponentModel;
namespace CSharpGL
{
    public partial class PickableRenderer
    {
        #region IPickable 成员

        private PickerBase picker;

        public virtual PickedGeometry GetPickedGeometry(PickEventArgs arg, uint stageVertexId, int x, int y)
        {
            PickedGeometry result = null;

            PickerBase picker = this.picker;
            if (picker != null)
            {
                result = picker.GetPickedGeometry(arg, stageVertexId, x, y);
            }

            return result;
        }

        #endregion
    }
}