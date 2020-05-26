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
    public class MA_ESTRUC_CAJAController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_ESTRUC_CAJA
        public IQueryable<MA_ESTRUC_CAJA> GetMA_ESTRUC_CAJA()
        {
            return db.MA_ESTRUC_CAJA;
        }

        // GET: api/MA_ESTRUC_CAJA/5
        [ResponseType(typeof(MA_ESTRUC_CAJA))]
        public IHttpActionResult GetMA_ESTRUC_CAJA(string id)
        {
            MA_ESTRUC_CAJA mA_ESTRUC_CAJA = db.MA_ESTRUC_CAJA.Find(id);
            if (mA_ESTRUC_CAJA == null)
            {
                return NotFound();
            }

            return Ok(mA_ESTRUC_CAJA);
        }

        // PUT: api/MA_ESTRUC_CAJA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_ESTRUC_CAJA(string id, MA_ESTRUC_CAJA mA_ESTRUC_CAJA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_ESTRUC_CAJA.CLAVE)
            {
                return BadRequest();
            }

            db.Entry(mA_ESTRUC_CAJA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_ESTRUC_CAJAExists(id))
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

        // POST: api/MA_ESTRUC_CAJA
        [ResponseType(typeof(MA_ESTRUC_CAJA))]
        public IHttpActionResult PostMA_ESTRUC_CAJA(MA_ESTRUC_CAJA mA_ESTRUC_CAJA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_ESTRUC_CAJA.Add(mA_ESTRUC_CAJA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_ESTRUC_CAJAExists(mA_ESTRUC_CAJA.CLAVE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_ESTRUC_CAJA.CLAVE }, mA_ESTRUC_CAJA);
        }

        // DELETE: api/MA_ESTRUC_CAJA/5
        [ResponseType(typeof(MA_ESTRUC_CAJA))]
        public IHttpActionResult DeleteMA_ESTRUC_CAJA(string id)
        {
            MA_ESTRUC_CAJA mA_ESTRUC_CAJA = db.MA_ESTRUC_CAJA.Find(id);
            if (mA_ESTRUC_CAJA == null)
            {
                return NotFound();
            }

            db.MA_ESTRUC_CAJA.Remove(mA_ESTRUC_CAJA);
            db.SaveChanges();

            return Ok(mA_ESTRUC_CAJA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_ESTRUC_CAJAExists(string id)
        {
            return db.MA_ESTRUC_CAJA.Count(e => e.CLAVE == id) > 0;
        }
    }
}