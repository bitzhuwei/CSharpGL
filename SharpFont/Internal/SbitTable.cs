using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFont
{
    class SbitTable
    {
        public unsafe static SbitTable Read(DataReader reader, TableRecord[] tables)
        {
            if (!SfntTables.SeekToTable(reader, tables, FourCC.Eblc))
                return null;

            // skip version
            var baseOffset = reader.Position;
            reader.Skip(sizeof(int));

            // load each strike table
            var count = reader.ReadInt32BE();
            if (count > MaxBitmapStrikes)
                throw new InvalidFontException("Too many bitmap strikes in font.");

            var sizeTableHeaders = stackalloc BitmapSizeTable[count];
            for (int i = 0; i < count; i++)
            {
                sizeTableHeaders[i].SubTableOffset = reader.ReadUInt32BE();
                sizeTableHeaders[i].SubTableSize = reader.ReadUInt32BE();
                sizeTableHeaders[i].SubTableCount = reader.ReadUInt32BE();

                // skip colorRef, metrics entries, start and end glyph indices
                reader.Skip(sizeof(uint) + sizeof(ushort) * 2 + 12 * 2);

                sizeTableHeaders[i].PpemX = reader.ReadByte();
                sizeTableHeaders[i].PpemY = reader.ReadByte();
                sizeTableHeaders[i].BitDepth = reader.ReadByte();
                sizeTableHeaders[i].Flags = (BitmapSizeFlags)reader.ReadByte();
            }

            // read index subtables
            var indexSubTables = stackalloc IndexSubTable[count];
            for (int i = 0; i < count; i++)
            {
                reader.Seek(baseOffset + sizeTableHeaders[i].SubTableOffset);
                indexSubTables[i] = new IndexSubTable
                {
                    FirstGlyph = reader.ReadUInt16BE(),
                    LastGlyph = reader.ReadUInt16BE(),
                    Offset = reader.ReadUInt32BE()
                };
            }

            // read the actual data for each strike table
            for (int i = 0; i < count; i++)
            {
                // read the subtable header
                reader.Seek(baseOffset + sizeTableHeaders[i].SubTableOffset + indexSubTables[i].Offset);
                var indexFormat = reader.ReadUInt16BE();
                var imageFormat = reader.ReadUInt16BE();
                var imageDataOffset = reader.ReadUInt32BE();


            }

            return null;
        }

        struct BitmapSizeTable
        {
            public uint SubTableOffset;
            public uint SubTableSize;
            public uint SubTableCount;
            public byte PpemX;
            public byte PpemY;
            public byte BitDepth;
            public BitmapSizeFlags Flags;
        }

        struct IndexSubTable
        {
            public ushort FirstGlyph;
            public ushort LastGlyph;
            public uint Offset;
        }

        [Flags]
        enum BitmapSizeFlags
        {
            None,
            Horizontal,
            Vertical
        }

        const int MaxBitmapStrikes = 1024;
    }
}
