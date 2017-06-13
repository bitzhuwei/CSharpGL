using System.ComponentModel;
namespace CSharpGL
{
    public partial class PickableRenderer
    {
        #region IPickable 成员

        public virtual uint GetVertexCount()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}