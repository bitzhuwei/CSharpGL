using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace c14d00_HowTransformFeedbackWorks
{
    public partial class Form1 : Form
    {
        private TransformFeedbackCalculator calculator;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.calculator = new TransformFeedbackCalculator(10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float[] inputs = ParseFloats(this.txtIntput.Text);
            if (this.calculator.MaxItemCount < inputs.Length)
            {
                this.calculator = new TransformFeedbackCalculator(inputs.Length);
            }

            this.calculator.UpdateInput(inputs);
            this.calculator.Calculate();
            float[] outputs = this.calculator.GetOutput(inputs.Length);
            string str = Floats2String(outputs);
            this.txtOutput.Text = str;
        }

        private string Floats2String(float[] outputs)
        {
            var builder = new StringBuilder();
            if (outputs.Length > 0)
            {
                {
                    builder.AppendFormat("{0}", outputs[0]);
                }
                for (int i = 1; i < outputs.Length; i++)
                {
                    builder.AppendFormat(", {0}", outputs[i]);
                }
            }

            return builder.ToString();
        }

        static readonly string[] separators = new string[] { "," };
        private float[] ParseFloats(string str)
        {
            string[] parts = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int index = 0;
            var values = new float[parts.Length];
            try
            {
                for (index = 0; index < parts.Length; index++)
                {
                    values[index] = float.Parse(parts[index]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format("Wrong number format:[{0}]", values[index]), "Error", MessageBoxButtons.OK);
            }

            return values;
        }
    }
}
