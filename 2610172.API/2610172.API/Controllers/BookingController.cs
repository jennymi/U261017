using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using U241017.DATA;

namespace _2610172.API.Controllers
{
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            base.OnActionExecuted(actionExecutedContext);
        }
    }

    [AllowCrossSiteJson]

    public class BookingController : ApiController
    {
        Repository _repo = Repository.GetRepo;

        [HttpGet]
        public List<Class1>GetBookings()
        {
            return _repo.Products;
        }

        [HttpGet]
        public Class1 GetBookings(int id)
        {
            Class1 p = _repo.Products.Find(x => x.Id == id);
            return p;
        }

        [HttpPost]
        public void AddBooking(Class1 p)
        {
            _repo.Products.Add(p);

        }

        [HttpDelete]
        public void RemoveProduct(int id)
        {
            Class1 p = _repo.Products.Find(x => x.Id == id);
            _repo.Products.Remove(p);
        }
    }
}
