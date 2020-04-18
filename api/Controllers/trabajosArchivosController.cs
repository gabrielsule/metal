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
    public class trabajosArchivosController : ApiController
    {
        private metalEntities db = new metalEntities();

        // GET: api/trabajosArchivos
        public IQueryable<trabajosArchivos> GettrabajosArchivos()
        {
            return db.trabajosArchivos;
        }

        // GET: api/trabajosArchivos/5
        [ResponseType(typeof(trabajosArchivos))]
        public IHttpActionResult GettrabajosArchivos(Guid id)
        {
            trabajosArchivos trabajosArchivos = db.trabajosArchivos.Find(id);
            if (trabajosArchivos == null)
            {
                return NotFound();
            }

            return Ok(trabajosArchivos);
        }

        // PUT: api/trabajosArchivos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttrabajosArchivos(Guid id, trabajosArchivos trabajosArchivos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trabajosArchivos.id)
            {
                return BadRequest();
            }

            db.Entry(trabajosArchivos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!trabajosArchivosExists(id))
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

        // POST: api/trabajosArchivos
        [ResponseType(typeof(trabajosArchivos))]
        public IHttpActionResult PosttrabajosArchivos(trabajosArchivos trabajosArchivos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.trabajosArchivos.Add(trabajosArchivos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (trabajosArchivosExists(trabajosArchivos.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = trabajosArchivos.id }, trabajosArchivos);
        }

        // DELETE: api/trabajosArchivos/5
        [ResponseType(typeof(trabajosArchivos))]
        public IHttpActionResult DeletetrabajosArchivos(Guid id)
        {
            trabajosArchivos trabajosArchivos = db.trabajosArchivos.Find(id);
            if (trabajosArchivos == null)
            {
                return NotFound();
            }

            db.trabajosArchivos.Remove(trabajosArchivos);
            db.SaveChanges();

            return Ok(trabajosArchivos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool trabajosArchivosExists(Guid id)
        {
            return db.trabajosArchivos.Count(e => e.id == id) > 0;
        }
    }
}