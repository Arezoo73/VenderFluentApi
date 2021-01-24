using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenderConvention.Controllers;
using VenderConvention.DTOs;
using VenderConvention.Inferastructurs;
using VenderConvention.Models;

namespace VenderConvention.ApplicationServices
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _repository;

        public VendorService(IVendorRepository repository)
        {
            _repository = repository;
        }

        public ListDTO GetAllById(int id)
        {
            var data = _repository.GetAllById(id);

            var result = new ListDTO()
            {

                Id = data.Id,
                VendorName = data.VendorName,
                Title = data.Title,
                Modifiedate = data.Modifiedate,
                Createdate = data.Createdate,
                PhoneNumber = data.PhoneNumber,
                Address = data.Address,
                NameTag = data.Tag.Select(t => t.NameTag).ToList()

            };

            return result;

        }

        public bool Insert(InsertVendorDTO DTO)
        {
            bool result = false;

            var TagList = new List<Tag>();
            if (DTO.Tags != null && DTO.Tags.Count > 0)
            {

                foreach (var item in DTO.Tags)
                {
                    Tag tag = new Tag();
                    tag.NameTag = item.NameTag;
                    TagList.Add(tag);
                }
            }

            var vendor = new vendor()
            {
                VendorName = DTO.VenderName,
                Title = DTO.Title,
                PhoneNumber = DTO.PhoneNumber,
                Address = DTO.Address,
                Tag = TagList
            };

            int insertedvendor = _repository.InsertVendor(vendor);
            if (insertedvendor > 0)
            {
                if (insertedvendor > 0)
                {
                    result = true;
                }

            }
            return result;
        }

        public bool Update(UpdateDTO dTO, int id)
        {
            bool result = false;
          
            var TagList = new List<Tag>();
           
                foreach (var item in dTO.Tags)
                {
                    Tag tag = new Tag();
                    tag.NameTag = item.NameTag;
                    TagList.Add(tag);
                }
           
            var ven = _repository.GetByIdVender(id);

            ven.VendorName = dTO.VendorName;
            ven.Title = dTO.Title;
            ven.PhoneNumber = dTO.PhoneNumber;
            ven.Address = dTO.Address;
            ven.Tag = TagList;


            var resultvendor = _repository.UpdateVendor(ven);
            
          
            
            if (resultvendor > 0)
            {
                result = true;
            }


            return result;
        }

        //public bool UpdatePatch(JsonPatchDocument<UpdatePatchDTO> dTO, int id)
        //{
        //    bool result = false;

        //    var TagList = new List<Tag>();
           
           
        //    foreach (var item in dTO.ApplyTo(UpdatePatchDTO))
        //    {
        //        Tag tag = new Tag();
        //        tag.NameTag = item.NameTag;
        //        TagList.Add(tag);
        //    }

        //    var ven = _repository.GetByIdVender(id);

        //    ven.VendorName = dto.VendorName;
        //    ven.Title = dto.Title;
        //    ven.PhoneNumber = dto.PhoneNumber;
        //    ven.Address = dto.Address;
        //    ven.Tag = TagList;


        //    var resultvendor = _repository.UpdateVendor(ven);

        //    result = true;

        //    if (resultvendor > 0)
        //    {
        //        result = true;
        //    }


        //    return result;
        //}

        public bool Delete(int id)
        {
          var iddelete = _repository.GetByIdVendorDelete(id);
          var result=  _repository.Delete(iddelete);
            if (result > 0)
            {
                return true;
            }
            return true;
        }


    }



    //public ListDTO GetAll()
    //{
    //    var Data = _repository.GetAll();
    //    ListDTO ff;

    //    foreach (var item in Data)
    //    {

    //        var a = new ListDTO()
    //        {

    //            Id = item.Id,
    //            VendorName = item.VendorName,
    //            Title = item.Title,
    //            Modifiedate = item.Modifiedate,
    //            Createdate = item.Createdate,
    //            PhoneNumber = item.PhoneNumber,
    //            Address = item.Address,
    //            NameTag = item.Tag.Select(t=>t.NameTag).ToList()

    //        };

    //        ff = a;
    //    }
    //    return ;

    //}






    }




