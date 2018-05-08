using System.ComponentModel;
using System.Drawing.Design;
namespace CSharpGL
{
    /// <summary>
    /// Rendering something using GLSL shader and VBO(VAO).
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public class IPickableRenderUnit
    {
        private const string strRenderUnit = "RenderUnit";

        // data structure for rendering.
        /// <summary>
        /// 
        /// </summary>
        private IPickableRenderMethodBuilder[] builders;

        /// <summary>
        /// 
        /// </summary>
        public IBufferSource Model { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IPickableRenderMethod[] Methods { get; private set; }


        /// <summary>
        /// Rendering something using GLSL shader and VBO(VAO).
        /// </summary>
        /// <param name="model">model data that can be transfermed into OpenGL Buffer's pointer.</param>
        ///<param name="builders">OpenGL switches.</param>
        public IPickableRenderUnit(IBufferSource model, params IPickableRenderMethodBuilder[] builders)
        {
            this.Model = model;
            this.builders = builders;
            this.Methods = new IPickableRenderMethod[builders.Length];
        }


        #region Initialize()

        private static object synObj = new object();

        private bool isInitialized = false;
        /// <summary>
        /// Already initialized.
        /// </summary>
        [Category(strRenderUnit)]
        [Description("Is this node initialized or not?")]
        public bool IsInitialized { get { return isInitialized; } }

        /// <summary>
        /// Initialize all stuff related to OpenGL.
        /// </summary>
        public void Initialize()
        {
            if (!isInitialized)
            {
                lock (synObj)
                {
                    if (!isInitialized)
                    {
                        //initializing = true;
                        DoInitialize();
                        //initializing = false;
                        isInitialized = true;
                    }
                }
            }
        }

        /// <summary>
        /// This method should only be invoked once.
        /// </summary>
        private void DoInitialize()
        {
            IBufferSource model = this.Model;
            for (int i = 0; i < this.builders.Length; i++)
            {
                IPickableRenderMethod method = this.builders[i].ToRenderMethod(model);
                this.Methods[i] = method;
            }
        }

        #endregion Initialize()

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="transformFeedbackObj"></param>
        public void Render(int index, TransformFeedbackObject transformFeedbackObj = null)
        {
            if (index < 0 || this.Methods.Length <= index) { throw new System.IndexOutOfRangeException(); }

            this.Methods[index].Render(transformFeedbackObj);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            foreach (var item in this.Methods)
            {
                item.Dispose();
            }
        }
    }
}
