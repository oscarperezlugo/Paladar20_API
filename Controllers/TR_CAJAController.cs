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
    public class TR_CAJAController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/TR_CAJA
        public IQueryable<TR_CAJA> GetTR_CAJA()
        {
            return db.TR_CAJA;
        }

        // GET: api/TR_CAJA/5
        [ResponseType(typeof(TR_CAJA))]
        public IHttpActionResult GetTR_CAJA(string id)
        {
            TR_CAJA tR_CAJA = db.TR_CAJA.Find(id);
            if (tR_CAJA == null)
            {
                return NotFound();
            }

            return Ok(tR_CAJA);
        }

        // PUT: api/TR_CAJA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_CAJA(string id, TR_CAJA tR_CAJA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_CAJA.cs_CAJA)
            {
                return BadRequest();
            }

            db.Entry(tR_CAJA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_CAJAExists(id))
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

        // POST: api/TR_CAJA
        [ResponseType(typeof(TR_CAJA))]
        public IHttpActionResult PostTR_CAJA(TR_CAJA tR_CAJA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_CAJA.Add(tR_CAJA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_CAJAExists(tR_CAJA.cs_CAJA))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_CAJA.cs_CAJA }, tR_CAJA);
        }

        // DELETE: api/TR_CAJA/5
        [ResponseType(typeof(TR_CAJA))]
        public IHttpActionResult DeleteTR_CAJA(string id)
        {
            TR_CAJA tR_CAJA = db.TR_CAJA.Find(id);
            if (tR_CAJA == null)
            {
                return NotFound();
            }

            db.TR_CAJA.Remove(tR_CAJA);
            db.SaveChanges();

            return Ok(tR_CAJA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_CAJAExists(string id)
        {
            return db.TR_CAJA.Count(e => e.cs_CAJA == id) > 0;
        }
    }
}