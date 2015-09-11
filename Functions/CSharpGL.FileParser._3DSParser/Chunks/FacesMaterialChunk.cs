using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class FacesMaterialChunk : ChunkBase
    {
        public string UsesMaterial;
        public ushort[] usesIndexes;

        //public static ushort[] allIndexes = new ushort[9998];

        internal override void Process(ParsingContext context)
        {
            var reader = context.reader;
            var chunk = this;

            {
                StringBuilder builder = new StringBuilder();

                byte b = reader.ReadByte();
                uint idx = 0;
                while (b != 0)
                {
                    builder.Append((char)b);
                    b = reader.ReadByte();
                    idx++;
                }
                chunk.BytesRead += idx + 1;

                this.UsesMaterial = builder.ToString();
            }
            {
                ushort length = reader.ReadUInt16();
                chunk.BytesRead += 2;
                Console.WriteLine("	Indices: {0}", length);
                var usesIndexes = new ushort[length];
                for (int ii = 0; ii < usesIndexes.Length; ii++)
                {
                    var value = reader.ReadUInt16();
                    //allIndexes[value] = 1;

                    usesIndexes[ii] = value;
                }
                chunk.BytesRead += (uint)(2 * length);

                this.usesIndexes = usesIndexes;
            }

            // 实际上，这一步已经没有要读取的子内容了。
            ChunkBaseProcess(context);
        }

        public override string ToString()
        {
            //foreach (var item in allIndexes)
            //{
            //    if (item != 1)
            //    {
            //        Console.WriteLine(item + "adfasdfasdfasf");
            //    }
            //}
            return string.Format("{0}, UsesMaterial: {1}, usesIndexes: {2}", this.GetBasicInfo(), UsesMaterial, usesIndexes.Length);
        }
    }
}
