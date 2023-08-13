using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ProductRepo : Repo, IRepo<Product, int, bool>
    {
        public bool Create(Product product)
        {
            db.Products.Add(product);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exp = db.Products.Find(id);
            db.Products.Remove(exp);

            return db.SaveChanges() > 0;
        }

        public List<Product> Get()
        {
            var data = (from d in db.Products
                        join b in db.Brands on d.BrandId equals b.Id
                        join c in db.Categories on d.CategoryId equals c.Id

                        select new
                        {
                            Id = d.Id,
                            Name = d.Name,
                            Price = d.Price,
                            BrandId = d.BrandId,
                            CategoryId = d.CategoryId,
                            BrandName = b.Name,
                            CategoryName = c.Name
                        }


                      ).ToList();

            List<Product> products = data.Select(d => new Product
            {
                Id = d.Id,
                Name = d.Name,
                Price = d.Price,
                BrandId = d.BrandId,
                CategoryId = d.CategoryId,
                BrandName = d.BrandName,
                CategoryName = d.CategoryName
            }).ToList();


            return products;
        }

        public Product Get(int id)
        {
            var data = (from d in db.Products
                        join b in db.Brands on d.BrandId equals b.Id
                        join c in db.Categories on d.CategoryId equals c.Id
                        where d.Id == id
                        select new
                        {
                            Id = d.Id,
                            Name = d.Name,
                            Price = d.Price,
                            BrandId = d.BrandId,
                            CategoryId = d.CategoryId,
                            BrandName = b.Name,
                            CategoryName = c.Name
                        }).FirstOrDefault();

            // Create a new Product instance using the DTO data
            var product = new Product
            {
                Id = data.Id,
                Name = data.Name,
                Price = data.Price,
                BrandId = data.BrandId,
                CategoryId = data.CategoryId,
                BrandName = data.BrandName,
                CategoryName = data.CategoryName
            };

            return product;
        }

        public bool Update(Product product)
        {
            var exp = db.Products.Find(product.Id);
            exp.Name = product.Name;
            exp.Price = product.Price;
            exp.BrandId = product.BrandId;
            exp.CategoryId = product.CategoryId;

            return db.SaveChanges() > 0;
        }
    }
}
