using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MipmapGenerator
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFilename.Text = this.openFileDialog1.FileName;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                var file = new System.IO.FileInfo(this.txtFilename.Text);
                var level0 = new Bitmap(file.FullName);
                var list = new List<Image>();
                list.Add(level0.GetThumbnailImage(level0.Width, level0.Height, null, IntPtr.Zero));
                level0.Dispose();
                int count = (int)this.numMipmapLevelCount.Value;
                Image current = list[0];
                for (int i = 1; i < count; i++)
                {
                    Image next = current.GetThumbnailImage(current.Width / 2, current.Height / 2, null, IntPtr.Zero);
                    list.Add(next);
                    current = next;
                }
                if (this.chkGenerateBigPicture.Checked)
                {
                    int interval = 3;
                    int totalWidth = 0, totalHeight = 0;
                    for (int i = 0; i < count; i++)
                    {
                        totalWidth += list[i].Width + interval;
                    }
                    totalWidth -= interval;
                    totalHeight = list[0].Height;
                    var totalImage = new Bitmap(totalWidth, totalHeight);
                    int cursor = 0;
                    using (var g = Graphics.FromImage(totalImage))
                    {
                        for (int i = 0; i < count; i++)
                        {
                            g.DrawImage(list[i], cursor, 0);
                            cursor += list[i].Width + interval;
                        }
                    }
                    list.Add(totalImage);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    string name = string.Format("{0}-level{1}.png", file.FullName, i);
                    list[i].Save(name);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
