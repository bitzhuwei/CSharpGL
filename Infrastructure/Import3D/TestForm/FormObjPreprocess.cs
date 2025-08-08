using Import3D;
using Import3D.Obj;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm {
    public partial class FormObjPreprocess : Form {
        public FormObjPreprocess() {
            InitializeComponent();
        }

        private void FormObjPreprocess_Load(object sender, EventArgs e) {
            var filenames = Directory.GetFiles("../../../../Import3D.Obj/models/examples-obj_spec", "*.obj.txt");
            foreach (var filename in filenames) {
                var text = File.ReadAllText(filename);
                var builder = new StringBuilder();
                using (var reader = new StreamReader(filename)) {
                    var preprocessed = Import3D.Obj.ObjFilePreprocessor.Preprocess(reader);
                    foreach (var line in preprocessed.lines) {
                        builder.AppendLine(line);
                    }
                }
                var objFileModel = Import3D.Obj.ObjFileParser.Parse(filename, modelName: filename);
                var scene = new Import3D.aiScene(name: filename);
                Import3D.Obj.ObjSceneBuilder.BuildScene(objFileModel, scene);
                var item = new PreprocessItem(filename, text, builder.ToString());
                this.cmbTestCases.Items.Add(item);
            }
            if (filenames.Length == 0) {
                MessageBox.Show("No test case found");
            }
        }

        private void cmbTestCases_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.cmbTestCases.SelectedItem is PreprocessItem item) {
                this.txtSource.Text = item.sourceCode;
                this.txtPreprocessed.Text = item.preprocessed;
            }
        }
    }

    class PreprocessItem {
        public readonly string filename;
        public readonly string sourceCode;
        public readonly string preprocessed;

        public PreprocessItem(string filename, string sourceCode, string preprocessed) {
            this.filename = filename;
            this.sourceCode = sourceCode;
            this.preprocessed = preprocessed;
        }

        public override string ToString() {
            return this.filename;
        }
    }
}
