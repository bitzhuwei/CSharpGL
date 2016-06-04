using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpGL
{
    public static class CharacterInfoDictHelper
    {
        public const string strCharacterInfoDict = "CharacterInfoDict";

        public static XElement ToXElement(this FullDictionary<char, CharacterInfo> dict)
        {
            XElement result = new XElement(strCharacterInfoDict,
                from item in dict
                select KeyValuePairHelper.ToXElement(item));

            return result;
        }

        public static FullDictionary<char, CharacterInfo> Parse(XElement xElement)
        {
            FullDictionary<char, CharacterInfo> result = new FullDictionary<char, CharacterInfo>(
                CharacterInfo.Default);

            foreach (var item in xElement.Elements(KeyValuePairHelper.strKeyValuePair))
            {
                KeyValuePair<char, CharacterInfo> pair = KeyValuePairHelper.Parse(item);
                result.Add(pair.Key, pair.Value);
            }

            return result;
        }
    }
}
