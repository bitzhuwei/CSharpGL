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
        private static readonly BlendingSourceFactor[] sourceFactors;
        private static readonly BlendingDestinationFactor[] destinationFactors;

        static FormBlendFunc()
        {
            {
                var list = new List<BlendingSourceFactor>();
                foreach (var item in Enum.GetNames(typeof(BlendingSourceFactor)))
                {
                    var value = (BlendingSourceFactor)Enum.Parse(typeof(BlendingSourceFactor), item);
                    list.Add(value);
                }

                sourceFactors = list.ToArray();
            }
            {
                var list = new List<BlendingDestinationFactor>();
                foreach (var item in Enum.GetNames(typeof(BlendingDestinationFactor)))
                {
                    var value = (BlendingDestinationFactor)Enum.Parse(typeof(BlendingDestinationFactor), item);
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

        public BlendingSourceFactor SelectedSourceFactor { get; set; }

        public BlendingDestinationFactor SelectedDestinationFactor { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            {
                var item = this.lstSourceFactor.SelectedItem;
                if (item == null)
                {
                    MessageBox.Show("Please select a source factor!");
                    return;
                }
                this.SelectedSourceFactor = (BlendingSourceFactor)item;
            }
            {
                var item = this.lstDestinationFactor.SelectedItem;
                if (item == null)
                {
                    MessageBox.Show("Please select a destination factor!");
                    return;
                }
                this.SelectedDestinationFactor = (BlendingDestinationFactor)item;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


    }
}
