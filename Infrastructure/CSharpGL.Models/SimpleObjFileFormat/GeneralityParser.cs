using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class GeneralityParser : ObjParserBase
    {
        private readonly char[] separator = new char[] { ' ' };
        public override void Parse(ObjVNFContext context)
        {
            string filename = context.ObjFilename;
            using (var reader = new System.IO.StreamReader(filename))
            {
                int vertexCount = 0, normalCount = 0, faceCount = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length <= 0) { continue; }
                    if (parts[0] == "v") { vertexCount++; }
                    else if (parts[0] == "vn") { normalCount++; }
                    else if (parts[0] == "f") { faceCount++; }
                }
                context.vertexCount = vertexCount;
                context.normalCount = normalCount;
                context.faceCount = faceCount;
            }
        }
    }
}
