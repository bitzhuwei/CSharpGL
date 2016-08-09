using CSharpGL;
using SimLab.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TracyEnergy.Simba.Data.Keywords;
using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    public partial class FormMain : Form
    {

        private void mniLoadECLGrid_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) { return; }

            //ModelContainer modelContainer = this.ModelContainer;

            string fileName = openFileDialog1.FileName;
            SimulationInputData inputData;
            try
            {
                inputData = this.LoadEclInputData(fileName);
            }
            catch (Exception err)
            {
                MessageBox.Show(String.Format("Load Error,{0}", err.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                List<GridBlockProperty> gridProperties = inputData.RootDataFile.GetGridProperties();
                GridBlockProperty firstProperty = gridProperties[0];
                double axisMin, axisMax, step;
                ColorIndicatorAxisAutomator.Automate(firstProperty.MinValue, firstProperty.MaxValue, out axisMin, out axisMax, out step);
                CatesianGrid grid = inputData.DumpCatesianGrid((float)axisMin, (float)axisMax);
                CatesianGridRenderer scientificRenderer = CatesianGridRenderer.Create(grid, this.scientificCanvas.CodedColorSampler);
                scientificRenderer.Initialize();
                var boundedRenderer = new BoundedRenderer(scientificRenderer,
                    grid.DataSource.SourceActiveBounds.Max - grid.DataSource.SourceActiveBounds.Min);
                var obj = new SceneObject();
                obj.Renderer = boundedRenderer;
                var transformScript = new TransformScript();
                transformScript.Position = -grid.DataSource.TranslateMatrix;
                obj.ScriptList.Add(transformScript);
                obj.ScriptList.Add(new BuildInTransformScript());
                this.scientificCanvas.Scene.ObjectList.Add(obj);
                string caseFileName = System.IO.Path.GetFileName(fileName);
                var gridderNode = new SceneObjectTreeNode(obj);
                gridderNode.Text = caseFileName;
                gridderNode.Tag = obj;//TODO: this is not needed any more.
                gridderNode.ToolTipText = grid.GetType().Name;
                this.objectsTreeView.Nodes.Add(gridderNode);
                //if (gridProps.Count <= 0)
                //{
                //    GridBlockProperty gbp = this.CreateGridSequenceGridBlockProperty(gridderSource, "INDEX");
                //    gridProps.Add(gbp);
                //}
                foreach (GridBlockProperty gbp in gridProperties)
                {
                    var script = new ScientificModelScriptComponent(obj, gbp, this.scientificCanvas.uiColorPalette);
                    obj.ScriptList.Add(script);
                    var propNode = new PropertyTreeNode(script);
                    propNode.Text = gbp.Name;
                    propNode.Tag = gbp;
                    gridderNode.Nodes.Add(propNode);
                }

                this.objectsTreeView.ExpandAll();
                //modelContainer.AddChild(gridder);
                //modelContainer.BoundingBox.SetBounds(gridderSource.TransformedActiveBounds.Min, gridderSource.TransformedActiveBounds.Max);
                //this.scene.ViewType = ViewTypes.UserView;

                List<NamedWellRenderer> well3dList;
                try
                {
                    well3dList = this.CreateWellPipelineRenderers(inputData, grid);
                }
                catch (Exception err)
                {
                    MessageBox.Show(String.Format("Create Well3d,{0}", err.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //if (well3dList != null && well3dList.Count > 0)
                //    this.AddWellNodes(gridderNode, this.scene, well3dList);
                //}

                vec3 back = this.scientificCanvas.Scene.Camera.GetBack();
                this.scientificCanvas.Scene.Camera.Target = -grid.DataSource.TranslateMatrix;
                this.scientificCanvas.Scene.Camera.Position = this.scientificCanvas.Scene.Camera.Target + back;
                this.scientificCanvas.Invalidate();

                this.RefreshScene(this.scientificCanvas.Scene, 0);
                this.scientificCanvas.uiColorPalette.SetCodedColor(axisMin, axisMax, step);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private List<NamedWellRenderer> CreateWellPipelineRenderers(SimulationInputData inputData, CatesianGrid grid)
        {
            WellSpecsCollection wellSpecsList = inputData.RootDataFile.GetWELSPECS();
            WellCompatCollection wellCompatList = inputData.RootDataFile.GetCOMPDAT();
            if (wellSpecsList == null || wellSpecsList.Count <= 0)
            {
                throw new ArgumentException("not found WELLSPECS info for the well");
            }
            // rename Well3DHelper to WellPipelineBuilder.
            WellPipelineBuilder well3DHelper = new HexahedronGridWellPipelineBuilder(grid);
            return well3DHelper.Convert(wellSpecsList, wellCompatList);
        }

    }
}
