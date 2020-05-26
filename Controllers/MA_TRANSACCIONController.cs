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
    public class MA_TRANSACCIONController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_TRANSACCION
        public IQueryable<MA_TRANSACCION> GetMA_TRANSACCION()
        {
            return db.MA_TRANSACCION;
        }

        // GET: api/MA_TRANSACCION/5
        [ResponseType(typeof(MA_TRANSACCION))]
        public IHttpActionResult GetMA_TRANSACCION(string id)
        {
            MA_TRANSACCION mA_TRANSACCION = db.MA_TRANSACCION.Find(id);
            if (mA_TRANSACCION == null)
            {
                return NotFound();
            }

            return Ok(mA_TRANSACCION);
        }

        // PUT: api/MA_TRANSACCION/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_TRANSACCION(string id, MA_TRANSACCION mA_TRANSACCION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_TRANSACCION.c_Numero)
            {
                return BadRequest();
            }

            db.Entry(mA_TRANSACCION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_TRANSACCIONExists(id))
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

        // POST: api/MA_TRANSACCION
        [ResponseType(typeof(MA_TRANSACCION))]
        public IHttpActionResult PostMA_TRANSACCION(MA_TRANSACCION mA_TRANSACCION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_TRANSACCION.Add(mA_TRANSACCION);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_TRANSACCIONExists(mA_TRANSACCION.c_Numero))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_TRANSACCION.c_Numero }, mA_TRANSACCION);
        }

        // DELETE: api/MA_TRANSACCION/5
        [ResponseType(typeof(MA_TRANSACCION))]
        public IHttpActionResult DeleteMA_TRANSACCION(string id)
        {
            MA_TRANSACCION mA_TRANSACCION = db.MA_TRANSACCION.Find(id);
            if (mA_TRANSACCION == null)
            {
                return NotFound();
            }

            db.MA_TRANSACCION.Remove(mA_TRANSACCION);
            db.SaveChanges();

            return Ok(mA_TRANSACCION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_TRANSACCIONExists(string id)
        {
            return db.MA_TRANSACCION.Count(e => e.c_Numero == id) > 0;
        }
    }
}