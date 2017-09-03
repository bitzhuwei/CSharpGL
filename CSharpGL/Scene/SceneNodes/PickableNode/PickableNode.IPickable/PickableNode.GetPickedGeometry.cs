using System.ComponentModel;
namespace CSharpGL
{
    public partial class PickableNode
    {
        #region IPickable 成员

        private PickerBase picker;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <returns></returns>
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