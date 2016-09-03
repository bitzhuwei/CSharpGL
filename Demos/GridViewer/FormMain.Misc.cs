using CSharpGL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TracyEnergy.Simba.Data.Keywords;

namespace GridViewer
{
    public partial class FormMain : Form
    {
        private SimulationInputData LoadEclInputData(String fileName)
        {
            KeywordSchema schema = KeywordSchemaExtension.RestoreSchemaFromEmbededResource();
            SimulationInputData inputData = new SimulationInputData(schema);
            inputData.ThrowError = true;
            inputData.LoadFromFile(fileName);
            return inputData;
        }

        private BoundingBoxRenderer GetBoundingBoxRenderer(params SceneObject[] objects)
        {
            var rectangles = new List<IBoundingBox>();
            foreach (var item in objects)
            {
                rectangles.AddRange(GetAllRectangle3Ds(item));
            }
            return rectangles.GetBoundingBoxRenderer();
        }

        private IEnumerable<IBoundingBox> GetAllRectangle3Ds(SceneObject obj)
        {
            var item = obj.Renderer as IBoundingBox;
            if (item != null) { yield return item; }

            foreach (var child in obj.Children)
            {
                foreach (var renderer in GetAllRectangle3Ds(child))
                {
                    yield return renderer;
                }
            }
        }

    }
}