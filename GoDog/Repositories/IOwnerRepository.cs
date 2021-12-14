using GoDog.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace GoDog.Repositories
{
    public interface IOwnerRepository
    {
        List<Owner> GetAllOwners();
        Owner GetOwnerById(int id);
        void DeleteOwner(int ownerId);
        void UpdateOwner(Owner owner);
        void AddOwner(Owner owner);
        public Owner GetOwnerByEmail(string email);
    }
}
