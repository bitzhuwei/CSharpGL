using System;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    internal class UpdateImageScript : Script, IDisposable
    {
        private Control canvas;
        private OpenFileDialog openTextureDlg;
        private KeyPressEventHandler keyPress;

        public UpdateImageScript(Control canvas, SceneObject obj = null)
            : base(obj)
        {
            this.canvas = canvas;

            if (this.openTextureDlg == null)
            {
                {
                    var openTextureDlg = new OpenFileDialog();
                    openTextureDlg.Filter = "Image File(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
                    this.openTextureDlg = openTextureDlg;
                }
                {
                    this.keyPress = this.glCanvas1_KeyPress;
                    this.canvas.KeyPress += this.keyPress;
                }
            }
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'o')
            {
                if (this.openTextureDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    {
                        var renderer = this.BindingObject.Renderer as IDisposable;
                        if (renderer != null)
                        { renderer.Dispose(); }
                    }
                    {
                        var renderer = new ImageProcessingRenderer(this.openTextureDlg.FileName);
                        renderer.Initialize();
                        this.BindingObject.Renderer = renderer;
                    }
                }
            }
            else if (e.KeyChar == 'z')
            {
                var renderer = this.BindingObject.Renderer as ImageProcessingRenderer;
                renderer.SwitchDisplayImage(true);
            }
            else if (e.KeyChar == 'x')
            {
                var renderer = this.BindingObject.Renderer as ImageProcessingRenderer;
                renderer.SwitchDisplayImage(false);
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        } // end sub

        /// <summary>
        /// Destruct instance of the class.
        /// </summary>
        ~UpdateImageScript()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Backing field to track whether Dispose has been called.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Dispose managed and unmanaged resources of this instance.
        /// </summary>
        /// <param name="disposing">If disposing equals true, managed and unmanaged resources can be disposed. If disposing equals false, only unmanaged resources can be disposed. </param>
        protected void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // TODO: Dispose managed resources.
                    this.canvas.KeyPress -= this.keyPress;
                    this.canvas = null;
                    this.openTextureDlg.Dispose();
                    this.openTextureDlg = null;
                } // end if

                // TODO: Dispose unmanaged resources.
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion IDisposable Members
    }
}