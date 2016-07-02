using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace GridViewer
{
    public partial class FormProperyGrid : Form
    {

        public PropertyGrid PropertyGrid { get { return this.propertyGrid1; } }

        public FormProperyGrid(object obj = null)
        {
            InitializeComponent();
            this.DisplayObject(obj);
        }

        public void DisplayObject(object obj)
        {
            if (!this.IsDisposed)
            {
                this.propertyGrid1.SelectedObject = obj;
                this.Text = string.Format("{0}", obj);
            }
        }
    }
}
