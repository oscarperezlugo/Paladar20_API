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
    public class MA_DETALLEPAGOController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_DETALLEPAGO
        public IQueryable<MA_DETALLEPAGO> GetMA_DETALLEPAGO()
        {
            return db.MA_DETALLEPAGO;
        }

        // GET: api/MA_DETALLEPAGO/5
        [ResponseType(typeof(MA_DETALLEPAGO))]
        public IHttpActionResult GetMA_DETALLEPAGO(string id)
        {
            MA_DETALLEPAGO mA_DETALLEPAGO = db.MA_DETALLEPAGO.Find(id);
            if (mA_DETALLEPAGO == null)
            {
                return NotFound();
            }

            return Ok(mA_DETALLEPAGO);
        }

        // PUT: api/MA_DETALLEPAGO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_DETALLEPAGO(string id, MA_DETALLEPAGO mA_DETALLEPAGO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_DETALLEPAGO.c_Caja)
            {
                return BadRequest();
            }

            db.Entry(mA_DETALLEPAGO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_DETALLEPAGOExists(id))
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

        // POST: api/MA_DETALLEPAGO
        [ResponseType(typeof(MA_DETALLEPAGO))]
        public IHttpActionResult PostMA_DETALLEPAGO(MA_DETALLEPAGO mA_DETALLEPAGO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_DETALLEPAGO.Add(mA_DETALLEPAGO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_DETALLEPAGOExists(mA_DETALLEPAGO.c_Caja))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_DETALLEPAGO.c_Caja }, mA_DETALLEPAGO);
        }

        // DELETE: api/MA_DETALLEPAGO/5
        [ResponseType(typeof(MA_DETALLEPAGO))]
        public IHttpActionResult DeleteMA_DETALLEPAGO(string id)
        {
            MA_DETALLEPAGO mA_DETALLEPAGO = db.MA_DETALLEPAGO.Find(id);
            if (mA_DETALLEPAGO == null)
            {
                return NotFound();
            }

            db.MA_DETALLEPAGO.Remove(mA_DETALLEPAGO);
            db.SaveChanges();

            return Ok(mA_DETALLEPAGO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_DETALLEPAGOExists(string id)
        {
            return db.MA_DETALLEPAGO.Count(e => e.c_Caja == id) > 0;
        }
    }
}