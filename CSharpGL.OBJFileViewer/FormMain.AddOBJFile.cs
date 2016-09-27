using CSharpGL.OBJFile;

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
            }
        }
    }
}