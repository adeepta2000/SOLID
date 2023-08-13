using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        public static List<ProductDTO> Get()
        {
            var data = DataAccessFactory.ProductData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product,ProductDTO>();
            });
            var mapper = new Mapper(config);
            var converted= mapper.Map<List<ProductDTO>>(data);
            return converted;
        }

        public static ProductDTO Get(int id)
        {
            var data= DataAccessFactory.ProductData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(config);
            var convarted= mapper.Map<ProductDTO>(data);

            return convarted;
        }
        
        public static bool Create(ProductDTO product)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Product>(product);
            return DataAccessFactory.ProductData().Create(conv);
        }

        public static bool Update(ProductDTO product)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Product>(product);
            return DataAccessFactory.ProductData().Update(conv);

        }

        public static bool Delete(int id) {
            return DataAccessFactory.ProductData().Delete(id);
        }
    }
}
