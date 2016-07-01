using CSharpGL;
using SimLab.helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using TracyEnergy.Simba.Data.Keywords;
using TracyEnergy.Simba.Data.Keywords.impl;

namespace GridViewer
{
    public partial class FormMain : Form
    {

        private void mniLoadECLGrid_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

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
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\HexahedronGrid.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\HexahedronGrid.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("in_Position", CatesianGrid.strPosition);
                map.Add("in_uv", CatesianGrid.strColor);
                var scientificRenderer = new Renderer(grid, shaderCodes, map);
                var boundedRenderer = new BoundedRenderer(scientificRenderer,
                    grid.DataSource.SourceActiveBounds.Max - grid.DataSource.SourceActiveBounds.Min, this.scientificCanvas.CodedColorSampler);
                boundedRenderer.Initialize();
                SceneObject sceneObject = new SceneObject();
                sceneObject.Name = typeof(CatesianGrid).Name;
                sceneObject.Renderer = new BoundedRendererComponent(boundedRenderer);
                //sceneObject.Transform.Position = grid.DataSource.TranslateMatrix;
                this.scientificCanvas.Scene.ObjectList.Add(sceneObject);
                string caseFileName = System.IO.Path.GetFileName(fileName);
                TreeNode gridderNode = this.objectsTreeView.Nodes.Add(caseFileName);
                gridderNode.Tag = grid;
                gridderNode.ToolTipText = fileName;
                //if (gridProps.Count <= 0)
                //{
                //    GridBlockProperty gbp = this.CreateGridSequenceGridBlockProperty(gridderSource, "INDEX");
                //    gridProps.Add(gbp);
                //}
                foreach (GridBlockProperty gbp in gridProperties)
                {
                    TreeNode propNode = gridderNode.Nodes.Add(gbp.Name);
                    propNode.Tag = gbp;
                }

                this.objectsTreeView.ExpandAll();
                this.scientificCanvas.uiCodedColorBar.UpdateValues(firstProperty);
                //modelContainer.AddChild(gridder);
                //modelContainer.BoundingBox.SetBounds(gridderSource.TransformedActiveBounds.Min, gridderSource.TransformedActiveBounds.Max);
                //this.scene.ViewType = ViewTypes.UserView;

                //List<Well> well3dList;
                //try
                //{
                //    well3dList = this.CreateWell3D(inputData, this.scene, gridderSource);
                //}
                //catch (Exception err)
                //{
                //    MessageBox.Show(String.Format("Create Well3d,{0}", err.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //if (well3dList != null && well3dList.Count > 0)
                //    this.AddWellNodes(gridderNode, this.scene, well3dList);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private SimulationInputData LoadEclInputData(String fileName)
        {
            KeywordSchema schema = KeywordSchemaExtension.RestoreSchemaFromEmbededResource();
            SimulationInputData inputData = new SimulationInputData(schema);
            inputData.ThrowError = true;
            inputData.LoadFromFile(fileName);
            return inputData;
        }
    }
}
