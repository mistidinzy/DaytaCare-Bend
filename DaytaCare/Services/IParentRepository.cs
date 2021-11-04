using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DaytaCare.Models;
using DaytaCare.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DaytaCare.Services
{
    public interface IParentRepository
    {
        Task<ActionResult<List<Daycare>>> Search(ParentSearchDto filter);
    }
}
