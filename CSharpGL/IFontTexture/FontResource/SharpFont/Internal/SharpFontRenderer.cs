using System;

namespace SharpFont
{
    /// <summary>
    /// Handles rasterizing curves to a bitmap.
    /// The algorithm is heavily inspired by the FreeType2 renderer; thanks guys!
    /// </summary>
    unsafe class SharpFontRenderer
    {
        /// <summary>
        /// the surface we're currently rendering to.
        /// </summary>
        Surface surface;                // 
        /// <summary>
        /// one scanline per Y, points into cell buffer
        /// </summary>
        int[] scanlines;                // 
        int[] curveLevels;
        /// <summary>
        /// points on a bezier arc
        /// </summary>
        Vector2[] bezierArc;            // 
        Cell[] cells;
        /// <summary>
        /// subpixel position of active point
        /// </summary>
        Vector2 activePoint;            // 
        /// <summary>
        /// running total of the active cell's area
        /// </summary>
        float activeArea;               // 
        /// <summary>
        /// ditto for coverage
        /// </summary>
        float activeCoverage;           // 
        /// <summary>
        /// pixel position of the active cell
        /// </summary>
        int cellX;
        /// <summary>
        /// pixel position of the active cell
        /// </summary>
        int cellY;               // 
        /// <summary>
        /// number of cells in active use
        /// </summary>
        int cellCount;                  // 
        /// <summary>
        /// bounds of the glyph surface, in plain old pixels
        /// </summary>
        int width;
        /// <summary>
        /// bounds of the glyph surface, in plain old pixels
        /// </summary>
        int height;              // 
        /// <summary>
        /// whether the current cell has active data
        /// </summary>
        bool cellActive;                // 

        public void Start(int width, int height)
        {
            this.width = width;
            this.height = height;

            cellCount = 0;
            activeArea = 0.0f;
            activeCoverage = 0.0f;
            cellActive = false;

            if (cells == null)
            {
                cells = new Cell[1024];
                curveLevels = new int[32];
                bezierArc = new Vector2[curveLevels.Length * 3 + 1];
                scanlines = new int[height];
            }
            else if (height >= scanlines.Length)
                scanlines = new int[height];

            for (int i = 0; i < height; i++)
                scanlines[i] = -1;
        }

        public void MoveTo(Vector2 point)
        {
            // record current cell, if any
            if (cellActive)
                RetireActiveCell();

            // calculate cell coordinates
            activePoint = point;
            cellX = Math.Max(-1, Math.Min((int)activePoint.x, width));
            cellY = (int)activePoint.y;

            // activate if this is a valid cell location
            cellActive = cellX < width && cellY < height;
            activeArea = 0.0f;
            activeCoverage = 0.0f;
        }

