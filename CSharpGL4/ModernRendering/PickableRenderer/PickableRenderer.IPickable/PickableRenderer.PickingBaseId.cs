using System.ComponentModel;
namespace CSharpGL
{
    public partial class PickableRenderer
    {
        #region IPickable 成员

        /// <summary>
        /// 
        /// </summary>
        uint IPickable.PickingBaseId { get; set; }

        #endregion
    }
}