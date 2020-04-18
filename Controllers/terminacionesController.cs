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
    public class terminacionesController : ApiController
    {
        private metalEntities db = new metalEntities();

        // GET: api/terminaciones
        public IQueryable<terminacion> Getterminacion()
        {
            return db.terminacion;
        }

        // GET: api/terminaciones/5
        [ResponseType(typeof(terminacion))]
        public IHttpActionResult Getterminacion(int id)
        {
            terminacion terminacion = db.terminacion.Find(id);
            if (terminacion == null)
            {
                return NotFound();
            }

            return Ok(terminacion);
        }

        // PUT: api/terminaciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putterminacion(int id, terminacion terminacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != terminacion.id)
            {
                return BadRequest();
            }

            db.Entry(terminacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!terminacionExists(id))
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

        // POST: api/terminaciones
        [ResponseType(typeof(terminacion))]
        public IHttpActionResult Postterminacion(terminacion terminacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.terminacion.Add(terminacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = terminacion.id }, terminacion);
        }

        // DELETE: api/terminaciones/5
        [ResponseType(typeof(terminacion))]
        public IHttpActionResult Deleteterminacion(int id)
        {
            terminacion terminacion = db.terminacion.Find(id);
            if (terminacion == null)
            {
                return NotFound();
            }

            db.terminacion.Remove(terminacion);
            db.SaveChanges();

            return Ok(terminacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool terminacionExists(int id)
        {
            return db.terminacion.Count(e => e.id == id) > 0;
        }
    }
}