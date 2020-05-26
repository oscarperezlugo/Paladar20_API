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
    public class TR_CIERRESController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/TR_CIERRES
        public IQueryable<TR_CIERRES> GetTR_CIERRES()
        {
            return db.TR_CIERRES;
        }

        // GET: api/TR_CIERRES/5
        [ResponseType(typeof(TR_CIERRES))]
        public IHttpActionResult GetTR_CIERRES(string id)
        {
            TR_CIERRES tR_CIERRES = db.TR_CIERRES.Find(id);
            if (tR_CIERRES == null)
            {
                return NotFound();
            }

            return Ok(tR_CIERRES);
        }

        // PUT: api/TR_CIERRES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_CIERRES(string id, TR_CIERRES tR_CIERRES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_CIERRES.c_DOCUMENTO)
            {
                return BadRequest();
            }

            db.Entry(tR_CIERRES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_CIERRESExists(id))
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

        // POST: api/TR_CIERRES
        [ResponseType(typeof(TR_CIERRES))]
        public IHttpActionResult PostTR_CIERRES(TR_CIERRES tR_CIERRES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_CIERRES.Add(tR_CIERRES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_CIERRESExists(tR_CIERRES.c_DOCUMENTO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_CIERRES.c_DOCUMENTO }, tR_CIERRES);
        }

        // DELETE: api/TR_CIERRES/5
        [ResponseType(typeof(TR_CIERRES))]
        public IHttpActionResult DeleteTR_CIERRES(string id)
        {
            TR_CIERRES tR_CIERRES = db.TR_CIERRES.Find(id);
            if (tR_CIERRES == null)
            {
                return NotFound();
            }

            db.TR_CIERRES.Remove(tR_CIERRES);
            db.SaveChanges();

            return Ok(tR_CIERRES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_CIERRESExists(string id)
        {
            return db.TR_CIERRES.Count(e => e.c_DOCUMENTO == id) > 0;
        }
    }
}