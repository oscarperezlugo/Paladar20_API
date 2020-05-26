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
    public class MA_CODIGOSController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_CODIGOS
        public IQueryable<MA_CODIGOS> GetMA_CODIGOS()
        {
            return db.MA_CODIGOS;
        }

        // GET: api/MA_CODIGOS/5
        [ResponseType(typeof(MA_CODIGOS))]
        public IHttpActionResult GetMA_CODIGOS(string id)
        {
            MA_CODIGOS mA_CODIGOS = db.MA_CODIGOS.Find(id);
            if (mA_CODIGOS == null)
            {
                return NotFound();
            }

            return Ok(mA_CODIGOS);
        }

        // PUT: api/MA_CODIGOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_CODIGOS(string id, MA_CODIGOS mA_CODIGOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_CODIGOS.c_CodNasa)
            {
                return BadRequest();
            }

            db.Entry(mA_CODIGOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_CODIGOSExists(id))
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

        // POST: api/MA_CODIGOS
        [ResponseType(typeof(MA_CODIGOS))]
        public IHttpActionResult PostMA_CODIGOS(MA_CODIGOS mA_CODIGOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_CODIGOS.Add(mA_CODIGOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_CODIGOSExists(mA_CODIGOS.c_CodNasa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_CODIGOS.c_CodNasa }, mA_CODIGOS);
        }

        // DELETE: api/MA_CODIGOS/5
        [ResponseType(typeof(MA_CODIGOS))]
        public IHttpActionResult DeleteMA_CODIGOS(string id)
        {
            MA_CODIGOS mA_CODIGOS = db.MA_CODIGOS.Find(id);
            if (mA_CODIGOS == null)
            {
                return NotFound();
            }

            db.MA_CODIGOS.Remove(mA_CODIGOS);
            db.SaveChanges();

            return Ok(mA_CODIGOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_CODIGOSExists(string id)
        {
            return db.MA_CODIGOS.Count(e => e.c_CodNasa == id) > 0;
        }
    }
}