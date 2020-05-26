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
    public class MA_CORRELATIVO_RETENCIONController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_CORRELATIVO_RETENCION
        public IQueryable<MA_CORRELATIVO_RETENCION> GetMA_CORRELATIVO_RETENCION()
        {
            return db.MA_CORRELATIVO_RETENCION;
        }

        // GET: api/MA_CORRELATIVO_RETENCION/5
        [ResponseType(typeof(MA_CORRELATIVO_RETENCION))]
        public IHttpActionResult GetMA_CORRELATIVO_RETENCION(string id)
        {
            MA_CORRELATIVO_RETENCION mA_CORRELATIVO_RETENCION = db.MA_CORRELATIVO_RETENCION.Find(id);
            if (mA_CORRELATIVO_RETENCION == null)
            {
                return NotFound();
            }

            return Ok(mA_CORRELATIVO_RETENCION);
        }

        // PUT: api/MA_CORRELATIVO_RETENCION/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_CORRELATIVO_RETENCION(string id, MA_CORRELATIVO_RETENCION mA_CORRELATIVO_RETENCION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_CORRELATIVO_RETENCION.CS_CAMPO)
            {
                return BadRequest();
            }

            db.Entry(mA_CORRELATIVO_RETENCION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_CORRELATIVO_RETENCIONExists(id))
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

        // POST: api/MA_CORRELATIVO_RETENCION
        [ResponseType(typeof(MA_CORRELATIVO_RETENCION))]
        public IHttpActionResult PostMA_CORRELATIVO_RETENCION(MA_CORRELATIVO_RETENCION mA_CORRELATIVO_RETENCION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_CORRELATIVO_RETENCION.Add(mA_CORRELATIVO_RETENCION);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_CORRELATIVO_RETENCIONExists(mA_CORRELATIVO_RETENCION.CS_CAMPO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_CORRELATIVO_RETENCION.CS_CAMPO }, mA_CORRELATIVO_RETENCION);
        }

        // DELETE: api/MA_CORRELATIVO_RETENCION/5
        [ResponseType(typeof(MA_CORRELATIVO_RETENCION))]
        public IHttpActionResult DeleteMA_CORRELATIVO_RETENCION(string id)
        {
            MA_CORRELATIVO_RETENCION mA_CORRELATIVO_RETENCION = db.MA_CORRELATIVO_RETENCION.Find(id);
            if (mA_CORRELATIVO_RETENCION == null)
            {
                return NotFound();
            }

            db.MA_CORRELATIVO_RETENCION.Remove(mA_CORRELATIVO_RETENCION);
            db.SaveChanges();

            return Ok(mA_CORRELATIVO_RETENCION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_CORRELATIVO_RETENCIONExists(string id)
        {
            return db.MA_CORRELATIVO_RETENCION.Count(e => e.CS_CAMPO == id) > 0;
        }
    }
}