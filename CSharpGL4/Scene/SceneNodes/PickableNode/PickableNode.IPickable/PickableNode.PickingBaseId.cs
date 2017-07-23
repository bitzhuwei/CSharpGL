using System.ComponentModel;
namespace CSharpGL
{
    public partial class PickableNode
    {
        #region IPickable 成员

        /// <summary>
        /// 
        /// </summary>
        uint IPickable.PickingBaseId { get; set; }

        #endregion
    }
}