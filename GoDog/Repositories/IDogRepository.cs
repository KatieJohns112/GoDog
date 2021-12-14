using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoDog.Models;

namespace GoDog.Repositories
{
    public interface IDogRepository
    {
        List<Dog> GetAllDogs();
        Dog GetDogById(int id);
        void AddDog(Dog dog);
        void UpdateDog(Dog dog);
        void DeleteDog(int dogId);
    }
}
