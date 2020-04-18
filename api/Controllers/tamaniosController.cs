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
    public class tamaniosController : ApiController
    {
        private metalEntities db = new metalEntities();

        // GET: api/tamanios
        public IQueryable<tamanio> Gettamanio()
        {
            return db.tamanio;
        }

        // GET: api/tamanios/5
        [ResponseType(typeof(tamanio))]
        public IHttpActionResult Gettamanio(int id)
        {
            tamanio tamanio = db.tamanio.Find(id);
            if (tamanio == null)
            {
                return NotFound();
            }

            return Ok(tamanio);
        }

        // PUT: api/tamanios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttamanio(int id, tamanio tamanio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tamanio.id)
            {
                return BadRequest();
            }

            db.Entry(tamanio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tamanioExists(id))
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

        // POST: api/tamanios
        [ResponseType(typeof(tamanio))]
        public IHttpActionResult Posttamanio(tamanio tamanio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tamanio.Add(tamanio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tamanio.id }, tamanio);
        }

        // DELETE: api/tamanios/5
        [ResponseType(typeof(tamanio))]
        public IHttpActionResult Deletetamanio(int id)
        {
            tamanio tamanio = db.tamanio.Find(id);
            if (tamanio == null)
            {
                return NotFound();
            }

            db.tamanio.Remove(tamanio);
            db.SaveChanges();

            return Ok(tamanio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tamanioExists(int id)
        {
            return db.tamanio.Count(e => e.id == id) > 0;
        }
    }
}