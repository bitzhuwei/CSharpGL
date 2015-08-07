using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryComparer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        private void btnBrowseBin1_Click(object sender, EventArgs e)
        {
            if (openBmpDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtBitmapFullname1.Text = openBmpDlg.FileName;
            }
        }

        private void btnBrowseBin2_Click(object sender, EventArgs e)
        {
            if (openBmpDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtBitmapFullname2.Text = openBmpDlg.FileName;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtBitmapFullname1.Text))
            {
                string message = string.Format("{0}", "Please select a bitmap file first!");
                MessageBox.Show(message);
                return;
            }

            if (string.IsNullOrEmpty(this.txtBitmapFullname2.Text))
            {
                string message = string.Format("{0}", "Please select another bitmap file first!");
                MessageBox.Show(message);
                return;
            }

            FileStream file1 = null;
            FileStream file2 = null;
            try
            {
                string name1 = this.txtBitmapFullname1.Text;
                string name2 = this.txtBitmapFullname2.Text;

                file1 = new FileStream(name1, FileMode.Open, FileAccess.Read);
                file2 = new FileStream(name2, FileMode.Open, FileAccess.Read);

                if (file1.Length != file2.Length)
                {
                    MessageBox.Show("not the same size!");
                }
                else
                {

                    FileInfo bmpFile1Info = new FileInfo(this.txtBitmapFullname1.Text);
                    string outputFile = string.Format("{0}\\{1}.txt", bmpFile1Info.DirectoryName, bmpFile1Info.Name);
                    using (StreamWriter sw = new StreamWriter(outputFile))
                    {
                        sw.WriteLine("comparer:");
                        sw.WriteLine(name1);
                        sw.WriteLine(name2);
                        int diffCount = 0;
                        for (int position = 0; position < file1.Length; position++)
                        {
                            int b1 = file1.ReadByte();
                            int b2 = file2.ReadByte();
                            if(b1!=b2)
                            {
                                sw.WriteLine(string.Format("@ ({0}) diff: {1} vs {2}",
                                        position, b1, b2));
                                diffCount++;
                            }
                        }

                        sw.WriteLine(string.Format("{0} diffs.", diffCount));
                    }

                    Process.Start("explorer", outputFile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (file1 != null)
                { file1.Dispose(); }
                if (file2 != null)
                { file2.Dispose(); }

            }
        }

    }
}
