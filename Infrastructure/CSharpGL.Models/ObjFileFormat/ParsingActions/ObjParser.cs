using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Models
{
    /// <summary>
    /// contains indexes of a triangle.
    /// </summary>
    public class ObjParser
    {
        private readonly string objFilename;
        private readonly ParsingActionBase[] parsingActions;
        private readonly GeneralityParsing summaryParsing = new GeneralityParsing();
        private readonly MeshParsing meshParsing = new MeshParsing();
        private readonly NormalParsing normalParsing = new NormalParsing();
        private readonly LocationParsing locationParsing = new LocationParsing();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFilename"></param>
        public ObjParser(string objFilename)
        {
            this.objFilename = objFilename;
            this.parsingActions = new ParsingActionBase[] { summaryParsing, meshParsing, normalParsing, locationParsing, };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ParsingResult Parse()
        {
            var result = new ParsingResult();
            var context = new ObjParsingContext(this.objFilename);

            try
            {
                foreach (var item in this.parsingActions)
                {
                    item.Parse(context);
                }
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }

            return result;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ParsingResult
    {
        /// <summary>
        /// 
        /// </summary>
        public Exception Error { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ObjMesh> MeshList { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ParsingResult()
        {
            this.MeshList = new List<ObjMesh>();
        }
    }
}
