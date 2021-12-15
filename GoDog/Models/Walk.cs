using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDog.Models
{
    public class Walk
    {
        public int id { get; set; }
        public DateTime TotalTime { get; set; }
        public int Duration { get; set; }
        public int WalkerId { get; set; }
        public int DogId { get; set; }
        public Dog Dog {get; set;}
        public Owner Owner { get; set; }
    }
}
