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
    public class MA_HABLADORES_BITACORAController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_HABLADORES_BITACORA
        public IQueryable<MA_HABLADORES_BITACORA> GetMA_HABLADORES_BITACORA()
        {
            return db.MA_HABLADORES_BITACORA;
        }

        // GET: api/MA_HABLADORES_BITACORA/5
        [ResponseType(typeof(MA_HABLADORES_BITACORA))]
        public IHttpActionResult GetMA_HABLADORES_BITACORA(decimal id)
        {
            MA_HABLADORES_BITACORA mA_HABLADORES_BITACORA = db.MA_HABLADORES_BITACORA.Find(id);
            if (mA_HABLADORES_BITACORA == null)
            {
                return NotFound();
            }

            return Ok(mA_HABLADORES_BITACORA);
        }

        // PUT: api/MA_HABLADORES_BITACORA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_HABLADORES_BITACORA(decimal id, MA_HABLADORES_BITACORA mA_HABLADORES_BITACORA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_HABLADORES_BITACORA.id)
            {
                return BadRequest();
            }

            db.Entry(mA_HABLADORES_BITACORA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_HABLADORES_BITACORAExists(id))
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

        // POST: api/MA_HABLADORES_BITACORA
        [ResponseType(typeof(MA_HABLADORES_BITACORA))]
        public IHttpActionResult PostMA_HABLADORES_BITACORA(MA_HABLADORES_BITACORA mA_HABLADORES_BITACORA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_HABLADORES_BITACORA.Add(mA_HABLADORES_BITACORA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mA_HABLADORES_BITACORA.id }, mA_HABLADORES_BITACORA);
        }

        // DELETE: api/MA_HABLADORES_BITACORA/5
        [ResponseType(typeof(MA_HABLADORES_BITACORA))]
        public IHttpActionResult DeleteMA_HABLADORES_BITACORA(decimal id)
        {
            MA_HABLADORES_BITACORA mA_HABLADORES_BITACORA = db.MA_HABLADORES_BITACORA.Find(id);
            if (mA_HABLADORES_BITACORA == null)
            {
                return NotFound();
            }

            db.MA_HABLADORES_BITACORA.Remove(mA_HABLADORES_BITACORA);
            db.SaveChanges();

            return Ok(mA_HABLADORES_BITACORA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_HABLADORES_BITACORAExists(decimal id)
        {
            return db.MA_HABLADORES_BITACORA.Count(e => e.id == id) > 0;
        }
    }
}