        public void LineTo(Vector2 point)
        {
            // figure out which scanlines this line crosses
            var startScanline = (int)activePoint.y;
            var endScanline = (int)point.y;

            // vertical clipping
            if (Math.Min(startScanline, endScanline) >= height ||
                Math.Max(startScanline, endScanline) < 0)
            {
                // just save this position since it's outside our bounds and continue
                activePoint = point;
                return;
            }

            // render the line
            var vector = point - activePoint;
            var fringeStart = activePoint.y - startScanline;
            var fringeEnd = point.y - endScanline;

            if (startScanline == endScanline)
            {
                // this is a horizontal line
                RenderScanline(startScanline, activePoint.x, fringeStart, point.x, fringeEnd);
            }
            else if (vector.x == 0)
            {
                // this is a vertical line
                var x = (int)activePoint.x;
                var xarea = (activePoint.x - x) * 2;

                // check if we're scanning up or down
                var first = 1.0f;
                var increment = 1;
                if (vector.y < 0)
                {
                    first = 0.0f;
                    increment = -1;
                }

                // first cell fringe
                var deltaY = (first - fringeStart);
                activeArea += xarea * deltaY;
                activeCoverage += deltaY;
                startScanline += increment;
                SetCurrentCell(x, startScanline);

                // any other cells covered by the line
                deltaY = first + first - 1.0f;
                var area = xarea * deltaY;
                while (startScanline != endScanline)
                {
                    activeArea += area;
                    activeCoverage += deltaY;
                    startScanline += increment;
                    SetCurrentCell(x, startScanline);
                }

                // ending fringe
                deltaY = fringeEnd - 1.0f + first;
                activeArea += xarea * deltaY;
                activeCoverage += deltaY;
            }
            else
            {
                // diagonal line
                // check if we're scanning up or down
                var dist = (1.0f - fringeStart) * vector.x;
                var first = 1.0f;
                var increment = 1;
                if (vector.y < 0)
                {
                    dist = fringeStart * vector.x;
                    first = 0.0f;
                    increment = -1;
                    vector.y = -vector.y;
                }

                // render the first scanline
                var delta = dist / vector.y;
                var x = activePoint.x + delta;
                RenderScanline(startScanline, activePoint.x, fringeStart, x, first);
                startScanline += increment;
                SetCurrentCell((int)x, startScanline);

                // step along the line
                if (startScanline != endScanline)
                {
                    delta = vector.x / vector.y;
                    while (startScanline != endScanline)
                    {
                        var x2 = x + delta;
                        RenderScanline(startScanline, x, 1.0f - first, x2, first);
                        x = x2;

                        startScanline += increment;
                        SetCurrentCell((int)x, startScanline);
                    }
                }

                // last scanline
                RenderScanline(startScanline, x, 1.0f - first, point.x, fringeEnd);
            }

            activePoint = point;
        }

        public void QuadraticCurveTo(Vector2 control, Vector2 point)
        {
            var levels = curveLevels;
            var arc = bezierArc;
            arc[0] = point;
            arc[1] = control;
            arc[2] = activePoint;

            var delta = Vector2.Abs(arc[2] + arc[0] - 2 * arc[1]);
            var dx = delta.x;
            if (dx < delta.y)
                dx = delta.y;

            // short cut for small arcs
            if (dx < 0.25f)
            {
                LineTo(arc[0]);
                return;
            }

            int level = 0;
            do
            {
                dx /= 4.0f;
                level++;
            } while (dx > 0.25f);

            int top = 0;
            int arcIndex = 0;
            levels[0] = level;

            while (top >= 0)
            {
                level = levels[top];
                if (level > 0)
                {
                    // split the arc
                    arc[arcIndex + 4] = arc[arcIndex + 2];
                    var b = arc[arcIndex + 1];
                    var a = arc[arcIndex + 3] = (arc[arcIndex + 2] + b) / 2;
                    b = arc[arcIndex + 1] = (arc[arcIndex] + b) / 2;
                    arc[arcIndex + 2] = (a + b) / 2;

                    arcIndex += 2;
                    top++;
                    levels[top] = levels[top - 1] = level - 1;
                }
                else
                {
                    LineTo(arc[arcIndex]);
                    top--;
                    arcIndex -= 2;
                }
            }
        }

        public void BlitTo(Surface surface)
        {
            if (cellActive)
                RetireActiveCell();

            // if we rendered nothing, there's nothing to do
            if (cellCount == 0)
                return;

            this.surface = surface;
            for (int y = 0; y < height; y++)
            {
                var x = 0;
                var coverage = 0.0f;
                var index = scanlines[y];

                while (index != -1)
                {
                    // cap off the previous span, if we had one
                    var cell = cells[index];
                    if (cell.X > x && coverage != 0.0f)
                        FillHLine(x, y, coverage, cell.X - x);

                    coverage += cell.Coverage;

                    var area = coverage - (cell.Area / 2.0f);
                    if (area != 0.0f && cell.X >= 0)
                        FillHLine(cell.X, y, area, 1);

                    x = cell.X + 1;
                    index = cell.Next;
                }

                // finish off the trailing span
                if (coverage != 0.0f)
                    FillHLine(x, y, coverage, width - x);
            }
        }

