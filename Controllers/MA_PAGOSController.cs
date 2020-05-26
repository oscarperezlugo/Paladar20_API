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
    public class MA_PAGOSController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_PAGOS
        public IQueryable<MA_PAGOS> GetMA_PAGOS()
        {
            return db.MA_PAGOS;
        }

        // GET: api/MA_PAGOS/5
        [ResponseType(typeof(MA_PAGOS))]
        public IHttpActionResult GetMA_PAGOS(string id)
        {
            MA_PAGOS mA_PAGOS = db.MA_PAGOS.Find(id);
            if (mA_PAGOS == null)
            {
                return NotFound();
            }

            return Ok(mA_PAGOS);
        }

        // PUT: api/MA_PAGOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_PAGOS(string id, MA_PAGOS mA_PAGOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_PAGOS.c_Caja)
            {
                return BadRequest();
            }

            db.Entry(mA_PAGOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_PAGOSExists(id))
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

        // POST: api/MA_PAGOS
        [ResponseType(typeof(MA_PAGOS))]
        public IHttpActionResult PostMA_PAGOS(MA_PAGOS mA_PAGOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_PAGOS.Add(mA_PAGOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_PAGOSExists(mA_PAGOS.c_Caja))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_PAGOS.c_Caja }, mA_PAGOS);
        }

        // DELETE: api/MA_PAGOS/5
        [ResponseType(typeof(MA_PAGOS))]
        public IHttpActionResult DeleteMA_PAGOS(string id)
        {
            MA_PAGOS mA_PAGOS = db.MA_PAGOS.Find(id);
            if (mA_PAGOS == null)
            {
                return NotFound();
            }

            db.MA_PAGOS.Remove(mA_PAGOS);
            db.SaveChanges();

            return Ok(mA_PAGOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_PAGOSExists(string id)
        {
            return db.MA_PAGOS.Count(e => e.c_Caja == id) > 0;
        }
    }
}