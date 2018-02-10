using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL
{
    public partial class FormBlendFunc : Form
    {
        private static readonly BlendSrcFactor[] sourceFactors;
        private static readonly BlendDestFactor[] destinationFactors;

        static FormBlendFunc()
        {
            {
                var list = new List<BlendSrcFactor>();
                foreach (var item in Enum.GetNames(typeof(BlendSrcFactor)))
                {
                    var value = (BlendSrcFactor)Enum.Parse(typeof(BlendSrcFactor), item);
                    list.Add(value);
                }

                sourceFactors = list.ToArray();
            }
            {
                var list = new List<BlendDestFactor>();
                foreach (var item in Enum.GetNames(typeof(BlendDestFactor)))
                {
                    var value = (BlendDestFactor)Enum.Parse(typeof(BlendDestFactor), item);
                    list.Add(value);
                }

                destinationFactors = list.ToArray();
            }
        }

        public FormBlendFunc()
        {
            InitializeComponent();

            foreach (var item in sourceFactors)
            {
                this.lstSourceFactor.Items.Add(item);
            }

            foreach (var item in destinationFactors)
            {
                this.lstDestinationFactor.Items.Add(item);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public BlendSrcFactor SelectedSourceFactor { get; set; }

        public BlendDestFactor SelectedDestinationFactor { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            {
                var item = this.lstSourceFactor.SelectedItem;
                if (item == null)
                {
                    MessageBox.Show("Please select a source factor!");
                    return;
                }
                this.SelectedSourceFactor = (BlendSrcFactor)item;
            }
            {
                var item = this.lstDestinationFactor.SelectedItem;
                if (item == null)
                {
                    MessageBox.Show("Please select a destination factor!");
                    return;
                }
                this.SelectedDestinationFactor = (BlendDestFactor)item;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


    }
}
