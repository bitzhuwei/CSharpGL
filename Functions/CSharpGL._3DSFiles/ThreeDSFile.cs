// Title:	ThreeDSFile.cs
// Author: 	Scott Ellington <scott.ellington@gmail.com>
//
// Copyright (C) 2006 Scott Ellington and authors
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using System.Drawing;

namespace CSharpGL._3DSFiles
{
    /*
0x4D4D // Main Chunk
©À©¤ 0x0002 // M3D Version
©À©¤ 0x3D3D // 3D Editor Chunk
©¦  ©À©¤ 0x4000 // Object Block
©¦  ©¦  ©À©¤ 0x4100 // Triangular Mesh
©¦  ©¦  ©¦  ©À©¤ 0x4110 // Vertices List
©¦  ©¦  ©¦  ©À©¤ 0x4120 // Faces Description
©¦  ©¦  ©¦  ©¦  ©À©¤ 0x4130 // Faces Material
©¦  ©¦  ©¦  ©¦  ©¸©¤ 0x4150 // Smoothing Group List
©¦  ©¦  ©¦  ©À©¤ 0x4140 // Mapping Coordinates List
©¦  ©¦  ©¦  ©¸©¤ 0x4160 // Local Coordinates System
©¦  ©¦  ©À©¤ 0x4600 // Light
©¦  ©¦  ©¦  ©¸©¤ 0x4610 // Spotlight
©¦  ©¦  ©¸©¤ 0x4700 // Camera
©¦  ©¸©¤ 0xAFFF // Material Block
©¦     ©À©¤ 0xA000 // Material Name
©¦     ©À©¤ 0xA010 // Ambient Color
©¦     ©À©¤ 0xA020 // Diffuse Color
©¦     ©À©¤ 0xA030 // Specular Color
©¦     ©À©¤ 0xA200 // Texture Map 1
©¦     ©À©¤ 0xA230 // Bump Map
©¦     ©¸©¤ 0xA220 // Reflection Map
©¦        ©¦  // Sub Chunks For Each Map 
©¦        ©À©¤ 0xA300 // Mapping Filename
©¦        ©¸©¤ 0xA351 // Mapping Parameters
©¸©¤ 0xB000 // Keyframer Chunk
   ©À©¤ 0xB002 // Mesh Information Block
   ©À©¤ 0xB007 // Spot Light Information Block
   ©¸©¤ 0xB008 // Frames (Start and End)
      ©À©¤ 0xB010 // Object Name
      ©À©¤ 0xB013 // Object Pivot Point
      ©À©¤ 0xB020 // Position Track
      ©À©¤ 0xB021 // Rotation Track
      ©À©¤ 0xB022 // Scale Track
      ©¸©¤ 0xB030 // Hierarchy Position
     */
    /// <summary>
    /// 
    /// </summary>
    public class ThreeDSFile
    {
        enum ThreeDSChunkType
        {
            MainChunk = 0x4D4D,
            /// <summary>
            /// this is the start of the editor config
            /// </summary>
            _3DEditorChunk = 0x3D3D,
            CVersion = 0x0002,
            /// <summary>
            /// this is the start of the keyframer config
            /// </summary>
            KeyFramerChunk = 0xB000,//todo
            /// <summary>
            /// sub defines of _3DEditorChunk
            /// </summary>
            EditorMaterial = 0xAFFF,

            MaterialName = 0xA000,
            AmbientColor = 0xA010,
            DiffuseColor = 0xA020,
            SpecularColor = 0xA030,
            C_MATSHININESS = 0xA040,
            TextureMap = 0xA200,
            MappingFilename = 0xA300,
            ObjectBlock = 0x4000,
            TriangularMesh = 0x4100,
            VerticesList = 0x4110,
            FacesDescription = 0x4120,
            FacesMaterial = 0x4130,
            /// <summary>
            /// UV
            /// </summary>
            MappingCoordinatesList = 0x4140,


        }

        class ThreeDSChunk
        {
            public ushort ID;
            public uint Length;
            public int BytesRead;

            public ThreeDSChunk(BinaryReader reader)
            {
                // 2 byte ID
                ID = reader.ReadUInt16();
                //Console.WriteLine ("ID: {0}", ID.ToString("x"));

                // 4 byte length
                Length = reader.ReadUInt32();
                //Console.WriteLine ("Length: {0}", Length);

                // = 6
                BytesRead = 6;
            }

