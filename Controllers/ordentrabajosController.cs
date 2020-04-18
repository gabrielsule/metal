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
using Metal.Models;

namespace Metal.Controllers
{
    public class ordentrabajosController : ApiController
    {
        private metalEntities db = new metalEntities();

        // GET: api/ordentrabajoes
        public IQueryable<ordentrabajo> Getordentrabajo()
        {
            return db.ordentrabajo;
        }

        // GET: api/ordentrabajoes/5
        [ResponseType(typeof(ordentrabajo))]
        public IHttpActionResult Getordentrabajo(int id)
        {
            ordentrabajo ordentrabajo = db.ordentrabajo.Find(id);
            if (ordentrabajo == null)
            {
                return NotFound();
            }

            return Ok(ordentrabajo);
        }

        // PUT: api/ordentrabajoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putordentrabajo(int id, ordentrabajo ordentrabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ordentrabajo.id)
            {
                return BadRequest();
            }

            db.Entry(ordentrabajo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ordentrabajoExists(id))
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

        // POST: api/ordentrabajoes
        [ResponseType(typeof(ordentrabajo))]
        public IHttpActionResult Postordentrabajo(ordentrabajo ordentrabajo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ordentrabajo.Add(ordentrabajo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ordentrabajo.id }, ordentrabajo);
        }

        // DELETE: api/ordentrabajoes/5
        [ResponseType(typeof(ordentrabajo))]
        public IHttpActionResult Deleteordentrabajo(int id)
        {
            ordentrabajo ordentrabajo = db.ordentrabajo.Find(id);
            if (ordentrabajo == null)
            {
                return NotFound();
            }

            db.ordentrabajo.Remove(ordentrabajo);
            db.SaveChanges();

            return Ok(ordentrabajo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ordentrabajoExists(int id)
        {
            return db.ordentrabajo.Count(e => e.id == id) > 0;
        }
    }
}