using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Models
{
    public class Schedule
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int ServiceID { get; set; }
        public bool Payed { get; set; }
        public DateTime Date { get; set; }

        //public ICollection<Client> Clients { get; set; }
    }
}
