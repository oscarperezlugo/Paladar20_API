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
    public class MA_CONCEPTOSController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_CONCEPTOS
        public IQueryable<MA_CONCEPTOS> GetMA_CONCEPTOS()
        {
            return db.MA_CONCEPTOS;
        }

        // GET: api/MA_CONCEPTOS/5
        [ResponseType(typeof(MA_CONCEPTOS))]
        public IHttpActionResult GetMA_CONCEPTOS(decimal id)
        {
            MA_CONCEPTOS mA_CONCEPTOS = db.MA_CONCEPTOS.Find(id);
            if (mA_CONCEPTOS == null)
            {
                return NotFound();
            }

            return Ok(mA_CONCEPTOS);
        }

        // PUT: api/MA_CONCEPTOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_CONCEPTOS(decimal id, MA_CONCEPTOS mA_CONCEPTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_CONCEPTOS.IDCONCEPTO)
            {
                return BadRequest();
            }

            db.Entry(mA_CONCEPTOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_CONCEPTOSExists(id))
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

        // POST: api/MA_CONCEPTOS
        [ResponseType(typeof(MA_CONCEPTOS))]
        public IHttpActionResult PostMA_CONCEPTOS(MA_CONCEPTOS mA_CONCEPTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_CONCEPTOS.Add(mA_CONCEPTOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_CONCEPTOSExists(mA_CONCEPTOS.IDCONCEPTO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_CONCEPTOS.IDCONCEPTO }, mA_CONCEPTOS);
        }

        // DELETE: api/MA_CONCEPTOS/5
        [ResponseType(typeof(MA_CONCEPTOS))]
        public IHttpActionResult DeleteMA_CONCEPTOS(decimal id)
        {
            MA_CONCEPTOS mA_CONCEPTOS = db.MA_CONCEPTOS.Find(id);
            if (mA_CONCEPTOS == null)
            {
                return NotFound();
            }

            db.MA_CONCEPTOS.Remove(mA_CONCEPTOS);
            db.SaveChanges();

            return Ok(mA_CONCEPTOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_CONCEPTOSExists(decimal id)
        {
            return db.MA_CONCEPTOS.Count(e => e.IDCONCEPTO == id) > 0;
        }
    }
}