using System;

namespace CSharpGL
{
    public class BlendFactorHelper
    {
        private int currentSource;
        private int currentDest;

        private static BlendSrcFactor[] sourceFactors;
        private static BlendDestFactor[] destFactors;

        static BlendFactorHelper()
        {
            {
                Array sources = Enum.GetValues(typeof(BlendSrcFactor));
                sourceFactors = new BlendSrcFactor[sources.Length];
                int i = 0;
                foreach (var item in sources)
                {
                    sourceFactors[i++] = (BlendSrcFactor)item;
                }
            }

            {
                Array dests = Enum.GetValues(typeof(BlendDestFactor));
                destFactors = new BlendDestFactor[dests.Length];
                int i = 0;
                foreach (var item in dests)
                {
                    destFactors[i++] = (BlendDestFactor)item;
                }
            }
        }

        public void GetNext(out BlendSrcFactor source, out BlendDestFactor dest)
        {
            source = sourceFactors[currentSource];
            dest = destFactors[currentDest];
            currentDest++;
            if (currentDest >= destFactors.Length)
            {
                currentDest = 0;
                currentSource++;
                if (currentSource >= sourceFactors.Length)
                {
                    currentSource = 0;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("glBlendFunc({0}, {1});", sourceFactors[currentSource], destFactors[currentDest]);
        }
    }
}