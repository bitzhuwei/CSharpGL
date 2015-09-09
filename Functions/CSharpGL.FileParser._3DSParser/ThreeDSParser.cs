using CSharpGL.FileParser._3DSParser.Chunks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser
{
    /// <summary>
    /// *.3ds文件解析器。
    /// </summary>
    public partial class ThreeDSParser
    {

        /// <summary>
        /// 逐步解析*.3ds文件。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_3dsFilename"></param>
        /// <returns></returns>
        public MainChunk Parse(string _3dsFilename)
        {
            base_dir = new FileInfo(_3dsFilename).DirectoryName + "/";

            file = new FileStream(_3dsFilename, FileMode.Open, FileAccess.Read);

            reader = new BinaryReader(file);
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            ChunkBase chunk = reader.ReadChunk();
            if (chunk.GetID() != (ushort)ThreeDSChunkType.MainChunk)
            { throw new Exception("Not a proper 3DS file."); }

            ProcessChunk(chunk);

            reader.Close();
            file.Close();

            reader = null;
            file = null;

            return chunk as MainChunk;
        }

        private void ProcessChunk(ChunkBase chunk)
        {
            while (chunk.BytesRead < chunk.Length)
            {
                ChunkBase child = reader.ReadChunk();

                switch ((ThreeDSChunkType)child.GetID())
                {
                    case ThreeDSChunkType.CVersion:

                        int version = reader.ReadInt32();
                        child.BytesRead += 4;

                        Console.WriteLine("3DS File Version: {0}", version);
                        break;

                    case ThreeDSChunkType._3DEditorChunk:

                        ChunkBase obj_chunk = reader.ReadChunk();

                        // not sure whats up with this chunk
                        SkipChunk(obj_chunk);
                        child.BytesRead += obj_chunk.BytesRead;

                        ProcessChunk(child);

                        break;

                    case ThreeDSChunkType.EditorMaterial:

                        ProcessMaterialChunk(child);
                        //SkipChunk ( child );
                        break;

                    case ThreeDSChunkType.ObjectBlock:

                        //SkipChunk ( child );
                        string name = ProcessString(child);
                        Console.WriteLine("OBJECT NAME: {0}", name);

                        ThreeDSMesh e = ProcessObjectChunk(child);
                        e.CalculateNormals();
                        model.Entities.Add(e);

                        break;

                    default:

                        SkipChunk(child);
                        break;

                }

                chunk.BytesRead += child.BytesRead;
                //Console.WriteLine ( "ID: {0} Length: {1} Read: {2}", chunk.ID.ToString("x"), chunk.Length , chunk.BytesRead );
            }
        }


        void ProcessMaterialChunk(ChunkBase chunk)
        {
            string name = string.Empty;
            ThreeDSMaterial m = new ThreeDSMaterial();

            while (chunk.BytesRead < chunk.Length)
            {
                ChunkBase child = reader.ReadChunk();

                switch ((ThreeDSChunkType)child.GetID())
                {
                    case ThreeDSChunkType.MaterialName:

                        name = ProcessString(child);
                        Console.WriteLine("Material: {0}", name);
                        break;

                    case ThreeDSChunkType.AmbientColor:

                        m.Ambient = ProcessColorChunk(child);
                        break;

                    case ThreeDSChunkType.DiffuseColor:

                        m.Diffuse = ProcessColorChunk(child);
                        break;

                    case ThreeDSChunkType.SpecularColor:

                        m.Specular = ProcessColorChunk(child);
                        break;

                    case ThreeDSChunkType.C_MATSHININESS:

                        m.Shininess = ProcessPercentageChunk(child);
                        //Console.WriteLine ( "SHININESS: {0}", m.Shininess );
                        break;

                    case ThreeDSChunkType.TextureMap:

                        ProcessPercentageChunk(child);

                        //SkipChunk ( child );
                        ProcessTexMapChunk(child, m);

                        break;

                    default:

                        SkipChunk(child);
                        break;
                }
                chunk.BytesRead += child.BytesRead;
            }
            materials.Add(name, m);
        }

        void ProcessTexMapChunk(ChunkBase chunk, ThreeDSMaterial m)
        {
            while (chunk.BytesRead < chunk.Length)
            {
                ChunkBase child = reader.ReadChunk();
                switch ((ThreeDSChunkType)child.GetID())
                {
                    case ThreeDSChunkType.MappingFilename:

                        string name = ProcessString(child);
                        Console.WriteLine("	Texture File: {0}", name);

                        //FileStream fStream;
                        Bitmap bmp;
                        try
                        {
                            //fStream = new FileStream(base_dir + name, FileMode.Open, FileAccess.Read);
                            bmp = new Bitmap(base_dir + name);
                        }
                        catch (Exception e)
                        {
                            // couldn't find the file
                            Console.WriteLine("	ERROR: could not load file '{0}'", base_dir + name);
                            break;
                        }

                        // Flip image (needed so texture are the correct way around!)
                        bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);

                        System.Drawing.Imaging.BitmapData imgData = bmp.LockBits(new Rectangle(new Point(0, 0), bmp.Size),
                                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        //								System.Drawing.Imaging.PixelFormat.Format24bppRgb ); 

                        m.BindTexture(imgData.Width, imgData.Height, imgData.Scan0);

                        bmp.UnlockBits(imgData);
                        bmp.Dispose();

                        /*
                        BinaryReader br = new BinaryReader(fStream);

                        br.ReadBytes ( 14 ); // skip file header
					
                        uint offset = br.ReadUInt32 (  );
                        //br.ReadBytes ( 4 ); // skip image header
                        uint biWidth = br.ReadUInt32 ();
                        uint biHeight = br.ReadUInt32 ();
                        Console.WriteLine ( "w {0} h {1}", biWidth, biHeight );
                        br.ReadBytes ( (int) offset - 12  ); // skip rest of image header
						
                        byte[,,] tex = new byte [ biHeight , biWidth , 4 ];
						
                        for ( int ii=0 ; ii <  biHeight ; ii++ )
                        {
                            for ( int jj=0 ; jj < biWidth ; jj++ )
                            {
                                tex [ ii, jj, 0 ] = br.ReadByte();
                                tex [ ii, jj, 1 ] = br.ReadByte();
                                tex [ ii, jj, 2 ] = br.ReadByte();
                                tex [ ii, jj, 3 ] = 255;
                                //Console.Write ( ii + " " );
                            }
                        }

                        br.Close();
                        fStream.Close();
                        m.BindTexture ( (int) biWidth, (int) biHeight, tex );
                        */
                        break;

                    default:

                        SkipChunk(child, (int)(chunk.Length - chunk.BytesRead - child.BytesRead));
                        break;

                }
                chunk.BytesRead += child.BytesRead;
            }
        }

        float[] ProcessColorChunk(ChunkBase chunk)
        {
            ChunkBase child = reader.ReadChunk();
            float[] c = new float[] { (float)reader.ReadByte() / 256, (float)reader.ReadByte() / 256, (float)reader.ReadByte() / 256 };
            //Console.WriteLine ( "R {0} G {1} B {2}", c.R, c.B, c.G );
            chunk.BytesRead += (int)child.Length;
            return c;
        }

        int ProcessPercentageChunk(ChunkBase chunk)
        {
            ChunkBase child = reader.ReadChunk();
            int per = reader.ReadUInt16();
            child.BytesRead += 2;
            chunk.BytesRead += child.BytesRead;
            return per;
        }

        ThreeDSMesh ProcessObjectChunk(ChunkBase chunk)
        {
            return ProcessObjectChunk(chunk, new ThreeDSMesh());
        }

        ThreeDSMesh ProcessObjectChunk(ChunkBase chunk, ThreeDSMesh e)
        {
            while (chunk.BytesRead < chunk.Length)
            {
                ChunkBase child = reader.ReadChunk();

                switch ((ThreeDSChunkType)child.GetID())
                {
                    case ThreeDSChunkType.TriangularMesh:

                        ProcessObjectChunk(child, e);
                        break;

                    case ThreeDSChunkType.VerticesList:

                        e.vertices = ReadVertices(child);
                        break;

                    case ThreeDSChunkType.FacesDescription:

                        e.indices = ReadIndices(child);

                        if (child.BytesRead < child.Length)
                            ProcessObjectChunk(child, e);
                        break;

                    case ThreeDSChunkType.FacesMaterial:

                        string name2 = ProcessString(child);
                        Console.WriteLine("	Uses Material: {0}", name2);

                        ThreeDSMaterial mat;
                        if (materials.TryGetValue(name2, out mat))
                            e.material = mat;
                        else
                            Console.WriteLine(" Warning: Material '{0}' not found. ", name2);
                        //throw new Exception ( "Material not found!" );

                        /*
                           int nfaces = reader.ReadUInt16 ();
                           child.BytesRead += 2;
                           Console.WriteLine ( nfaces );

                           for ( int ii=0; ii< nfaces+2; ii++)
                           {
                           Console.Write ( reader.ReadUInt16 () + " " );
                           child.BytesRead += 2;

                           }
                           */
                        SkipChunk(child);
                        break;

                    case ThreeDSChunkType.MappingCoordinatesList:

                        int cnt = reader.ReadUInt16();
                        child.BytesRead += 2;

                        Console.WriteLine("	TexCoords: {0}", cnt);
                        e.texcoords = new TexCoord[cnt];
                        for (int ii = 0; ii < cnt; ii++)
                            e.texcoords[ii] = new TexCoord(reader.ReadSingle(), reader.ReadSingle());

                        child.BytesRead += (cnt * (4 * 2));

                        break;

                    default:

                        SkipChunk(child);
                        break;

                }
                chunk.BytesRead += child.BytesRead;
                //Console.WriteLine ( "	ID: {0} Length: {1} Read: {2}", chunk.ID.ToString("x"), chunk.Length , chunk.BytesRead );
            }
            return e;
        }

        void SkipChunk(ChunkBase chunk, int maxSkip = -1)
        {
            int length = (int)chunk.Length - chunk.BytesRead;
            if (maxSkip != -1)
            {
                if (length > maxSkip)//Something wrong about 3ds file may happen here.
                {
                    length = maxSkip;
                }
            }
            reader.ReadBytes(length);
            chunk.BytesRead += length;
        }

        string ProcessString(ChunkBase chunk)
        {
            StringBuilder sb = new StringBuilder();

            byte b = reader.ReadByte();
            int idx = 0;
            while (b != 0)
            {
                sb.Append((char)b);
                b = reader.ReadByte();
                idx++;
            }
            chunk.BytesRead += idx + 1;

            return sb.ToString();
        }

        Vector[] ReadVertices(ChunkBase chunk)
        {
            ushort numVerts = reader.ReadUInt16();
            chunk.BytesRead += 2;
            Console.WriteLine("	Vertices: {0}", numVerts);
            Vector[] verts = new Vector[numVerts];

            for (int ii = 0; ii < verts.Length; ii++)
            {
                float f1 = reader.ReadSingle();
                float f2 = reader.ReadSingle();
                float f3 = reader.ReadSingle();

                verts[ii] = new Vector(f1, f3, -f2);
                //Console.WriteLine ( verts [ii] );
            }

            //Console.WriteLine ( "{0}   {1}", verts.Length * ( 3 * 4 ), chunk.Length - chunk.BytesRead );

            chunk.BytesRead += verts.Length * (3 * 4);
            //chunk.BytesRead = (int) chunk.Length;
            //SkipChunk ( chunk );

            return verts;
        }

        Triangle[] ReadIndices(ChunkBase chunk)
        {
            ushort numIdcs = reader.ReadUInt16();
            chunk.BytesRead += 2;
            Console.WriteLine("	Indices: {0}", numIdcs);
            Triangle[] idcs = new Triangle[numIdcs];

            for (int ii = 0; ii < idcs.Length; ii++)
            {
                idcs[ii] = new Triangle(reader.ReadUInt16(), reader.ReadUInt16(), reader.ReadUInt16());
                //Console.WriteLine ( idcs [ii] );

                // flags
                reader.ReadUInt16();
            }
            chunk.BytesRead += (2 * 4) * idcs.Length;
            //Console.WriteLine ( "b {0} l {1}", chunk.BytesRead, chunk.Length);

            //chunk.BytesRead = (int) chunk.Length;
            //SkipChunk ( chunk );

            return idcs;
        }

        //public event EventHandler<ParsingArgs> ChunkParsed;
        private string base_dir;
        private BinaryReader reader;
        private FileStream file;
        private ThreeDSModel model = new ThreeDSModel();
        private Dictionary<string, ThreeDSMaterial> materials = new Dictionary<string, ThreeDSMaterial>();
    }
}
