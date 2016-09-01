using System;
using System.ComponentModel;

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

            this.lblSelectedType.Text = string.Empty;

            this.context = context;
            this.provider = provider;
            this.propertyGrid.SelectedObject = value;
            this.Text = string.Format("{0} - Property Editor", value);
            if (value != null)
            { this.lblSelectedType.Text = string.Format("{0}", value.GetType()); }
            else
            { this.lblSelectedType.Text = string.Format("NULL"); }
            this.propertyGrid.PropertyValueChanged += propertyGrid_PropertyValueChanged;
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var sceneObject = context.Instance as SceneObject;
            if (sceneObject != null)
            {
                sceneObject.UpdateAndRender();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}