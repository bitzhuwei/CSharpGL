using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Base type of all scripts.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public abstract partial class Script : IBindingObject<SceneObject>
    {
        /// <summary>
        /// name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 为便于调试而设置的ID值，没有应用意义。
        /// <para>Only for debugging.</para>
        /// </summary>
        public int Id { get; private set; }

        private static int idCounter = 0;

        /// <summary>
        ///
        /// </summary>
        public SceneObject BindingObject { get; set; }

        /// <summary>
        /// Base type of all scripts.
        /// </summary>
        /// <param name="bindingObject"></param>
        public Script(SceneObject bindingObject = null)
        {
            this.Id = idCounter++;

            this.BindingObject = bindingObject;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="elapsedTime"></param>
        protected virtual void DoUpdate(double elapsedTime) { }

        internal void Update(double elapsedTime)
        {
            this.DoUpdate(elapsedTime);
        }
    }
}