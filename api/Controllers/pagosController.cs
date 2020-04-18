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
    public class pagosController : ApiController
    {
        private metalEntities db = new metalEntities();

        // GET: api/pagoes
        public IQueryable<pago> Getpago()
        {
            return db.pago;
        }

        // GET: api/pagoes/5
        [ResponseType(typeof(pago))]
        public IHttpActionResult Getpago(int id)
        {
            pago pago = db.pago.Find(id);
            if (pago == null)
            {
                return NotFound();
            }

            return Ok(pago);
        }

        // PUT: api/pagoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpago(int id, pago pago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pago.id)
            {
                return BadRequest();
            }

            db.Entry(pago).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pagoExists(id))
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

        // POST: api/pagoes
        [ResponseType(typeof(pago))]
        public IHttpActionResult Postpago(pago pago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.pago.Add(pago);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pago.id }, pago);
        }

        // DELETE: api/pagoes/5
        [ResponseType(typeof(pago))]
        public IHttpActionResult Deletepago(int id)
        {
            pago pago = db.pago.Find(id);
            if (pago == null)
            {
                return NotFound();
            }

            db.pago.Remove(pago);
            db.SaveChanges();

            return Ok(pago);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool pagoExists(int id)
        {
            return db.pago.Count(e => e.id == id) > 0;
        }
    }
}