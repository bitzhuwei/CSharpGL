using System.ComponentModel;
namespace CSharpGL
{
    public partial class PickableRenderer
    {
        #region IPickable 成员

        private PickerBase picker;

        public virtual PickedGeometry GetPickedGeometry(PickingEventArgs arg, uint stageVertexId)
        {
            PickedGeometry result = null;

            PickerBase picker = this.picker;
            if (picker != null)
            {
                result = picker.GetPickedGeometry(arg, stageVertexId);
            }

            return result;
        }

        #endregion
    }
}