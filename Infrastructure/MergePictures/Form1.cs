using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MergePictures
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFolder.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.txtFolder.Text))
            {
                MessageBox.Show("Please select a valid folder path!");
                return;
            }

            if (this.numColumn.Value <= 0)
            {
                MessageBox.Show("Please select a valid column number!");
                return;
            }

            if (this.numRow.Value <= 0)
            {
                MessageBox.Show("Please select a valid row number!");
                return;
            }

            var column = (int)this.numColumn.Value;
            var row = (int)this.numRow.Value;
            var pictures = (from item in Directory.GetFiles(this.txtFolder.Text, "*.png")
                            select new Bitmap(item)).ToArray();
            if (pictures.Length < column * row)
            {
                MessageBox.Show("Not enough picture(*.png) files!");
                return;
            }

            var unitSize = pictures[0].Size;
            var margin = 2;
            var totalSize = new Size(unitSize.Width * column + margin * (column - 1), unitSize.Height * row + margin * (row - 1));
            var totalPicture = new Bitmap(totalSize.Width, totalSize.Height);
            using (var g = Graphics.FromImage(totalPicture))
            {
                int index = 0;
                for (int y = 0; y < row; y++)
                {
                    for (int x = 0; x < column; x++)
                    {
                        g.DrawImage(pictures[index++], x * unitSize.Width + x * margin, y * unitSize.Height + y * margin);
                    }
                }
            }

            totalPicture.Save(Path.Combine(this.txtFolder.Text, "Total.png"));
        }
    }
}
