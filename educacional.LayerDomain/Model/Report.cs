using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace educacional.LayerDomain.Model
{
    [Keyless]
    public class Report
    {
        public string Student { get; set; }
        public decimal Maths { get; set; }
        public decimal Portuguese { get; set; }
        public decimal History { get; set; }
        public decimal Geography { get; set; }
        public decimal English { get; set; }
        public decimal Biology { get; set; }
        public decimal Philosophy { get; set; }
        public decimal Physics { get; set; }
        public decimal Chemistry { get; set; }
        public decimal Average { get; set; }
    }
}
