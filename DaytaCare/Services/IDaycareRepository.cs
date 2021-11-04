using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DaytaCare.Models;
using DaytaCare.Models.DTO;

namespace DaytaCare.Services
{
    public interface IDaycareRepository
    {
        Task<List<DaycareDTO>> GetAll();

        Task<Daycare> GetById(int id);

        Task<Daycare> Insert(CreateDaycareDto daycare);

        Task<bool> TryDelete(int id);

        Task<bool> TryUpdate(Daycare daycare);

        Task AddAmenity(int daycareId, int amenityId);

        Task DeleteAmenity(int daycareId, int amenityId);
    }
}
