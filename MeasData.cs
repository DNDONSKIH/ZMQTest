using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MeasData
    {
        public string? instrument;
        public string? meas;
        public int? src1;
        public int? src2;
        public double? result;

        public MeasData(string? instrument, string? meas, int? src1, int? src2, double? result)
        {
            this.instrument = instrument;
            this.meas = meas;
            this.src1 = src1;
            this.src2 = src2;
            this.result = result;
        }


    }
}
