using GoDog.Models;
using System.Collections.Generic;

namespace GoDog.Repositories
{
    public interface INeighborhoodRepository
    {
        List<Neighborhood> GetAll();
    }
}