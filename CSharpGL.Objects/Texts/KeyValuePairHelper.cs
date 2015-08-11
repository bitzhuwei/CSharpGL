using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpGL.Objects.Texts
{
    public static class KeyValuePairHelper
    {
        public const string strKeyValuePair = "KeyValuePair";
        public const string strCharacter = "Character";

        public static XElement ToXElement(this KeyValuePair<char, CharacterInfo> pair)
        {
            XElement result = new XElement(strKeyValuePair,
                new XAttribute(strCharacter, (int)pair.Key),
                pair.Value.ToXElement());

            return result;
        }

        public static KeyValuePair<char, CharacterInfo> Parse(XElement xElement)
        {
            char c = (char)int.Parse(xElement.Attribute(strCharacter).Value);
            CharacterInfo cInfo = CharacterInfoHelper.Parse(xElement.Element(CharacterInfoHelper.strCharacterInfo));

            KeyValuePair<char, CharacterInfo> result = new KeyValuePair<char, CharacterInfo>(c, cInfo);

            return result;
        }
    }
}
