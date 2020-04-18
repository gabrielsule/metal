using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Metal.Models;

namespace Metal.Controllers
{
    public class archivosController : ApiController
    {
        private metalEntities db = new metalEntities();

        // GET: api/archivos
        public IQueryable<archivos> Getarchivos()
        {
            return db.archivos;
        }

        // GET: api/archivos/5
        [ResponseType(typeof(archivos))]
        public IHttpActionResult Getarchivos(int id)
        {
            archivos archivos = db.archivos.Find(id);
            if (archivos == null)
            {
                return NotFound();
            }

            return Ok(archivos);
        }

        // PUT: api/archivos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putarchivos(int id, archivos archivos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != archivos.id)
            {
                return BadRequest();
            }

            db.Entry(archivos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!archivosExists(id))
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

        // POST: api/archivos
        [ResponseType(typeof(archivos))]
        public IHttpActionResult Postarchivos(archivos archivos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.archivos.Add(archivos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = archivos.id }, archivos);
        }

        // DELETE: api/archivos/5
        [ResponseType(typeof(archivos))]
        public IHttpActionResult Deletearchivos(int id)
        {
            archivos archivos = db.archivos.Find(id);
            if (archivos == null)
            {
                return NotFound();
            }

            db.archivos.Remove(archivos);
            db.SaveChanges();

            return Ok(archivos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool archivosExists(int id)
        {
            return db.archivos.Count(e => e.id == id) > 0;
        }
    }
}