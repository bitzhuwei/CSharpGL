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

                var mainObj = new SceneObject();
                mainObj.Name = string.Format("CatesianGrid: {0}", fileName);
                mainObj.ScriptList.Add(new DumpTreeNodeScript());
                SceneObject gridObj = AddCatesianGridObj(grid, gridProperties, fileName);
                mainObj.Children.Add(gridObj);
                SceneObject[] wellObjects = AddWellObjects(inputData, grid, fileName);
                mainObj.Children.AddRange(wellObjects);
                BoundingBoxRenderer boxRenderer = GetBoundingBoxRenderer(mainObj);
                mainObj.Renderer = boxRenderer;
                this.scientificCanvas.Scene.ObjectList.Add(mainObj);

                vec3 back = this.scientificCanvas.Scene.Camera.GetBack();
                this.scientificCanvas.Scene.Camera.Target = -grid.DataSource.Position;
                this.scientificCanvas.Scene.Camera.Position = this.scientificCanvas.Scene.Camera.Target + back;
                this.scientificCanvas.ColorPalette.SetCodedColor(axisMin, axisMax, step);

                // refresh objects state in scene.
                this.scientificCanvas.Scene.Start(1);

                // update tree node.
                TreeNode mainNode = DumpTreeNode(mainObj);
                this.objectsTreeView.Nodes.Add(mainNode);

                // render scene to this canvas.
                this.scientificCanvas.Invalidate();

                this.objectsTreeView.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private TreeNode DumpTreeNode(SceneObject obj)
        {
            TreeNode node = null;
            DumpTreeNodeScript script = obj.GetScript<DumpTreeNodeScript>();
            if (script != null)
            {
                node = script.DumpTreeNode();
            }

            if (node != null)
            {
                foreach (var item in obj.Children)
                {
                    TreeNode child = DumpTreeNode(item);
                    if (child != null)
                    {
                        node.Nodes.Add(child);
                    }
                }
            }

            return node;
        }

        private SceneObject[] AddWellObjects(SimulationInputData inputData, CatesianGrid grid, string fileName)
        {
            var result = new List<SceneObject>();

            List<CSharpGL.Tuple<WellRenderer, LabelRenderer>> wellList;
            wellList = this.CreateWellList(inputData, grid);
            if (wellList == null) { return result.ToArray(); }
            //this.AddWellNodes(gridderNode, this.scene, well3dList);
            foreach (var item in wellList)
            {
                //item.Item1.ModelTransformUpdated+=
                var wellObj = new SceneObject();
                wellObj.Name = string.Format("SceneObject: {0}", item.Item1.Name);
                wellObj.Renderer = item.Item1;
                wellObj.ScriptList.Add(new DumpTreeNodeScript());
                {
                    item.Item1.Initialize();
                    BoundingBoxRenderer boxRenderer = GetBoundingBoxRenderer(item.Item1);
                    var boxObj = new SceneObject();
                    boxObj.Name = string.Format("{0}", boxRenderer);
                    boxObj.Renderer = boxRenderer;
                    boxObj.ScriptList.Add(new DumpTreeNodeScript());
                    wellObj.Children.Add(boxObj);
                }
                result.Add(wellObj);
                {
                    var labelObj = new SceneObject();
                    labelObj.Renderer = item.Item2;
                    labelObj.Name = string.Format("SceneObject: {0}", item.Item2.Name);
                    labelObj.ScriptList.Add(new LabelTargetScript(item.Item1));
                    labelObj.ScriptList.Add(new DumpTreeNodeScript());
                    wellObj.Children.Add(labelObj);
                }
            }

            return result.ToArray();
        }

        private SceneObject AddCatesianGridObj(CatesianGrid grid, List<GridBlockProperty> gridProperties, string fileName)
        {
            CatesianGridRenderer renderer = CatesianGridRenderer.Create(grid, this.scientificCanvas.ColorPalette.Sampler);
            //string caseFileName = System.IO.Path.GetFileName(fileName);
            renderer.Name = System.IO.Path.GetFileName(fileName);
            renderer.ModelMatrix = glm.translate(mat4.identity(),
                -grid.DataSource.Position);
            renderer.Initialize();
            var gridObj = new SceneObject();
            gridObj.Name = renderer.Name;
            gridObj.Renderer = renderer;
            gridObj.ScriptList.Add(new DumpCatesianGridTreeNodeScript());
            {
                var boxRenderer = GetBoundingBoxRenderer(renderer);
                var boxObj = new SceneObject();
                boxObj.Name = string.Format("{0}", boxRenderer);
                boxObj.Renderer = boxRenderer;
                gridObj.Children.Add(boxObj);
            }

            foreach (GridBlockProperty gbp in gridProperties)
            {
                var script = new ScientificModelScript(gridObj, gbp, this.scientificCanvas.ColorPalette);
                gridObj.ScriptList.Add(script);
            }
            return gridObj;
        }

        private List<CSharpGL.Tuple<WellRenderer, LabelRenderer>> CreateWellList(SimulationInputData inputData, CatesianGrid grid)
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
