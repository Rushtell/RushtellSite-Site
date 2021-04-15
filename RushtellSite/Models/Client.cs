using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RushtellSite.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Deposit { get; set; }
        public string Type { get; set; }
    }
}
