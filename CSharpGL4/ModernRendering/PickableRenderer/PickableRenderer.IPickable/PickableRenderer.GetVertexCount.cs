using System.ComponentModel;
namespace CSharpGL
{
    public partial class PickableRenderer
    {
        #region IPickable 成员

        uint IPickable.GetVertexCount()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}