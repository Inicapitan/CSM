using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NIF { get; set; }
        public string Gender { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }
        
        //public ICollection<Schedule> Schedule { get; set; }
    }
}
