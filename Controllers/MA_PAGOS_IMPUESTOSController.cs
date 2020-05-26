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
    public class MA_PAGOS_IMPUESTOSController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_PAGOS_IMPUESTOS
        public IQueryable<MA_PAGOS_IMPUESTOS> GetMA_PAGOS_IMPUESTOS()
        {
            return db.MA_PAGOS_IMPUESTOS;
        }

        // GET: api/MA_PAGOS_IMPUESTOS/5
        [ResponseType(typeof(MA_PAGOS_IMPUESTOS))]
        public IHttpActionResult GetMA_PAGOS_IMPUESTOS(string id)
        {
            MA_PAGOS_IMPUESTOS mA_PAGOS_IMPUESTOS = db.MA_PAGOS_IMPUESTOS.Find(id);
            if (mA_PAGOS_IMPUESTOS == null)
            {
                return NotFound();
            }

            return Ok(mA_PAGOS_IMPUESTOS);
        }

        // PUT: api/MA_PAGOS_IMPUESTOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_PAGOS_IMPUESTOS(string id, MA_PAGOS_IMPUESTOS mA_PAGOS_IMPUESTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_PAGOS_IMPUESTOS.c_Numero)
            {
                return BadRequest();
            }

            db.Entry(mA_PAGOS_IMPUESTOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_PAGOS_IMPUESTOSExists(id))
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

        // POST: api/MA_PAGOS_IMPUESTOS
        [ResponseType(typeof(MA_PAGOS_IMPUESTOS))]
        public IHttpActionResult PostMA_PAGOS_IMPUESTOS(MA_PAGOS_IMPUESTOS mA_PAGOS_IMPUESTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_PAGOS_IMPUESTOS.Add(mA_PAGOS_IMPUESTOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_PAGOS_IMPUESTOSExists(mA_PAGOS_IMPUESTOS.c_Numero))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_PAGOS_IMPUESTOS.c_Numero }, mA_PAGOS_IMPUESTOS);
        }

        // DELETE: api/MA_PAGOS_IMPUESTOS/5
        [ResponseType(typeof(MA_PAGOS_IMPUESTOS))]
        public IHttpActionResult DeleteMA_PAGOS_IMPUESTOS(string id)
        {
            MA_PAGOS_IMPUESTOS mA_PAGOS_IMPUESTOS = db.MA_PAGOS_IMPUESTOS.Find(id);
            if (mA_PAGOS_IMPUESTOS == null)
            {
                return NotFound();
            }

            db.MA_PAGOS_IMPUESTOS.Remove(mA_PAGOS_IMPUESTOS);
            db.SaveChanges();

            return Ok(mA_PAGOS_IMPUESTOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_PAGOS_IMPUESTOSExists(string id)
        {
            return db.MA_PAGOS_IMPUESTOS.Count(e => e.c_Numero == id) > 0;
        }
    }
}