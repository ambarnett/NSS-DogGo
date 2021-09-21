using System.Collections.Generic;
using DogGo.Models;

namespace DogGo.Repositories
{
    public interface INeighborhoodRepository
    {
        List<Neighborhood> GetAllNeighborhoods();
        Neighborhood GetNeighborhoodById(int id);
    }
}
