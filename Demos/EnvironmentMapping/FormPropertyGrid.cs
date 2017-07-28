using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EnvironmentMapping
{
    public partial class FormPropertyGrid : Form
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public FormPropertyGrid(object target)
        {
            InitializeComponent();

            this.propertyGrid1.SelectedObject = target;
        }

    }
}
