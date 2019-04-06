using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnApi.Controllers
{
    public class ValuesController : ApiController
    {
        static List<string> valueList = new List<string>()
        {"piyu","sukanta" };



        // GET api/values
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, valueList);
            return response;
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, valueList[id]);
               
            }
            catch (Exception)
            {

                response = Request.CreateErrorResponse(HttpStatusCode.NotFound,"Invalid id");
            }
            return response;
           
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]string value)
        {
            HttpResponseMessage response;
            try
            {
                
                valueList.Add(value);
                response = Request.CreateResponse(HttpStatusCode.Created);
               
            }
            catch (Exception)
            {

                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad request");
            }
            return response;
           
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            HttpResponseMessage response;
            try
            {
                valueList[id] = value;
                response = Request.CreateResponse(HttpStatusCode.NoContent);
                
            }
            catch (Exception)
            {

                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad request");
            }

            return response;
            

        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response;
           
            try
            {
                var deleteval = valueList[id];
                valueList.Remove(deleteval);
                response = Request.CreateResponse(HttpStatusCode.OK);
                
            }
            catch (Exception)
            {

                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Index");
            }

            return response;
        }
    }
}
