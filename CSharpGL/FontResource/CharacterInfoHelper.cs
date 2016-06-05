using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CSharpGL
{
    /// <summary>
    /// 绘制一个字符所需要的所有信息
    /// </summary>
    public static class CharacterInfoHelper
    {
        public const string strCharacterInfo = "CharacterInfo";
        public const string strXOffset = "XOffset";
        public const string strYOffset = "YOffset";
        public const string strWidth = "width";
        public const string strHeight = "height";

        public static XElement ToXElement(this CharacterInfo cInfo)
        {
            XElement result = new XElement(strCharacterInfo,
                new XAttribute(strXOffset, cInfo.xoffset),
                new XAttribute(strYOffset, cInfo.yoffset),
                new XAttribute(strWidth, cInfo.width),
                new XAttribute(strHeight, cInfo.height));

            return result;
        }

        public static CharacterInfo Parse(XElement xElement)
        {
            CharacterInfo cInfo = new CharacterInfo();
            cInfo.xoffset = int.Parse(xElement.Attribute(strXOffset).Value);
            cInfo.yoffset = int.Parse(xElement.Attribute(strYOffset).Value);
            cInfo.width = int.Parse(xElement.Attribute(strWidth).Value);
            cInfo.height = int.Parse(xElement.Attribute(strHeight).Value);

            return cInfo;
        }
    }
}
