using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{

    public static class Tuple
    {

        public static Tuple<T1> Create<T1>(T1 item1)
        {
            return new Tuple<T1>(item1);
        }


        public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
        {
            return new Tuple<T1, T2>(item1, item2);
        }


        public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
        {
            return new Tuple<T1, T2, T3>(item1, item2, item3);
        }


        public static Tuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            return new Tuple<T1, T2, T3, T4>(item1, item2, item3, item4);
        }


        public static Tuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            return new Tuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5);
        }


        public static Tuple<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            return new Tuple<T1, T2, T3, T4, T5, T6>(item1, item2, item3, item4, item5, item6);
        }


        public static Tuple<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        {
            return new Tuple<T1, T2, T3, T4, T5, T6, T7>(item1, item2, item3, item4, item5, item6, item7);
        }


        internal static int CombineHashCodes(int h1, int h2)
        {
            return (h1 << 5) + h1 ^ h2;
        }

        internal static int CombineHashCodes(int h1, int h2, int h3)
        {
            return Tuple.CombineHashCodes(Tuple.CombineHashCodes(h1, h2), h3);
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4)
        {
            return Tuple.CombineHashCodes(Tuple.CombineHashCodes(h1, h2), Tuple.CombineHashCodes(h3, h4));
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5)
        {
            return Tuple.CombineHashCodes(Tuple.CombineHashCodes(h1, h2, h3, h4), h5);
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6)
        {
            return Tuple.CombineHashCodes(Tuple.CombineHashCodes(h1, h2, h3, h4), Tuple.CombineHashCodes(h5, h6));
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7)
        {
            return Tuple.CombineHashCodes(Tuple.CombineHashCodes(h1, h2, h3, h4), Tuple.CombineHashCodes(h5, h6, h7));
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7, int h8)
        {
            return Tuple.CombineHashCodes(Tuple.CombineHashCodes(h1, h2, h3, h4), Tuple.CombineHashCodes(h5, h6, h7, h8));
        }
    }


    public class Tuple<T1>
    {
        private readonly T1 m_Item1;

        public T1 Item1
        {
            get
            {
                return this.m_Item1;
            }
        }

        public Tuple(T1 item1)
        {
            this.m_Item1 = item1;
        }

    }


    public class Tuple<T1, T2>
    {
        private readonly T1 m_Item1;

        private readonly T2 m_Item2;

        public T1 Item1
        {
            get
            {
                return this.m_Item1;
            }
        }


        public T2 Item2
        {
            get
            {
                return this.m_Item2;
            }
        }

        public Tuple(T1 item1, T2 item2)
        {
            this.m_Item1 = item1;
            this.m_Item2 = item2;
        }

    }

    public class Tuple<T1, T2, T3>
    {
        private readonly T1 m_Item1;

        private readonly T2 m_Item2;

        private readonly T3 m_Item3;

        public T1 Item1
        {
            get
            {
                return this.m_Item1;
            }
        }


        public T2 Item2
        {
            get
            {
                return this.m_Item2;
            }
        }


        public T3 Item3
        {
            get
            {
                return this.m_Item3;
            }
        }

        public Tuple(T1 item1, T2 item2, T3 item3)
        {
            this.m_Item1 = item1;
            this.m_Item2 = item2;
            this.m_Item3 = item3;
        }

    }


    public class Tuple<T1, T2, T3, T4>
    {
        private readonly T1 m_Item1;

        private readonly T2 m_Item2;

        private readonly T3 m_Item3;

        private readonly T4 m_Item4;

        public T1 Item1
        {
            get
            {
                return this.m_Item1;
            }
        }

        public T2 Item2
        {
            get
            {
                return this.m_Item2;
            }
        }

        public T3 Item3
        {
            get
            {
                return this.m_Item3;
            }
        }

        public T4 Item4
        {
            get
            {
                return this.m_Item4;
            }
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            this.m_Item1 = item1;
            this.m_Item2 = item2;
            this.m_Item3 = item3;
            this.m_Item4 = item4;
        }

    }


    public class Tuple<T1, T2, T3, T4, T5>
    {
        private readonly T1 m_Item1;

        private readonly T2 m_Item2;

        private readonly T3 m_Item3;

        private readonly T4 m_Item4;

        private readonly T5 m_Item5;

        public T1 Item1
        {
            get
            {
                return this.m_Item1;
            }
        }

        public T2 Item2
        {
            get
            {
                return this.m_Item2;
            }
        }

        public T3 Item3
        {
            get
            {
                return this.m_Item3;
            }
        }

        public T4 Item4
        {
            get
            {
                return this.m_Item4;
            }
        }


        public T5 Item5
        {
            get
            {
                return this.m_Item5;
            }
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            this.m_Item1 = item1;
            this.m_Item2 = item2;
            this.m_Item3 = item3;
            this.m_Item4 = item4;
            this.m_Item5 = item5;
        }
    }

    public class Tuple<T1, T2, T3, T4, T5, T6>
    {
        private readonly T1 m_Item1;

        private readonly T2 m_Item2;

        private readonly T3 m_Item3;

        private readonly T4 m_Item4;

        private readonly T5 m_Item5;

        private readonly T6 m_Item6;


        public T1 Item1
        {

            get
            {
                return this.m_Item1;
            }
        }


        public T2 Item2
        {

            get
            {
                return this.m_Item2;
            }
        }


        public T3 Item3
        {

            get
            {
                return this.m_Item3;
            }
        }


        public T4 Item4
        {

            get
            {
                return this.m_Item4;
            }
        }


        public T5 Item5
        {

            get
            {
                return this.m_Item5;
            }
        }


        public T6 Item6
        {

            get
            {
                return this.m_Item6;
            }
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            this.m_Item1 = item1;
            this.m_Item2 = item2;
            this.m_Item3 = item3;
            this.m_Item4 = item4;
            this.m_Item5 = item5;
            this.m_Item6 = item6;
        }

    }


    public class Tuple<T1, T2, T3, T4, T5, T6, T7>
    {
        private readonly T1 m_Item1;

        private readonly T2 m_Item2;

        private readonly T3 m_Item3;

        private readonly T4 m_Item4;

        private readonly T5 m_Item5;

        private readonly T6 m_Item6;

        private readonly T7 m_Item7;


        public T1 Item1
        {

            get
            {
                return this.m_Item1;
            }
        }


        public T2 Item2
        {

            get
            {
                return this.m_Item2;
            }
        }


        public T3 Item3
        {

            get
            {
                return this.m_Item3;
            }
        }


        public T4 Item4
        {

            get
            {
                return this.m_Item4;
            }
        }


        public T5 Item5
        {

            get
            {
                return this.m_Item5;
            }
        }


        public T6 Item6
        {

            get
            {
                return this.m_Item6;
            }
        }


        public T7 Item7
        {

            get
            {
                return this.m_Item7;
            }
        }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        {
            this.m_Item1 = item1;
            this.m_Item2 = item2;
            this.m_Item3 = item3;
            this.m_Item4 = item4;
            this.m_Item5 = item5;
            this.m_Item6 = item6;
            this.m_Item7 = item7;
        }

    }

}
