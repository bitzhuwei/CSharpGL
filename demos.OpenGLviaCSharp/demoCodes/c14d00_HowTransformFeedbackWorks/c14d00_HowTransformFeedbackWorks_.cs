using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c14d00_HowTransformFeedbackWorks {
    internal unsafe class c14d00_HowTransformFeedbackWorks_ : demoCode {
        public c14d00_HowTransformFeedbackWorks_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private TransformFeedbackCalculator calculator;

        public override void display(GL gl) {

        }

        public override void init(GL gl) {
            this.calculator = new TransformFeedbackCalculator(10);
            //float[] inputs = ParseFloats(this.txtIntput.Text);
            var inputs = new float[] { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f };
            if (this.calculator.MaxItemCount < inputs.Length) {
                this.calculator = new TransformFeedbackCalculator(inputs.Length);
            }

            this.calculator.UpdateInput(inputs);
            this.calculator.Calculate();
            float[] outputs = this.calculator.GetOutput(inputs.Length);
            string str = Floats2String(outputs);

            //this.txtOutput.Text = str;
            MessageBox.Show(str, "result");

        }
        private string Floats2String(float[] outputs) {
            var builder = new StringBuilder();
            if (outputs.Length > 0) {
                {
                    builder.AppendFormat("{0}", outputs[0]);
                }
                for (int i = 1; i < outputs.Length; i++) {
                    builder.AppendFormat(", {0}", outputs[i]);
                }
            }

            return builder.ToString();
        }

        static readonly string[] separators = new string[] { "," };
        private float[] ParseFloats(string str) {
            string[] parts = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int index = 0;
            var values = new float[parts.Length];
            try {
                for (index = 0; index < parts.Length; index++) {
                    values[index] = float.Parse(parts[index]);
                }
            }
            catch (Exception) {
                MessageBox.Show(string.Format("Wrong number format:[{0}]", values[index]), "Error", MessageBoxButtons.OK);
            }

            return values;
        }

        public override void reshape(GL gl, int width, int height) {

        }
    }
}
