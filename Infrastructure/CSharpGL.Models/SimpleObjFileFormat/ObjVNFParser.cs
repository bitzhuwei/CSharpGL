using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ObjVNFParser
    {
        private readonly ObjParserBase generality = new GeneralityParser();
        private readonly ObjParserBase meshParser = new MeshParser();
        private readonly ObjParserBase normalParser = new NormalParser();
        private readonly ObjParserBase locationParser = new LocationParser();
        private readonly ObjParserBase[] parserList;

        public ObjVNFParser()
        {
            this.parserList = new ObjParserBase[] { generality, meshParser, normalParser, locationParser, };
        }
        public ObjVNFResult Parse(ObjVNFContext context)
        {
            ObjVNFResult result = new ObjVNFResult();
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
