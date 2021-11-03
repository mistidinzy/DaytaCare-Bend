using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DaytaCare.Models;

namespace DaytaCare.Services
{
    public interface IDaycareRepository
    {
        Task<List<Daycare>> GetAll();

        Task<Daycare> GetById(int id);

        Task Insert(Daycare daycare);

        Task<bool> TryDelete(int id);

        Task<bool> TryUpdate(Daycare daycare);

        Task AddAmenity(int daycareId, int amenityId);

        Task DeleteAmenity(int daycareId, int amenityId);
    }
}
