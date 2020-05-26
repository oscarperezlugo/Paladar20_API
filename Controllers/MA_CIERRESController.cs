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
    public class MA_CIERRESController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_CIERRES
        public IQueryable<MA_CIERRES> GetMA_CIERRES()
        {
            return db.MA_CIERRES;
        }

        // GET: api/MA_CIERRES/5
        [ResponseType(typeof(MA_CIERRES))]
        public IHttpActionResult GetMA_CIERRES(string id)
        {
            MA_CIERRES mA_CIERRES = db.MA_CIERRES.Find(id);
            if (mA_CIERRES == null)
            {
                return NotFound();
            }

            return Ok(mA_CIERRES);
        }

        // PUT: api/MA_CIERRES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_CIERRES(string id, MA_CIERRES mA_CIERRES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_CIERRES.c_DOCUMENTO)
            {
                return BadRequest();
            }

            db.Entry(mA_CIERRES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_CIERRESExists(id))
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

        // POST: api/MA_CIERRES
        [ResponseType(typeof(MA_CIERRES))]
        public IHttpActionResult PostMA_CIERRES(MA_CIERRES mA_CIERRES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_CIERRES.Add(mA_CIERRES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_CIERRESExists(mA_CIERRES.c_DOCUMENTO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_CIERRES.c_DOCUMENTO }, mA_CIERRES);
        }

        // DELETE: api/MA_CIERRES/5
        [ResponseType(typeof(MA_CIERRES))]
        public IHttpActionResult DeleteMA_CIERRES(string id)
        {
            MA_CIERRES mA_CIERRES = db.MA_CIERRES.Find(id);
            if (mA_CIERRES == null)
            {
                return NotFound();
            }

            db.MA_CIERRES.Remove(mA_CIERRES);
            db.SaveChanges();

            return Ok(mA_CIERRES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_CIERRESExists(string id)
        {
            return db.MA_CIERRES.Count(e => e.c_DOCUMENTO == id) > 0;
        }
    }
}