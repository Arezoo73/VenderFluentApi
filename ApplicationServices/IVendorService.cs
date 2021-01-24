using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenderConvention.Controllers;
using VenderConvention.DTOs;
using VenderConvention.Models;

namespace VenderConvention.ApplicationServices
{
   public interface IVendorService
    {
        ListDTO GetAllById(int id);
        bool Insert(InsertVendorDTO DTO);
        bool Update(UpdateDTO dTO, int id);
        bool Delete(int id);
        //bool UpdatePatch(JsonPatchDocument<UpdatePatchDTO> dTO, int id);
       






        //ListDTO GetAll();

    }
}
