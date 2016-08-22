using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //private SceneObject GetBoundingBoxObject(params IRectangle3D[] rectangles)
        //{
        //    var boxObj = new SceneObject();
        //    boxObj.Name = string.Format("Box of {0}", rectangles[0]);
        //    {
        //        Rectangle3D rect = rectangles[0].GetRectangle();
        //        for (int i = 1; i < rectangles.Length; i++)
        //        {
        //            rect = rect.Union(rectangles[i].GetRectangle());
        //        }
        //        vec3 lengths = rect.Max - rect.Min;
        //        BoundingBoxRenderer boxRenderer = BoundingBoxRenderer.Create(lengths);
        //        {
        //            vec3 position = rect.Max / 2 + rect.Min / 2;
        //            //boxRenderer.ModelMatrix = glm.translate(mat4.identity(), position);
        //            boxRenderer.ModelMatrix = glm.translate(mat4.identity(), position);
        //        }
        //        //boxRenderer.Initialize();
        //        boxObj.Renderer = boxRenderer;
        //    }

        //    return boxObj;
        //}
        private BoundingBoxRenderer GetBoundingBoxRenderer(params SceneObject[] objects)
        {
            List<IRectangle3D> rectangles = new List<IRectangle3D>();
            foreach (var item in objects)
            {
                rectangles.AddRange(GetAllRectangle3Ds(item));
            }
            return GetBoundingBoxRenderer(rectangles.ToArray());
        }
        private IEnumerable<IRectangle3D> GetAllRectangle3Ds(SceneObject obj)
        {
            var item = obj.Renderer as IRectangle3D;
            if (item != null) { yield return item; }

            foreach (var child in obj.Children)
            {
                foreach (var renderer in GetAllRectangle3Ds(child))
                {
                    yield return renderer;
                }
            }
        }
        private BoundingBoxRenderer GetBoundingBoxRenderer(params IRectangle3D[] rectangles)
        {
            Rectangle3D rect = rectangles[0].GetRectangle();
            for (int i = 1; i < rectangles.Length; i++)
            {
                rect = rect.Union(rectangles[i].GetRectangle());
            }
            vec3 lengths = rect.Max - rect.Min;
            BoundingBoxRenderer boxRenderer = BoundingBoxRenderer.Create(lengths);
            boxRenderer.SwitchList.Add(new LineWidthSwitch(1));
            vec3 position = rect.Max / 2 + rect.Min / 2;
            boxRenderer.ModelMatrix = glm.translate(mat4.identity(), position);

            return boxRenderer;
        }
    }
}
