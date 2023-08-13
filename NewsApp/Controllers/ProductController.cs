using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace NewsApp.Controllers
{
    
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/AllProduct")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = ProductService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch(Exception e) {
               return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message); 
            }
        }

        [HttpGet]
        [Route("api/GetById/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = ProductService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,e.Message);
            }
        }

        [HttpPost]
        [Route("api/CreateProduct")]

        public HttpResponseMessage Create(ProductDTO product)
        {
            try
            {
                ProductService.Create(product);
                return Request.CreateResponse(HttpStatusCode.OK, new {Msg="Created"});
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("api/UpdateProduct")]
        public HttpResponseMessage Update(ProductDTO product)
        {
            try
            {
                ProductService.Update(product);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("api/DeleteProduct/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                ProductService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted" });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
