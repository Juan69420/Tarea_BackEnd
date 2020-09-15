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
using Tarea_BackEnd.Models;

namespace Tarea_BackEnd.Controllers
{
    public class GianellasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Gianellas
        [Authorize]
        public IQueryable<Gianella> GetGianellas()
        {
            return db.Gianellas;
        }

        // GET: api/Gianellas/5
        [Authorize]
        [ResponseType(typeof(Gianella))]
        public IHttpActionResult GetGianella(int id)
        {
            Gianella gianella = db.Gianellas.Find(id);
            if (gianella == null)
            {
                return NotFound();
            }

            return Ok(gianella);
        }

        // PUT: api/Gianellas/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGianella(int id, Gianella gianella)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gianella.gianellaID)
            {
                return BadRequest();
            }

            db.Entry(gianella).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GianellaExists(id))
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

        // POST: api/Gianellas
        [Authorize]
        [ResponseType(typeof(Gianella))]
        public IHttpActionResult PostGianella(Gianella gianella)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gianellas.Add(gianella);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gianella.gianellaID }, gianella);
        }

        // DELETE: api/Gianellas/5
        [Authorize]
        [ResponseType(typeof(Gianella))]
        public IHttpActionResult DeleteGianella(int id)
        {
            Gianella gianella = db.Gianellas.Find(id);
            if (gianella == null)
            {
                return NotFound();
            }

            db.Gianellas.Remove(gianella);
            db.SaveChanges();

            return Ok(gianella);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GianellaExists(int id)
        {
            return db.Gianellas.Count(e => e.gianellaID == id) > 0;
        }
    }
}