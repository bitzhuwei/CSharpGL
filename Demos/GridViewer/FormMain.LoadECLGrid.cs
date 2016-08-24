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

                SceneObject gridObj = GetCatesianGridObj(grid, gridProperties, fileName);
                SceneObject[] wellObjects = GetWellObjects(inputData, grid, fileName);
                var list = new List<IRectangle3D>();
                list.Add(gridObj.Renderer as IRectangle3D);
                list.AddRange((from item in wellObjects select (item.Renderer as IRectangle3D)).ToArray());
                BoundingBoxRenderer boxRenderer = GetBoundingBoxRenderer(list.ToArray());
                SceneObject mainObj = boxRenderer.WrapToSceneObject(
                    string.Format("CatesianGrid: {0}", fileName),
                    new ModelScaleScript(),
                    new DumpTreeNodeScript());
                mainObj.Children.Add(gridObj);
                mainObj.Children.AddRange(wellObjects);

                this.scientificCanvas.Scene.RootObject.Children.Add(mainObj);

                vec3 back = this.scientificCanvas.Scene.Camera.GetBack();
                this.scientificCanvas.Scene.Camera.Target = -grid.DataSource.Position;
                this.scientificCanvas.Scene.Camera.Position = this.scientificCanvas.Scene.Camera.Target + back;
                this.scientificCanvas.ColorPalette.SetCodedColor(axisMin, axisMax, step);


                // update tree node.
                TreeNode mainNode = DumpTreeNode(mainObj);
                this.objectsTreeView.Nodes.Add(mainNode);
                this.objectsTreeView.ExpandAll();

                // refresh objects state in scene.
                this.scientificCanvas.Scene.Update();

                // render scene to this canvas.
                this.scientificCanvas.Invalidate();

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

        private SceneObject[] GetWellObjects(SimulationInputData inputData, CatesianGrid grid, string fileName)
        {
            var result = new List<SceneObject>();

            List<CSharpGL.Tuple<WellRenderer, LabelRenderer>> wellList = this.CreateWellList(inputData, grid);
            if (wellList == null) { return result.ToArray(); }
            //this.AddWellNodes(gridderNode, this.scene, well3dList);
            foreach (var item in wellList)
            {
                item.Item1.Initialize();
                SceneObject wellObj = item.Item1.WrapToSceneObject(new ModelScaleScript());
                wellObj.ScriptList.Add(new DumpTreeNodeScript());
                {
                    BoundingBoxRenderer boxRenderer = GetBoundingBoxRenderer(item.Item1);
                    SceneObject boxObj = boxRenderer.WrapToSceneObject(new ModelScaleScript(), new DumpTreeNodeScript());
                    wellObj.Children.Add(boxObj);
                }
                result.Add(wellObj);
                {
                    SceneObject labelObj = item.Item2.WrapToSceneObject(
                        new ModelScaleScript(),
                        new LabelTargetScript(item.Item1),
                        new DumpTreeNodeScript());
                    wellObj.Children.Add(labelObj);
                }
            }

            return result.ToArray();
        }

        private SceneObject GetCatesianGridObj(CatesianGrid grid, List<GridBlockProperty> gridProperties, string fileName)
        {
            CatesianGridRenderer renderer = CatesianGridRenderer.Create(
                -grid.DataSource.Position, grid, this.scientificCanvas.ColorPalette.Sampler);
            //string caseFileName = System.IO.Path.GetFileName(fileName);
            renderer.Name = System.IO.Path.GetFileName(fileName);
            renderer.ModelMatrix = glm.translate(mat4.identity(),
                -grid.DataSource.Position);
            renderer.Initialize();
            SceneObject gridObj = renderer.WrapToSceneObject(
                new ModelScaleScript(),
                new DumpCatesianGridTreeNodeScript());
            {
                var boxRenderer = GetBoundingBoxRenderer(renderer);
                SceneObject boxObj = boxRenderer.WrapToSceneObject(
                    new ModelScaleScript(),
                    new DumpTreeNodeScript());
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
            return well3DHelper.Convert(-grid.DataSource.Position, wellSpecsList, wellCompatList);
        }

    }
}
