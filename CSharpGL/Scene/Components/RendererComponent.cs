//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace CSharpGL
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public abstract class RendererComponent : Component, IRenderable, IDisposable
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="bindingObject"></param>
//        public RendererComponent(SceneObject bindingObject = null)
//            : base(bindingObject)
//        { }

//        //protected override void DoInitialize()
//        //{
//        //    base.DoInitialize();

//        //    int location;
//        //    location = this.shaderProgram.GetUniformLocation(projection);
//        //    if (location < 0)
//        //    { throw new Exception(string.Format("No uniform found for the name [{0}]", projection)); }
//        //    else
//        //    { this.projectionLocation = (uint)location; }
//        //    location = this.shaderProgram.GetUniformLocation(view);
//        //    if (location < 0)
//        //    { throw new Exception(string.Format("No uniform found for the name [{0}]", view)); }
//        //    else
//        //    { this.viewLocation = (uint)location; }
//        //    location = this.shaderProgram.GetUniformLocation(model);
//        //    if (location < 0)
//        //    { throw new Exception(string.Format("No uniform found for the name [{0}]", model)); }
//        //    else
//        //    { this.modelLocation = (uint)location; }

//        //}
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="arg"></param>
//        /// <param name="projection"></param>
//        /// <param name="view"></param>
//        /// <param name="model"></param>
//        /// <returns></returns>
//        protected bool TryGetMatrix(RenderEventArg arg,
//            out mat4 projection, out mat4 view, out mat4 model)
//        {
//            projection = arg.Camera.GetProjectionMat4();
//            view = arg.Camera.GetViewMat4();

//            SceneObject bindingObject = this.BindingObject;
//            if (bindingObject != null)
//            {
//                model = bindingObject.Transform.GetModelMatrix();

//                return true;
//            }
//            else
//            {
//                model = new mat4();

//                return false;
//            }
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="arg"></param>
//        public abstract void Render(RenderEventArg arg);

//        #region IDisposable Members

//        /// <summary>
//        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
//        /// </summary>
//        public void Dispose()
//        {
//            this.Dispose(true);
//            GC.SuppressFinalize(this);
//        } // end sub

//        /// <summary>
//        /// Destruct instance of the class.
//        /// </summary>
//        ~RendererComponent()
//        {
//            this.Dispose(false);
//        }

//        /// <summary>
//        /// Backing field to track whether Dispose has been called.
//        /// </summary>
//        private bool disposedValue = false;

//        /// <summary>
//        /// Dispose managed and unmanaged resources of this instance.
//        /// </summary>
//        /// <param name="disposing">If disposing equals true, managed and unmanaged resources can be disposed. If disposing equals false, only unmanaged resources can be disposed. </param>
//        protected virtual void Dispose(bool disposing)
//        {

//            if (this.disposedValue == false)
//            {
//                if (disposing)
//                {
//                    DisposeManagedResources();
//                } // end if

//                DisposeUnmanagedResource();

//            } // end if

//            this.disposedValue = true;
//        } // end sub

//        /// <summary>
//        /// 
//        /// </summary>
//        protected virtual void DisposeManagedResources() { }
//        /// <summary>
//        /// 
//        /// </summary>
//        protected abstract void DisposeUnmanagedResource();

//        #endregion

//    }
//}
