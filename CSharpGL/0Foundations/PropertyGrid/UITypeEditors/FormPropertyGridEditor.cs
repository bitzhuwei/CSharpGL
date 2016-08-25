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
    partial class FormPropertyGridEditor : Form
    {
        private ITypeDescriptorContext context;
        private IServiceProvider provider;

        public FormPropertyGridEditor(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            InitializeComponent();

            this.context = context;
            this.provider = provider;
            this.propertyGrid.SelectedObject = value;
            this.Text = string.Format("{0} - Property Editor", value);
            if (value != null)
            { this.lblProperty.Text = string.Format("{0}", value.GetType()); }
            else
            { this.lblProperty.Text = string.Format("NULL"); }
            this.propertyGrid.PropertyValueChanged += propertyGrid_PropertyValueChanged;
        }

        void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var sceneObject = context.Instance as SceneObject;
            if (sceneObject != null)
            {
                sceneObject.UpdateRender();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}
