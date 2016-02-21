using CSharpGL.GlyphTextures;
using GLM;
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
            FontResource fontResource = CSharpGL.GlyphTextures.FontResource.Default;
            var glyphTexCoords = new StringModel.GlyphTexCoord[content.Length];
            //fontResource.GenerateBitmapForString(content, 10, 10000);
            int currentWidth = 0; int currentHeight = 0;
            /*
             * 0     2  4     6 8     10 12   14  
             * -------  ------- -------  -------
             * |     |  |     | |     |  |     |
             * |     |  |     | |     |  |     |
             * |     |  |     | |     |  |     |
             * -------  ------- -------  -------
             * 1     3  5     7 9     11 13   15 
             */
            for (int i = 0; i < content.Length; i++)
            {
                char ch = content[i];
                CharacterInfo info = fontResource.CharInfoDict[ch];
                glyphPositions[i] = new StringModel.GlyphPosition(
                    new GLM.vec2(currentWidth, currentHeight),
                    new GLM.vec2(currentWidth, currentHeight + fontResource.FontHeight),
                    new GLM.vec2(currentWidth + info.width, currentHeight),
                    new GLM.vec2(currentWidth + info.width, currentHeight + fontResource.FontHeight));
                glyphTexCoords[i] = new StringModel.GlyphTexCoord(
                    new GLM.vec2(info.xoffset, info.yoffset),
                    new GLM.vec2(info.xoffset, info.yoffset + info.height),
                    new GLM.vec2(info.xoffset + info.width, info.yoffset),
                    new GLM.vec2(info.xoffset + info.width, info.yoffset + info.height)
                    );
                currentWidth += info.width;
            }
            // move to center
            for (int i = 0; i < content.Length; i++)
            {
                StringModel.GlyphPosition position = glyphPositions[i];
                position.leftUp.x -= currentWidth / 2;
                position.leftDown.x -= currentWidth / 2;
                position.rightUp.x -= currentWidth / 2;
                position.rightDown.x -= currentWidth / 2;
            }

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

            model.positions = glyphPositions;
            model.texCoords = glyphTexCoords;
            model.colors = glyphColors;
            model.glyphTexture = FontTextureManager.Instance.GetTexture2D(fontResource.FontBitmap);

            return model;
        }
    }
}
