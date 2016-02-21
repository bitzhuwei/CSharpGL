using CSharpGL.GlyphTextures;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Texts.StringModelFactory
{
    public class DummyStringModelFactory
    {
        /// <summary>
        /// 简单地生成一行文字。
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static StringModel GetModel(string content)
        {
            StringModel model = new StringModel();

            var glyphPositions = new StringModel.GlyphPosition[content.Length];
            FontResource fontResource = CSharpGL.GlyphTextures.FontResource.Default;
            var glyphTexCoords = new StringModel.GlyphTexCoord[content.Length];
            //fontResource.GenerateBitmapForString(content, 10, 10000);
            int currentWidth = 0; int currentHeight = 0;
            /*
             * 0     3  4     6 8     11 12   15
             * -------  ------- -------  -------
             * |     |  |     | |     |  |     |
             * |     |  |     | |     |  |     |
             * |     |  |     | |     |  |     |
             * -------  ------- -------  -------
             * 1     2  5     6 9     10 13   14 
             */
            for (int i = 0; i < content.Length; i++)
            {
                char ch = content[i];
                CharacterInfo info = fontResource.CharInfoDict[ch];
                glyphPositions[i] = new StringModel.GlyphPosition(
                    new GLM.vec2(currentWidth, currentHeight + fontResource.FontHeight),
                    new GLM.vec2(currentWidth, currentHeight),
                    new GLM.vec2(currentWidth + info.width, currentHeight),
                    new GLM.vec2(currentWidth + info.width, currentHeight + fontResource.FontHeight));
                const int shrimp = 2;
                glyphTexCoords[i] = new StringModel.GlyphTexCoord(
                    new GLM.vec2((float)(info.xoffset + shrimp) / (float)fontResource.FontBitmap.Width, (float)(currentHeight) / (float)fontResource.FontBitmap.Height),
                    new GLM.vec2((float)(info.xoffset + shrimp) / (float)fontResource.FontBitmap.Width, (float)(currentHeight + fontResource.FontHeight) / (float)fontResource.FontBitmap.Height),
                    new GLM.vec2((float)(info.xoffset - shrimp + info.width) / (float)fontResource.FontBitmap.Width, (float)(currentHeight + fontResource.FontHeight) / (float)fontResource.FontBitmap.Height),
                    new GLM.vec2((float)(info.xoffset - shrimp + info.width) / (float)fontResource.FontBitmap.Width, (float)(currentHeight) / (float)fontResource.FontBitmap.Height)
                    );
                currentWidth += info.width + 10;
            }
            // move to center
            for (int i = 0; i < content.Length; i++)
            {
                StringModel.GlyphPosition position = glyphPositions[i];

                position.leftUp.x -= currentWidth / 2;
                position.leftDown.x -= currentWidth / 2;
                position.rightUp.x -= currentWidth / 2;
                position.rightDown.x -= currentWidth / 2;
                position.leftUp.y -= (currentHeight + fontResource.FontHeight) / 2;
                position.leftDown.y -= (currentHeight + fontResource.FontHeight) / 2;
                position.rightUp.y -= (currentHeight + fontResource.FontHeight) / 2;
                position.rightDown.y -= (currentHeight + fontResource.FontHeight) / 2;

                position.leftUp.x /= (currentHeight + fontResource.FontHeight);
                position.leftDown.x /= (currentHeight + fontResource.FontHeight);
                position.rightUp.x /= (currentHeight + fontResource.FontHeight);
                position.rightDown.x /= (currentHeight + fontResource.FontHeight);
                position.leftUp.y /= (currentHeight + fontResource.FontHeight);
                position.leftDown.y /= (currentHeight + fontResource.FontHeight);
                position.rightUp.y /= (currentHeight + fontResource.FontHeight);
                position.rightDown.y /= (currentHeight + fontResource.FontHeight);
                glyphPositions[i] = position;
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
