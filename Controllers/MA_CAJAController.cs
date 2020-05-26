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
    public class MA_CAJAController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_CAJA
        public IQueryable<MA_CAJA> GetMA_CAJA()
        {
            return db.MA_CAJA;
        }

        // GET: api/MA_CAJA/5
        [ResponseType(typeof(MA_CAJA))]
        public IHttpActionResult GetMA_CAJA(string id)
        {
            MA_CAJA mA_CAJA = db.MA_CAJA.Find(id);
            if (mA_CAJA == null)
            {
                return NotFound();
            }

            return Ok(mA_CAJA);
        }

        // PUT: api/MA_CAJA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_CAJA(string id, MA_CAJA mA_CAJA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_CAJA.C_Codigo)
            {
                return BadRequest();
            }

            db.Entry(mA_CAJA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_CAJAExists(id))
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

        // POST: api/MA_CAJA
        [ResponseType(typeof(MA_CAJA))]
        public IHttpActionResult PostMA_CAJA(MA_CAJA mA_CAJA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_CAJA.Add(mA_CAJA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_CAJAExists(mA_CAJA.C_Codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_CAJA.C_Codigo }, mA_CAJA);
        }

        // DELETE: api/MA_CAJA/5
        [ResponseType(typeof(MA_CAJA))]
        public IHttpActionResult DeleteMA_CAJA(string id)
        {
            MA_CAJA mA_CAJA = db.MA_CAJA.Find(id);
            if (mA_CAJA == null)
            {
                return NotFound();
            }

            db.MA_CAJA.Remove(mA_CAJA);
            db.SaveChanges();

            return Ok(mA_CAJA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_CAJAExists(string id)
        {
            return db.MA_CAJA.Count(e => e.C_Codigo == id) > 0;
        }
    }
}