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
    public class MA_CAJA_CONFIGURACIONController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_CAJA_CONFIGURACION
        public IQueryable<MA_CAJA_CONFIGURACION> GetMA_CAJA_CONFIGURACION()
        {
            return db.MA_CAJA_CONFIGURACION;
        }

        // GET: api/MA_CAJA_CONFIGURACION/5
        [ResponseType(typeof(MA_CAJA_CONFIGURACION))]
        public IHttpActionResult GetMA_CAJA_CONFIGURACION(string id)
        {
            MA_CAJA_CONFIGURACION mA_CAJA_CONFIGURACION = db.MA_CAJA_CONFIGURACION.Find(id);
            if (mA_CAJA_CONFIGURACION == null)
            {
                return NotFound();
            }

            return Ok(mA_CAJA_CONFIGURACION);
        }

        // PUT: api/MA_CAJA_CONFIGURACION/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_CAJA_CONFIGURACION(string id, MA_CAJA_CONFIGURACION mA_CAJA_CONFIGURACION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_CAJA_CONFIGURACION.CAJA)
            {
                return BadRequest();
            }

            db.Entry(mA_CAJA_CONFIGURACION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_CAJA_CONFIGURACIONExists(id))
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

        // POST: api/MA_CAJA_CONFIGURACION
        [ResponseType(typeof(MA_CAJA_CONFIGURACION))]
        public IHttpActionResult PostMA_CAJA_CONFIGURACION(MA_CAJA_CONFIGURACION mA_CAJA_CONFIGURACION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_CAJA_CONFIGURACION.Add(mA_CAJA_CONFIGURACION);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_CAJA_CONFIGURACIONExists(mA_CAJA_CONFIGURACION.CAJA))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_CAJA_CONFIGURACION.CAJA }, mA_CAJA_CONFIGURACION);
        }

        // DELETE: api/MA_CAJA_CONFIGURACION/5
        [ResponseType(typeof(MA_CAJA_CONFIGURACION))]
        public IHttpActionResult DeleteMA_CAJA_CONFIGURACION(string id)
        {
            MA_CAJA_CONFIGURACION mA_CAJA_CONFIGURACION = db.MA_CAJA_CONFIGURACION.Find(id);
            if (mA_CAJA_CONFIGURACION == null)
            {
                return NotFound();
            }

            db.MA_CAJA_CONFIGURACION.Remove(mA_CAJA_CONFIGURACION);
            db.SaveChanges();

            return Ok(mA_CAJA_CONFIGURACION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_CAJA_CONFIGURACIONExists(string id)
        {
            return db.MA_CAJA_CONFIGURACION.Count(e => e.CAJA == id) > 0;
        }
    }
}