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
    public class MA_DISPOSITIVOS_CAJAController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_DISPOSITIVOS_CAJA
        public IQueryable<MA_DISPOSITIVOS_CAJA> GetMA_DISPOSITIVOS_CAJA()
        {
            return db.MA_DISPOSITIVOS_CAJA;
        }

        // GET: api/MA_DISPOSITIVOS_CAJA/5
        [ResponseType(typeof(MA_DISPOSITIVOS_CAJA))]
        public IHttpActionResult GetMA_DISPOSITIVOS_CAJA(string id)
        {
            MA_DISPOSITIVOS_CAJA mA_DISPOSITIVOS_CAJA = db.MA_DISPOSITIVOS_CAJA.Find(id);
            if (mA_DISPOSITIVOS_CAJA == null)
            {
                return NotFound();
            }

            return Ok(mA_DISPOSITIVOS_CAJA);
        }

        // PUT: api/MA_DISPOSITIVOS_CAJA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_DISPOSITIVOS_CAJA(string id, MA_DISPOSITIVOS_CAJA mA_DISPOSITIVOS_CAJA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_DISPOSITIVOS_CAJA.CAJA)
            {
                return BadRequest();
            }

            db.Entry(mA_DISPOSITIVOS_CAJA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_DISPOSITIVOS_CAJAExists(id))
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

        // POST: api/MA_DISPOSITIVOS_CAJA
        [ResponseType(typeof(MA_DISPOSITIVOS_CAJA))]
        public IHttpActionResult PostMA_DISPOSITIVOS_CAJA(MA_DISPOSITIVOS_CAJA mA_DISPOSITIVOS_CAJA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_DISPOSITIVOS_CAJA.Add(mA_DISPOSITIVOS_CAJA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_DISPOSITIVOS_CAJAExists(mA_DISPOSITIVOS_CAJA.CAJA))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_DISPOSITIVOS_CAJA.CAJA }, mA_DISPOSITIVOS_CAJA);
        }

        // DELETE: api/MA_DISPOSITIVOS_CAJA/5
        [ResponseType(typeof(MA_DISPOSITIVOS_CAJA))]
        public IHttpActionResult DeleteMA_DISPOSITIVOS_CAJA(string id)
        {
            MA_DISPOSITIVOS_CAJA mA_DISPOSITIVOS_CAJA = db.MA_DISPOSITIVOS_CAJA.Find(id);
            if (mA_DISPOSITIVOS_CAJA == null)
            {
                return NotFound();
            }

            db.MA_DISPOSITIVOS_CAJA.Remove(mA_DISPOSITIVOS_CAJA);
            db.SaveChanges();

            return Ok(mA_DISPOSITIVOS_CAJA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_DISPOSITIVOS_CAJAExists(string id)
        {
            return db.MA_DISPOSITIVOS_CAJA.Count(e => e.CAJA == id) > 0;
        }
    }
}