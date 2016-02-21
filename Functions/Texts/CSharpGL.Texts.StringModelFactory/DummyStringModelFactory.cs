using CSharpGL.GlyphTextures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Texts.StringModelFactory
{
    class DummyStringModelFactory
    {
        /// <summary>
        /// 简单地生成一行文字。
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public StringModel GetModel(string content)
        {
            StringModel model = new StringModel();

            var glyphPositions = new StringModel.GlyphPosition[content.Length];
            int currentWidth = 0; int currentHeight = 0;
            FontResource fontResource = CSharpGL.GlyphTextures.FontResource.Default;
            //fontResource.GenerateBitmapForString(content, 10, 10000);
            //fontResource.CharInfoDict

            var glyphTexCoords = new StringModel.GlyphTexCoord[content.Length];


            var glyphColors = new StringModel.GlyphColor[content.Length];
            for (int i = 0; i < glyphColors.Length; i++)
            {
                glyphColors[i] = new StringModel.GlyphColor(
                    new GLM.vec4(1, 1, 1, 1),
                    new GLM.vec4(1, 1, 1, 1),
                    new GLM.vec4(1, 1, 1, 1),
                    new GLM.vec4(1, 1, 1, 1)
                    );
            }

            return model;
        }
    }
}
