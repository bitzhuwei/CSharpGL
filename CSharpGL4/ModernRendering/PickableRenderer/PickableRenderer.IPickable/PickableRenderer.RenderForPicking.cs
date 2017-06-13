using System.ComponentModel;
namespace CSharpGL
{
    public partial class PickableRenderer
    {
        #region IPickable 成员

        void IPickable.RenderForPicking(PickEventArgs arg)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}