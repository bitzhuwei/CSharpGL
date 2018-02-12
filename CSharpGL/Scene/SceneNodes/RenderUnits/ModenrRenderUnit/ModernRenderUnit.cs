using System;
using System.ComponentModel;
using System.Drawing.Design;
namespace CSharpGL
{
    /// <summary>
    /// Rendering something using multiple GLSL shader programs and VBO(VAO).
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class ModernRenderUnit : IDisposable
    {
        private const string strRenderUnit = "RenderUnit";

        // data structure for rendering.
        /// <summary>
        /// 
        /// </summary>
        private RenderMethodBuilder[] builders;

        /// <summary>
        /// 
        /// </summary>
        public IBufferSource Model { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public RenderMethod[] Methods { get; private set; }


        /// <summary>
        /// Rendering something using multiple GLSL shader programs and VBO(VAO).
        /// </summary>
        /// <param name="model">model data that can be transfermed into OpenGL Buffer's pointer.</param>
        ///<param name="builders">OpenGL switches.</param>
        public ModernRenderUnit(IBufferSource model, params RenderMethodBuilder[] builders)
        {
            this.Model = model;
            this.builders = builders;
            this.Methods = new RenderMethod[builders.Length];
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
                RenderMethod method = this.builders[i].ToRenderMethod(model);
                this.Methods[i] = method;
            }
        }

        #endregion Initialize()

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="controlMode">index buffer is accessable randomly or only by frame.</param>
        ///// <param name="transformFeedbackObj"></param>
        //public void Render(int index, ControlMode controlMode, TransformFeedbackObject transformFeedbackObj = null)
        //{
        //    if (index < 0 || this.Methods.Length <= index) { throw new System.IndexOutOfRangeException(); }

        //    this.Methods[index].Render(controlMode, transformFeedbackObj);
        //}
    }
}
