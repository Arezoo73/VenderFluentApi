using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenderConvention.ApplicationServices;
using VenderConvention.DTOs;
using VenderConvention.Inferastructurs;
using VenderConvention.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace VenderConvention.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _service;

        public VendorController(IVendorService service)
        {
            _service = service;

        }

        [HttpGet]
        public IActionResult getallById(int id)
        {
            var result = _service.GetAllById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Insert(InsertVendorDTO dTO)
        {
            var result = _service.Insert(dTO);

            if (result)
            {
                return Ok();
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, UpdateDTO dTO)
        {
            var result = _service.Update(dTO, id);
            if (result)
            {
                return Ok();
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            return Ok(result);
        }

        //[HttpPatch("{id}")]
        //public IActionResult UpdatePatch([FromRoute] int id, JsonPatchDocument<UpdatePatchDTO> state)
        //{
        //    var result = _service.UpdatePatch(state,id);

        //    return Ok(result);

        //}
    }



    //[HttpGet]
    ///[Route("GetAll")]
    //public IActionResult GetAll()
    //{
    //  var result= _service.GetAll();
    //    return Ok(result);

    //}

    //[HttpPost]
    //public IActionResult Insert(InsertVendorDTO dTO)
    //{
    //    var result = _service.Insert(dTO);

    //    if (result)
    //    {
    //        return Ok();
    //    }
    //    else
    //    {
    //        throw new Exception();
    //    }
    //}


}

