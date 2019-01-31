using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeImageAPI
{
    // Summary:
    //     Specifies how much an image is rotated and the axis used to flip the image.
    public enum RotateFlipType
    {
        // Summary:
        //     Specifies a 180-degree clockwise rotation followed by a horizontal and vertical
        //     flip.
        Rotate180FlipXY = 0,
        //
        // Summary:
        //     Specifies no clockwise rotation and no flipping.
        RotateNoneFlipNone = 0,
        //
        // Summary:
        //     Specifies a 270-degree clockwise rotation followed by a horizontal and vertical
        //     flip.
        Rotate270FlipXY = 1,
        //
        // Summary:
        //     Specifies a 90-degree clockwise rotation without flipping.
        Rotate90FlipNone = 1,
        //
        // Summary:
        //     Specifies a 180-degree clockwise rotation without flipping.
        Rotate180FlipNone = 2,
        //
        // Summary:
        //     Specifies no clockwise rotation followed by a horizontal and vertical flip.
        RotateNoneFlipXY = 2,
        //
        // Summary:
        //     Specifies a 270-degree clockwise rotation without flipping.
        Rotate270FlipNone = 3,
        //
        // Summary:
        //     Specifies a 90-degree clockwise rotation followed by a horizontal and vertical
        //     flip.
        Rotate90FlipXY = 3,
        //
        // Summary:
        //     Specifies a 180-degree clockwise rotation followed by a vertical flip.
        Rotate180FlipY = 4,
        //
        // Summary:
        //     Specifies no clockwise rotation followed by a horizontal flip.
        RotateNoneFlipX = 4,
        //
        // Summary:
        //     Specifies a 90-degree clockwise rotation followed by a horizontal flip.
        Rotate90FlipX = 5,
        //
        // Summary:
        //     Specifies a 270-degree clockwise rotation followed by a vertical flip.
        Rotate270FlipY = 5,
        //
        // Summary:
        //     Specifies no clockwise rotation followed by a vertical flip.
        RotateNoneFlipY = 6,
        //
        // Summary:
        //     Specifies a 180-degree clockwise rotation followed by a horizontal flip.
        Rotate180FlipX = 6,
        //
        // Summary:
        //     Specifies a 90-degree clockwise rotation followed by a vertical flip.
        Rotate90FlipY = 7,
        //
        // Summary:
        //     Specifies a 270-degree clockwise rotation followed by a horizontal flip.
        Rotate270FlipX = 7,
    }
}
