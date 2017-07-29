using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjVNFParser
    {
        private readonly ObjParserBase generality = new GeneralityParser();
        private readonly ObjParserBase meshParser = new MeshParser();
        private readonly ObjParserBase normalParser = new NormalParser();
        private readonly ObjParserBase locationParser = new LocationParser();
        private readonly ObjParserBase[] parserList;

        /// <summary>
        /// 
        /// </summary>
        public ObjVNFParser()
        {
            this.parserList = new ObjParserBase[] { generality, meshParser, normalParser, locationParser, };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public ObjVNFResult Parse(string filename)
        {
            ObjVNFResult result = new ObjVNFResult();
            var context = new ObjVNFContext(filename);
            try
            {
                foreach (var item in this.parserList)
                {
                    item.Parse(context);
                }

                result.Mesh = context.Mesh;
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }

            return result;
        }
    }
}
