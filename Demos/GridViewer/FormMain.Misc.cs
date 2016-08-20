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

        private SceneObject GetBoundingBoxObject(IModelSize modelSize)
        {
            var boxObj = new SceneObject();
            boxObj.Name = string.Format("Box of {0}", modelSize);
            {
                vec3 lengths = new vec3(modelSize.XLength, modelSize.YLength, modelSize.ZLength);
                BoundingBoxRenderer boxRenderer = BoundingBoxRenderer.Create(lengths);
                {
                    var transform = modelSize as IModelTransform;
                    vec3 position = transform.ModelMatrix.GetTranslate();
                    //boxRenderer.ModelMatrix = glm.translate(mat4.identity(), position);
                    boxRenderer.ModelMatrix = transform.ModelMatrix;
                }
                //boxRenderer.Initialize();
                boxObj.Renderer = boxRenderer;
            }

            return boxObj;
        }
    }
}
