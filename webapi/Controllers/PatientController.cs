using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using webapi.Models;
using LoggerFactory; 

namespace webapi.Controllers
{
    public class PatientController : ApiController
    {
        private CRUDDATABASEEntities db = new CRUDDATABASEEntities();

        // GET: api/Patient
        public IQueryable<PatientNewModel> GetPatients()
        {
            var patients = db.Patients.Include(p => p.Gender).Select(p => new PatientNewModel
            {
                Id = p.Id,
                PatientName = p.PatientName,
                Gender = new Genders
                {
                    Name = p.Gender.Name
                },
                DOB = p.DOB,
                Height = p.Height,
                Weight = p.Weight,
                BMI = p.BMI,
                created_on = p.created_on,
                updated_on = p.updated_on,
                create_by = p.create_by,
                updated_by = p.updated_by
            });

            return patients;
        }

        // GET: api/Patient/5
        [ResponseType(typeof(Patient))]
        public IHttpActionResult GetPatient(long id)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // PUT: api/Patient/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatient(long id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            db.Entry(patient).State = EntityState.Modified;

            try
            {
                patient.updated_on = DateTime.Now;
                patient.updated_by = 1;
                patient.create_by = 1;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

       
        // POST: api/Patient
        [ResponseType(typeof(Patient))]
        public IHttpActionResult PostPatient(Patient patient)
        {
            try
            {
                // Simulate a scenario where patient name is required
                if (string.IsNullOrWhiteSpace(patient.PatientName))
                {
                    throw new ArgumentException("Patient name is required.");
                }

                patient.created_on = DateTime.Now;
                patient.create_by = 1;

                
                db.Patients.Add(patient);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = patient.Id }, patient);
            }
            catch (Exception ex)
            {
                // Log the exception
                LoggerFactory.Factory.LogException(ex);
                // Return a server error response
                return InternalServerError(ex);
            }
        }


        // DELETE: api/Patient/5
        [ResponseType(typeof(Patient))]
        public IHttpActionResult DeletePatient(long id)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            db.Patients.Remove(patient);
            db.SaveChanges();

            return Ok(patient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientExists(long id)
        {
            return db.Patients.Count(e => e.Id == id) > 0;
        }
      
    }
}
