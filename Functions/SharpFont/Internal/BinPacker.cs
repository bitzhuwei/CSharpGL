using System;

namespace SharpFont
{
    struct Rect
    {
        public int X, Y, Width, Height;

        //public int Right => X + Width;
        public int Right
        { get { return X + Width; } }
        //public int Bottom => Y + Height;
        public int Bottom
        { get { return Y + Height; } }

        public Rect(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public bool Contains(Rect rect)
        {
            return rect.X >= X && rect.Y >= Y &&
                   rect.Right <= Right && rect.Bottom <= Bottom;
        }

        //public override string ToString () => $"{X}, {Y}, {Width}, {Height}";
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", this.X, this.Y, this.Width, this.Height);
        }
    }

    struct ResizableArray<T>
    {
        public T[] Data;
        public int Count;

        //public T this[int index] => Data[index];
        public T this[int index]
        {
            get { return Data[index]; }
        }

        public ResizableArray(int capacity)
        {
            Data = new T[capacity];
            Count = 0;
        }

        //public void Clear () => Count = 0;
        public void Clear()
        {
            Count = 0;
        }

        public void Add(T value)
        {
            if (Count == Data.Length)
                Array.Resize(ref Data, (int)(Data.Length * 1.5));
            Data[Count++] = value;
        }

        public void RemoveAt(int index)
        {
            Count--;
            if (index < Count)
                Array.Copy(Data, index + 1, Data, index, Count - index);
        }
    }

    // based on the "MAXRECTS" method developed by Jukka Jylänki: http://clb.demon.fi/files/RectangleBinPack.pdf
    struct BinPacker
    {
        ResizableArray<Rect> freeList;

        public BinPacker(int width, int height)
        {
            freeList = new ResizableArray<Rect>(16);
            freeList.Add(new Rect(0, 0, width, height));
        }

        public void Clear(int width, int height)
        {
            freeList.Clear();
            freeList.Add(new Rect(0, 0, width, height));
        }

        public Rect Insert(int width, int height)
        {
            var bestNode = new Rect();
            var bestShortFit = int.MaxValue;
            var bestLongFit = int.MaxValue;

            var count = freeList.Count;
            for (int i = 0; i < count; i++)
            {
                // try to place the rect
                var rect = freeList[i];
                if (rect.Width < width || rect.Height < height)
                    continue;

                var leftoverX = Math.Abs(rect.Width - width);
                var leftoverY = Math.Abs(rect.Height - height);
                var shortFit = Math.Min(leftoverX, leftoverY);
                var longFit = Math.Max(leftoverX, leftoverY);

                if (shortFit < bestShortFit || (shortFit == bestShortFit && longFit < bestLongFit))
                {
                    bestNode = new Rect(rect.X, rect.Y, width, height);
                    bestShortFit = shortFit;
                    bestLongFit = longFit;
                }
            }

            if (bestNode.Height == 0)
                return bestNode;

            // split out free areas into smaller ones
            for (int i = 0; i < count; i++)
            {
                if (SplitFreeNode(freeList[i], bestNode))
                {
                    freeList.RemoveAt(i);
                    i--;
                    count--;
                }
            }

            // prune the freelist
            for (int i = 0; i < freeList.Count; i++)
            {
                for (int j = i + 1; j < freeList.Count; j++)
                {
                    var idata = freeList[i];
                    var jdata = freeList[j];
                    if (jdata.Contains(idata))
                    {
                        freeList.RemoveAt(i);
                        i--;
                        break;
                    }

                    if (idata.Contains(jdata))
                    {
                        freeList.RemoveAt(j);
                        j--;
                    }
                }
            }

            return bestNode;
        }

        bool SplitFreeNode(Rect freeNode, Rect usedNode)
        {
            // test if the rects even intersect
            var insideX = usedNode.X < freeNode.Right && usedNode.Right > freeNode.X;
            var insideY = usedNode.Y < freeNode.Bottom && usedNode.Bottom > freeNode.Y;
            if (!insideX || !insideY)
                return false;

            if (insideX)
            {
                // new node at the top side of the used node
                if (usedNode.Y > freeNode.Y && usedNode.Y < freeNode.Bottom)
                {
                    var newNode = freeNode;
                    newNode.Height = usedNode.Y - newNode.Y;
                    freeList.Add(newNode);
                }

                // new node at the bottom side of the used node
                if (usedNode.Bottom < freeNode.Bottom)
                {
                    var newNode = freeNode;
                    newNode.Y = usedNode.Bottom;
                    newNode.Height = freeNode.Bottom - usedNode.Bottom;
                    freeList.Add(newNode);
                }
            }

            if (insideY)
            {
                // new node at the left side of the used node
                if (usedNode.X > freeNode.X && usedNode.X < freeNode.Right)
                {
                    var newNode = freeNode;
                    newNode.Width = usedNode.X - newNode.X;
                    freeList.Add(newNode);
                }

                // new node at the right side of the used node
                if (usedNode.Right < freeNode.Right)
                {
                    var newNode = freeNode;
                    newNode.X = usedNode.Right;
                    newNode.Width = freeNode.Right - usedNode.Right;
                    freeList.Add(newNode);
                }
            }

            return true;
        }
    }
}
