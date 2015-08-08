using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTF2Bmps
{
    class WorkerResult
    {
        public WorkerData data;
        public StringBuilder builder;

        public WorkerResult(StringBuilder builder, WorkerData data)
        {
            // TODO: Complete member initialization
            this.builder = builder;
            this.data = data;
        }
    }
}
