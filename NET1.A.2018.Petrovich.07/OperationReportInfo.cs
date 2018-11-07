using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1.A._2018.Petrovich._07
{
    public class OperationReportInfo : EventArgs
    {
        public string AccNumber { get; set; }
        public string TypeOperaton { get; set; }
        public decimal Amount { get; set; }
    }
}
