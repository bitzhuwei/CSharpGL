using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Picture.DDS
{
    public partial class vgl
    {
        public static void vglLoadDDS(string filename, ref vglImageData image)
        {
            System.IO.FileStream f = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader br = new System.IO.BinaryReader(f);

            //DDS_FILE_HEADER file_header = { 0, };
            DDS_FILE_HEADER file_header = new DDS_FILE_HEADER();

            //fread(&file_header, sizeof(file_header.magic) + sizeof(file_header.std_header), 1, f);
            file_header = br.ReadStruct<DDS_FILE_HEADER>();

            if (file_header.magic != DDSSignal.DDS_MAGIC)
            {
                goto done_close_file;
            }

            if (file_header.std_header.ddspf.dwFourCC == DDSSignal.DDS_FOURCC_DX10)
            {
                //fread(&file_header.dxt10_header, sizeof(file_header.dxt10_header), 1, f);
                f.Position = Marshal.SizeOf(file_header.magic) + Marshal.SizeOf(file_header.std_header);
                file_header.dxt10_header = br.ReadStruct<DDS_HEADER_DXT10>();
            }

            if (!vgl_DDSHeaderToImageDataHeader(ref file_header, ref image))
                goto done_close_file;

            image.target = vgl_GetTargetFromDDSHeader(ref file_header);

            if (image.target == GL.GL_NONE)
                goto done_close_file;

            //int current_pos = ftell(f);
            long current_pos = f.Position;
            long file_size = f.Length;

            image.totalDataSize = (int)(file_size - current_pos);
            var data = new UnmanagedArray<byte>(image.totalDataSize);
            image.mip[0].data = data.Header;
            //image.mip[0].data = new byte[image.totalDataSize];

            //fread(image.mip[0].data, file_size - current_pos, 1, f);
            for (int i = 0; i < image.totalDataSize; i++)
            {
                data[i] = br.ReadByte();
            }

            int level;
            IntPtr ptr = image.mip[0].data;

            uint width = file_header.std_header.width;
            uint height = file_header.std_header.height;
            uint depth = file_header.std_header.depth;

            image.sliceStride = 0;

            if (image.mipLevels == 0)
            {
                image.mipLevels = 1;
            }

            for (level = 0; level < image.mipLevels; ++level)
            {
                image.mip[level].data = ptr;
                image.mip[level].width = (int)width;
                image.mip[level].height = (int)height;
                image.mip[level].depth = (int)depth;
                image.mip[level].mipStride = (int)(vgl_GetDDSStride(ref file_header, (int)width) * height);
                image.sliceStride += image.mip[level].mipStride;
                ptr += image.mip[level].mipStride;
                width >>= 1;
                height >>= 1;
                depth >>= 1;
            }

        done_close_file:
            f.Close();
        }
    }
}
