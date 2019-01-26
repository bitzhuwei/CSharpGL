using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PhysicallyBasedRendering
{
    public class HdrFile
    {
        public enum Format
        {
            RGBE,
            XYZE
        }

        public enum Compression
        {
            Uncompressed,
            RLE,
            AdaptiveRLE
        }

        Pixel[] colors;
        public Format format;
        public Compression compression;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public void SetDimensions(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            colors = new Pixel[width * height];
        }

        public void SetColors(Pixel[] c)
        {
            colors = c;
        }

        //public Texture2D ToTexture(bool mipmap, bool linear)
        //{
        //    var tex = new Texture2D(Width, Height, TextureFormat.ARGB32, mipmap, linear);
        //    tex.SetPixels32(colors);
        //    return tex;
        //}
    }


    // Example implementation:
    // http://code.google.com/p/glorg2/source/browse/Glorg2/Glorg2/Resource/HdrImporter.cs?r=cf4dcecac8eae0e7a94bb8f03d6a63e483333a29


    public class HdrAssetImporter
    {
        public static HdrFile ReadHdrFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new System.Exception("File does not exist");
            }

            var hdr = new HdrFile();

            using (var stream = new FileStream(path, FileMode.Open))
            {
                using (var sr = new StreamReader(stream))
                {
                    string header = sr.ReadLine().Trim();
                    if (header != "#?RADIANCE")
                    {
                        throw new System.Exception("File is not in Radiance HDR format.");
                    }
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (line.StartsWith("FORMAT"))
                        {
                            switch (line.Substring(7))
                            {
                            case "32-bit_rle_rgbe":
                                hdr.format = HdrFile.Format.RGBE;
                                break;
                            case "32-bit_rle_xyze":
                                hdr.format = HdrFile.Format.XYZE;
                                throw new System.Exception("XYZE format is not supported.");
                            default:
                                throw new System.Exception("HDR file is of an unknown format.");
                            }
                        }
                        // end of header
                        if (line == string.Empty)
                        {
                            break;
                        }
                    }
                    // Read the dimensions
                    string[] size = sr.ReadLine().Split(' ');
                    // FIXME assuming that it's -Y +X layout
                    int width = int.Parse(size[1]);
                    int height = int.Parse(size[3]);
                    Pixel[] buffer = new Pixel[width * height];

                    hdr.SetDimensions(width, height);

                    var sb = new StringBuilder();
                    var lastColor = new Pixel(0, 0, 0, 0);
                    int cursor = 0;

                    while (cursor < buffer.Length)
                    {
                        byte[] rgbe = new byte[4];
                        stream.Read(rgbe, 0, 4);

                        if (width < 8 || width > 32767)
                        {
                            hdr.compression = HdrFile.Compression.Uncompressed;
                        }
                        else if (cursor == 0 && rgbe[0] == 2 && rgbe[1] == 2)
                        {
                            hdr.compression = HdrFile.Compression.AdaptiveRLE;
                        }

                        Pixel c = new Pixel(rgbe[0], rgbe[1], rgbe[2], rgbe[3]);
                        if (hdr.compression == HdrFile.Compression.AdaptiveRLE)
                        {
                            // TODO
                        }
                        else if (c.r == 255 && c.g == 255 && c.b == 255)
                        {
                            // Old run-length encoding
                            hdr.compression = HdrFile.Compression.RLE;
                            cursor++;
                            for (int i = 0; i < c.a; i++)
                            {
                                buffer[cursor] = lastColor;
                                cursor++;
                            }
                        }
                        else
                        {
                            buffer[cursor] = c;
                        }
                        lastColor = c;
                        cursor++;
                    }

                    hdr.SetColors(buffer);
                }
            }
            return hdr;
        }

        //	static Pixel RgbeToColor (byte[] bytes)
        //	{
        //		var c = new Pixel ();
        //		c.r = RgbeToColorComponent (bytes[0], bytes[3]);
        //		c.g = RgbeToColorComponent (bytes[1], bytes[3]);
        //		c.b = RgbeToColorComponent (bytes[2], bytes[3]);
        //		c.a = 1;
        //		return c;
        //	}

        //	static byte RgbeToColorComponent (byte v, byte e)
        //	{
        //		var exp = System.Convert.ToSingle (e) * 255 - 128;
        //		double f = System.Convert.ToSingle (v) * System.Math.Pow (2, exp);
        //		return System.Convert.ToByte (f);
        //	}
    }
}
