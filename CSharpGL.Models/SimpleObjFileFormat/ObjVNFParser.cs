using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public unsafe class ObjVNFParser {
        private readonly ObjParserBase[] parserList;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quad2triangle"></param>
        /// <param name="reverseNormal"></param>
        public ObjVNFParser(bool quad2triangle = true, bool reverseNormal = false) {
            var generalityParser = new GeneralityParser();
            var meshParser = new MeshParser();
            var normalParser = new NormalParser();
            var texCoordParser = new TexCoordParser();
            var tangentParser = new TangentParser();
            var locationParser = new LocationParser();
            var list = new List<ObjParserBase>();
            list.Add(new GeneralityParser());
            list.Add(new MeshParser());
            list.Add(new NormalParser(reverseNormal));
            list.Add(new TexCoordParser());
            if (quad2triangle) { list.Add(new Quad2TriangleParser()); }
            list.Add(new TangentParser());
            list.Add(new LocationParser());

            this.parserList = list.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public ObjVNFResult Parse(string filename) {
            ObjVNFResult result = new ObjVNFResult();
            var context = new ObjVNFContext(filename);
            try {
                foreach (var item in this.parserList) {
                    item.Parse(context);
                }

                result.Mesh = context.Mesh;
            }
            catch (Exception ex) {
                result.Error = ex;
            }

            return result;
        }
    }
}