            public override string ToString()
            {
                return string.Format("{0}, {1}, {2}", (ThreeDSChunkType)ID, Length, BytesRead);
                //return base.ToString();
            }
        }

        BinaryReader reader;

        ThreeDSModel model = new ThreeDSModel();
        public ThreeDSModel ThreeDSModel
        {
            get
            {
                return model;
            }
        }

        Dictionary<string, ThreeDSMaterial> materials = new Dictionary<string, ThreeDSMaterial>();

        string base_dir;

        public ThreeDSFile(string file_name)
        {
            base_dir = new FileInfo(file_name).DirectoryName + "/";

            FileStream file;
            file = new FileStream(file_name, FileMode.Open, FileAccess.Read);

            reader = new BinaryReader(file);
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            ThreeDSChunk chunk = new ThreeDSChunk(reader);
            if (chunk.ID != (short)ThreeDSChunkType.MainChunk)
                throw new Exception("Not a proper 3DS file.");

            ProcessChunk(chunk);

            reader.Close();
            file.Close();
        }

        void ProcessChunk(ThreeDSChunk chunk)
        {
            while (chunk.BytesRead < chunk.Length)
            {
                ThreeDSChunk child = new ThreeDSChunk(reader);

                switch ((ThreeDSChunkType)child.ID)
                {
                    case ThreeDSChunkType.CVersion:

                        int version = reader.ReadInt32();
                        child.BytesRead += 4;

                        Console.WriteLine("3DS File Version: {0}", version);
                        break;

                    case ThreeDSChunkType._3DEditorChunk:

                        ThreeDSChunk obj_chunk = new ThreeDSChunk(reader);

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

        void ProcessMaterialChunk(ThreeDSChunk chunk)
        {
            string name = string.Empty;
            ThreeDSMaterial m = new ThreeDSMaterial();

            while (chunk.BytesRead < chunk.Length)
            {
                ThreeDSChunk child = new ThreeDSChunk(reader);

                switch ((ThreeDSChunkType)child.ID)
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

        void ProcessTexMapChunk(ThreeDSChunk chunk, ThreeDSMaterial m)
        {
            while (chunk.BytesRead < chunk.Length)
            {
                ThreeDSChunk child = new ThreeDSChunk(reader);
                switch ((ThreeDSChunkType)child.ID)
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

        float[] ProcessColorChunk(ThreeDSChunk chunk)
        {
            ThreeDSChunk child = new ThreeDSChunk(reader);
            float[] c = new float[] { (float)reader.ReadByte() / 256, (float)reader.ReadByte() / 256, (float)reader.ReadByte() / 256 };
            //Console.WriteLine ( "R {0} G {1} B {2}", c.R, c.B, c.G );
            chunk.BytesRead += (int)child.Length;
            return c;
        }

        int ProcessPercentageChunk(ThreeDSChunk chunk)
        {
            ThreeDSChunk child = new ThreeDSChunk(reader);
            int per = reader.ReadUInt16();
            child.BytesRead += 2;
            chunk.BytesRead += child.BytesRead;
            return per;
        }

        ThreeDSMesh ProcessObjectChunk(ThreeDSChunk chunk)
        {
            return ProcessObjectChunk(chunk, new ThreeDSMesh());
        }

        ThreeDSMesh ProcessObjectChunk(ThreeDSChunk chunk, ThreeDSMesh e)
        {
            while (chunk.BytesRead < chunk.Length)
            {
                ThreeDSChunk child = new ThreeDSChunk(reader);

                switch ((ThreeDSChunkType)child.ID)
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

        void SkipChunk(ThreeDSChunk chunk, int maxSkip = -1)
        {
            int length = (int)chunk.Length - chunk.BytesRead;
            if (maxSkip != -1)
            {
                if (length > maxSkip)//Something wrong about 3ds file may happen here.
                {
                    length = maxSkip;
                }
            }
            //reader.ReadBytes(length);
            reader.BaseStream.Position += length;
            chunk.BytesRead += length;
        }

        string ProcessString(ThreeDSChunk chunk)
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

        Vector[] ReadVertices(ThreeDSChunk chunk)
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

        Triangle[] ReadIndices(ThreeDSChunk chunk)
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

        /*
           public static void Main (string[] argv)
           {
           if (argv.Length <= 0) return;
           new ThreeDSFile ( argv[0] );
           }
           */
    }
}
