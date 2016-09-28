using CSharpGL.OBJFile;
using System.Drawing;

namespace CSharpGL.OBJFileViewer
{
    public partial class FormMain
    {
        private string lastfilename;

        private void 打开OToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (this.OpenOBJFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OBJRawFile file = OBJRawFile.Load(this.OpenOBJFileDlg.FileName);
                foreach (var item in file.Models)
                {
                    OBJModelRenderer renderer = OBJModelRenderer.Create(
                        item);
                    SceneObject obj = renderer.WrapToSceneObject();
                    this.scene.RootObject.Children.Add(obj);
                }

                this.lastfilename = this.OpenOBJFileDlg.FileName;
            }
        }

        private void 纹理OToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (this.openTextureDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(this.openTextureDlg.FileName);
                foreach (var item in this.scene.RootObject)
                {
                    var renderer = item.Renderer as OBJModelRenderer;
                    if (renderer != null)
                    {
                        renderer.SetTexture(bitmap);
                    }
                }
                bitmap.Dispose();
            }
        }
    }
}