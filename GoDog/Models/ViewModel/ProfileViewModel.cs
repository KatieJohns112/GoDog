using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDog.Models.ViewModels
{
    public class ProfileViewModel
    {
        public Owner Owner { get; set; }
        public List<Walker> Walkers { get; set; }
        public List<Dog> Dogs { get; set; }
        public Walker walker { get; set; }
      
    }
}