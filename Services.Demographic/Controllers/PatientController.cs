using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Services.Demographic.Controllers
{
    public class PatientController : ApiController
    {
        private static List<Patient> _patients = new List<Patient>(
            new Patient[] { new Patient { PatientId = 1, FirstName = "Nilesh", LastName = "P", Address = "Bangalore" }, new Patient {PatientId = 2, FirstName = "Nishtha", LastName = "P", Address = "Bangalore" } }
        );
        
        // GET: api/Patient
        public IEnumerable<Patient> Get()
        {
            return _patients;
        }

        // GET: api/Patient/5
        public Patient Get(int id)
        {
            return _patients.FirstOrDefault(x=>x.PatientId == id);
        }

        // POST: api/Patient
        public void Post([FromBody]Patient value)
        {
            _patients.Add(value);
        }

        // PUT: api/Patient/5
        public void Put(int id, [FromBody]string value)
        {
            
        }

        // DELETE: api/Patient/5
        public void Delete(int id)
        {
            _patients.Remove(Get(id));
        }
    }
}
