using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BrandRepo : Repo, IRepo<Brand, int, bool>
    {
        public bool Create(Brand obj)
        {
            db.Brands.Add(obj);
            return db.SaveChanges() > 0 ;
        }

        public bool Delete(int id)
        {
            var exbrand=db.Brands.Find(id);
            db.Brands.Remove(exbrand);
            return db.SaveChanges() > 0 ;
        }

        public List<Brand> Get()
        {
            return db.Brands.ToList();
        }

        public Brand Get(int id)
        {
            return db.Brands.Find(id);
        }

        public bool Update(Brand obj)
        {
            var exbrand = db.Brands.Find(obj.Id);
            db.Entry(exbrand).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0 ;
        }
    }
}
