using System.ComponentModel;
namespace CSharpGL
{
    public partial class PickableNode
    {
        #region IPickable 成员

        private PickerBase[] picker;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <returns></returns>
        public virtual PickedGeometry GetPickedGeometry(PickingEventArgs arg, uint stageVertexId)
        {
            PickedGeometry result = null;

            PickerBase[] picker = this.picker;
            if (picker != null)
            {
                var pickable = this as IPickable;
                uint baseId = pickable.PickingBaseId;
                for (int i = 0; i < picker.Length; i++)
                {
                    var blockVertexCount = (uint)picker[i].PositionBuffer.Length;
                    if (baseId <= stageVertexId && stageVertexId < baseId + blockVertexCount)
                    {
                        result = picker[i].GetPickedGeometry(arg, stageVertexId, baseId);
                        break;
                    }

                    baseId += blockVertexCount;
                }
            }

            return result;
        }

        #endregion
    }
}