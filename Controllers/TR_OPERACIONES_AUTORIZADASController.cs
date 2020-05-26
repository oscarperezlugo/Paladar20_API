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
using Paladar20_API.Models;

namespace Paladar20_API.Controllers
{
    public class TR_OPERACIONES_AUTORIZADASController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/TR_OPERACIONES_AUTORIZADAS
        public IQueryable<TR_OPERACIONES_AUTORIZADAS> GetTR_OPERACIONES_AUTORIZADAS()
        {
            return db.TR_OPERACIONES_AUTORIZADAS;
        }

        // GET: api/TR_OPERACIONES_AUTORIZADAS/5
        [ResponseType(typeof(TR_OPERACIONES_AUTORIZADAS))]
        public IHttpActionResult GetTR_OPERACIONES_AUTORIZADAS(decimal id)
        {
            TR_OPERACIONES_AUTORIZADAS tR_OPERACIONES_AUTORIZADAS = db.TR_OPERACIONES_AUTORIZADAS.Find(id);
            if (tR_OPERACIONES_AUTORIZADAS == null)
            {
                return NotFound();
            }

            return Ok(tR_OPERACIONES_AUTORIZADAS);
        }

        // PUT: api/TR_OPERACIONES_AUTORIZADAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_OPERACIONES_AUTORIZADAS(decimal id, TR_OPERACIONES_AUTORIZADAS tR_OPERACIONES_AUTORIZADAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_OPERACIONES_AUTORIZADAS.id)
            {
                return BadRequest();
            }

            db.Entry(tR_OPERACIONES_AUTORIZADAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_OPERACIONES_AUTORIZADASExists(id))
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

        // POST: api/TR_OPERACIONES_AUTORIZADAS
        [ResponseType(typeof(TR_OPERACIONES_AUTORIZADAS))]
        public IHttpActionResult PostTR_OPERACIONES_AUTORIZADAS(TR_OPERACIONES_AUTORIZADAS tR_OPERACIONES_AUTORIZADAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_OPERACIONES_AUTORIZADAS.Add(tR_OPERACIONES_AUTORIZADAS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tR_OPERACIONES_AUTORIZADAS.id }, tR_OPERACIONES_AUTORIZADAS);
        }

        // DELETE: api/TR_OPERACIONES_AUTORIZADAS/5
        [ResponseType(typeof(TR_OPERACIONES_AUTORIZADAS))]
        public IHttpActionResult DeleteTR_OPERACIONES_AUTORIZADAS(decimal id)
        {
            TR_OPERACIONES_AUTORIZADAS tR_OPERACIONES_AUTORIZADAS = db.TR_OPERACIONES_AUTORIZADAS.Find(id);
            if (tR_OPERACIONES_AUTORIZADAS == null)
            {
                return NotFound();
            }

            db.TR_OPERACIONES_AUTORIZADAS.Remove(tR_OPERACIONES_AUTORIZADAS);
            db.SaveChanges();

            return Ok(tR_OPERACIONES_AUTORIZADAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_OPERACIONES_AUTORIZADASExists(decimal id)
        {
            return db.TR_OPERACIONES_AUTORIZADAS.Count(e => e.id == id) > 0;
        }
    }
}