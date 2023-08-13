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
    internal class CategoryRepo : Repo, IRepo<Category, int, bool>
    {
        public bool Create(Category obj)
        {
            db.Categories.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var excat= db.Categories.Find(id);
            db.Categories.Remove(excat);
            return db.SaveChanges() > 0;
        }

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public bool Update(Category obj)
        {
            var excat = db.Categories.Find(obj.Id);
            db.Entry(excat).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
