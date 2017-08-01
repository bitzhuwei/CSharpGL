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
        private readonly ObjParserBase[] parserList;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quad2triangle"></param>
        public ObjVNFParser(bool quad2triangle)
        {
            var generality = new GeneralityParser();
            var meshParser = new MeshParser();
            var normalParser = new NormalParser();
            var locationParser = new LocationParser();
            if (quad2triangle)
            {
                this.parserList = new ObjParserBase[] { generality, meshParser, normalParser, new Quad2TriangleParser(), locationParser, };
            }
            else
            {
                this.parserList = new ObjParserBase[] { generality, meshParser, normalParser, locationParser, };
            }
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
