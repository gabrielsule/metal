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
    public class materialesController : ApiController
    {
        private metalEntities db = new metalEntities();

        // GET: api/materiales
        public IQueryable<material> Getmaterial()
        {
            return db.material;
        }

        // GET: api/materiales/5
        [ResponseType(typeof(material))]
        public IHttpActionResult Getmaterial(int id)
        {
            material material = db.material.Find(id);
            if (material == null)
            {
                return NotFound();
            }

            return Ok(material);
        }

        // PUT: api/materiales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmaterial(int id, material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != material.id)
            {
                return BadRequest();
            }

            db.Entry(material).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!materialExists(id))
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

        // POST: api/materiales
        [ResponseType(typeof(material))]
        public IHttpActionResult Postmaterial(material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.material.Add(material);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = material.id }, material);
        }

        // DELETE: api/materiales/5
        [ResponseType(typeof(material))]
        public IHttpActionResult Deletematerial(int id)
        {
            material material = db.material.Find(id);
            if (material == null)
            {
                return NotFound();
            }

            db.material.Remove(material);
            db.SaveChanges();

            return Ok(material);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool materialExists(int id)
        {
            return db.material.Count(e => e.id == id) > 0;
        }
    }
}