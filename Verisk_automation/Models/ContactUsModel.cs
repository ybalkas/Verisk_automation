using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject3.Models
{
    internal class ContactUsModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string   businessEmail{ get; set; }
        public string? businessPhone { get; set; }
        public string? company { get; set; }
        public string? comments { get; set; }
    }
}
