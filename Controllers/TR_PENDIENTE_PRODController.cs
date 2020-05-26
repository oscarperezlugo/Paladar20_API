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
    public class TR_PENDIENTE_PRODController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/TR_PENDIENTE_PROD
        public IQueryable<TR_PENDIENTE_PROD> GetTR_PENDIENTE_PROD()
        {
            return db.TR_PENDIENTE_PROD;
        }

        // GET: api/TR_PENDIENTE_PROD/5
        [ResponseType(typeof(TR_PENDIENTE_PROD))]
        public IHttpActionResult GetTR_PENDIENTE_PROD(decimal id)
        {
            TR_PENDIENTE_PROD tR_PENDIENTE_PROD = db.TR_PENDIENTE_PROD.Find(id);
            if (tR_PENDIENTE_PROD == null)
            {
                return NotFound();
            }

            return Ok(tR_PENDIENTE_PROD);
        }

        // PUT: api/TR_PENDIENTE_PROD/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_PENDIENTE_PROD(decimal id, TR_PENDIENTE_PROD tR_PENDIENTE_PROD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_PENDIENTE_PROD.ID)
            {
                return BadRequest();
            }

            db.Entry(tR_PENDIENTE_PROD).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_PENDIENTE_PRODExists(id))
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

        // POST: api/TR_PENDIENTE_PROD
        [ResponseType(typeof(TR_PENDIENTE_PROD))]
        public IHttpActionResult PostTR_PENDIENTE_PROD(TR_PENDIENTE_PROD tR_PENDIENTE_PROD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_PENDIENTE_PROD.Add(tR_PENDIENTE_PROD);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_PENDIENTE_PRODExists(tR_PENDIENTE_PROD.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_PENDIENTE_PROD.ID }, tR_PENDIENTE_PROD);
        }

        // DELETE: api/TR_PENDIENTE_PROD/5
        [ResponseType(typeof(TR_PENDIENTE_PROD))]
        public IHttpActionResult DeleteTR_PENDIENTE_PROD(decimal id)
        {
            TR_PENDIENTE_PROD tR_PENDIENTE_PROD = db.TR_PENDIENTE_PROD.Find(id);
            if (tR_PENDIENTE_PROD == null)
            {
                return NotFound();
            }

            db.TR_PENDIENTE_PROD.Remove(tR_PENDIENTE_PROD);
            db.SaveChanges();

            return Ok(tR_PENDIENTE_PROD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_PENDIENTE_PRODExists(decimal id)
        {
            return db.TR_PENDIENTE_PROD.Count(e => e.ID == id) > 0;
        }
    }
}