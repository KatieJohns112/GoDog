using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoDog.Models;

namespace GoDog.Repositories
{
    public interface IWalkRepository
    {
        List<Walk> GetAllWalks();
        List<Walk> GetWalksByWalkerId(int WalkerId);
    }
}
