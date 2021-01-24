using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenderConvention.Contexts;
using VenderConvention.Models;

namespace VenderConvention.Inferastructurs
{
    public class VendorRepository : IVendorRepository
    {
        private readonly ShopContext _context;

        public VendorRepository(ShopContext context)
        {
            _context = context;
        }

        public vendor GetAllById(int id)
        {
            return _context.Vendor.Where(v => v.Id == id).Include(t => t.Tag).FirstOrDefault();
        }


        public int InsertVendor(vendor vendor)
        {
            _context.Vendor.Add(vendor);
            return _context.SaveChanges();
        }

               
        public int UpdateVendor(vendor vendor)
        {
            _context.Vendor.Update(vendor);
            return _context.SaveChanges();
        }

        public vendor GetByIdVender(int id)
        {
            return _context.Vendor.Where(v => v.Id == id).FirstOrDefault(); 
        }

        public vendor GetByIdVendorDelete(int id)
        {
            return _context.Vendor.Where(x => x.Isdeleted == false).FirstOrDefault();
        }
        
        public int Delete(vendor vendor)
        {
            _context.Vendor.Remove(vendor);
            return _context.SaveChanges();
        }

        public List<Tag> GetByIdTag(int id)
        {
            return _context.Tag.Where(t => t.VendorId == id).ToList();
        }

       
        

        //public List<vendor> GetAll()
        //{
        //    //var result = (from v in _context.Vendor
        //    //              join vt in _context.Tag
        //    //              on v.Id equals vt.VendorId
        //    //              select v).ToList();
        //    //return result;

        //    return _context.Vendor.Include(x => x.Tag).ToList();

        //}

    }
}
