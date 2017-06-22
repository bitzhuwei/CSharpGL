using System.ComponentModel;
namespace CSharpGL
{
    public partial class PickableRenderer
    {
        #region IPickable 成员

        private TwoFlags enablePicking = TwoFlags.BeforeChildren | TwoFlags.Children;
        /// <summary>
        /// 
        /// </summary>
        public TwoFlags EnablePicking
        {
            get { return this.enablePicking; }
            set { this.enablePicking = value; }
        }

        #endregion
    }
}