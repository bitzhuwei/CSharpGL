using System;

namespace CSharpGL
{
    public class BlendFactorHelper
    {
        private int currentSource;
        private int currentDest;

        private static BlendingSourceFactor[] sourceFactors;
        private static BlendingDestinationFactor[] destFactors;

        static BlendFactorHelper()
        {
            {
                Array sources = Enum.GetValues(typeof(BlendingSourceFactor));
                sourceFactors = new BlendingSourceFactor[sources.Length];
                int i = 0;
                foreach (var item in sources)
                {
                    sourceFactors[i++] = (BlendingSourceFactor)item;
                }
            }

            {
                Array dests = Enum.GetValues(typeof(BlendingDestinationFactor));
                destFactors = new BlendingDestinationFactor[dests.Length];
                int i = 0;
                foreach (var item in dests)
                {
                    destFactors[i++] = (BlendingDestinationFactor)item;
                }
            }
        }

        public void GetNext(out BlendingSourceFactor source, out BlendingDestinationFactor dest)
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