        void FillHLine(int x, int y, float coveragePercentage, int length)
        {
            var coverage = (int)Math.Round(coveragePercentage * 255, MidpointRounding.AwayFromZero);
            if (coverage == 0)
                return;

            coverage = Math.Min(Math.Abs(coverage), 255);
            var c = (byte)coverage;

            // find the scanline offset
            var bits = (byte*)surface.Bits - y * surface.Pitch;
            if (surface.Pitch >= 0)
                bits += (surface.Height - 1) * surface.Pitch;

            // finally fill pixels
            var p = bits + x;
            for (int i = 0; i < length; i++)
                *p++ = c;
        }

        void RenderScanline(int scanline, float x1, float y1, float x2, float y2)
        {
            var startCell = (int)x1;
            var endCell = (int)x2;
            var fringeStart = x1 - startCell;
            var fringeEnd = x2 - endCell;

            // trivial case; exact same Y, down to the subpixel
            if (y1 == y2)
            {
                SetCurrentCell(endCell, scanline);
                return;
            }

            // trivial case; within the same cell
            if (startCell == endCell)
            {
                var deltaY = y2 - y1;
                activeArea += (fringeStart + fringeEnd) * deltaY;
                activeCoverage += deltaY;
                return;
            }

            // long case: render a run of adjacent cells on the scanline
            var dx = x2 - x1;
            var dy = y2 - y1;

            // check if we're going left or right
            var dist = (1.0f - fringeStart) * dy;
            var first = 1.0f;
            var increment = 1;
            if (dx < 0)
            {
                dist = fringeStart * dy;
                first = 0.0f;
                increment = -1;
                dx = -dx;
            }

            // update the first cell
            var delta = dist / dx;
            activeArea += (fringeStart + first) * delta;
            activeCoverage += delta;

            startCell += increment;
            SetCurrentCell(startCell, scanline);
            y1 += delta;

            // update all covered cells
            if (startCell != endCell)
            {
                dist = y2 - y1 + delta;
                delta = dist / dx;

                while (startCell != endCell)
                {
                    activeArea += delta;
                    activeCoverage += delta;
                    y1 += delta;
                    startCell += increment;
                    SetCurrentCell(startCell, scanline);
                }
            }

            // final cell
            delta = y2 - y1;
            activeArea += (fringeEnd + 1.0f - first) * delta;
            activeCoverage += delta;
        }

        void SetCurrentCell(int x, int y)
        {
            // all cells on the left of the clipping region go to the minX - 1 position
            x = Math.Min(x, width);
            x = Math.Max(x, -1);

            // moving to a new cell?
            if (x != cellX || y != cellY)
            {
                if (cellActive)
                    RetireActiveCell();

                activeArea = 0.0f;
                activeCoverage = 0.0f;
                cellX = x;
                cellY = y;
            }

            cellActive = cellX < width && cellY < height;
        }

        void RetireActiveCell()
        {
            // cells with no coverage have nothing to do
            if (activeArea == 0.0f && activeCoverage == 0.0f)
                return;

            // find the right spot to add or insert this cell
            var x = cellX;
            var y = cellY;
            var cell = scanlines[y];
            if (cell == -1 || cells[cell].X > x)
            {
                // no cells at all on this scanline yet, or the first one
                // is already beyond our X value, so grab a new one
                cell = GetNewCell(x, cell);
                scanlines[y] = cell;
                return;
            }

            while (cells[cell].X != x)
            {
                var next = cells[cell].Next;
                if (next == -1 || cells[next].X > x)
                {
                    // either we reached the end of the chain in this
                    // scanline, or the next cell has a larger X
                    next = GetNewCell(x, next);
                    cells[cell].Next = next;
                    return;
                }

                // move to next cell
                cell = next;
            }

            // we found a cell with identical coords, so adjust its coverage
            cells[cell].Area += activeArea;
            cells[cell].Coverage += activeCoverage;
        }

        int GetNewCell(int x, int next)
        {
            // resize our array if we've run out of room
            if (cellCount == cells.Length)
                Array.Resize(ref cells, (int)(cells.Length * 1.5));

            var index = cellCount++;
            cells[index].X = x;
            cells[index].Next = next;
            cells[index].Area = activeArea;
            cells[index].Coverage = activeCoverage;

            return index;
        }

        struct Cell
        {
            public int X;
            public int Next;
            public float Coverage;
            public float Area;
        }
    }
}
