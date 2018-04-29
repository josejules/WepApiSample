using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WepApiSample.Models;

namespace WepApiSample.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeEntities dbContext = new EmployeeEntities();

        public IQueryable<tblEmployee> GetEmployees()
        {
            return dbContext.tblEmployees;
        }

        public IHttpActionResult GetEmployee(int id)
        {
            tblEmployee emp = dbContext.tblEmployees.FirstOrDefault(x => x.EmployeeId == id);
            if (emp == null)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, "Employee Not Found");
            }
            return Ok(emp);
        }

        public HttpResponseMessage PostEmployee([FromBody]tblEmployee employee)
        {
            try
            {
                dbContext.tblEmployees.Add(employee);
                dbContext.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                message.Headers.Location = new Uri(Request.RequestUri + employee.EmployeeId.ToString());
                return message;
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
