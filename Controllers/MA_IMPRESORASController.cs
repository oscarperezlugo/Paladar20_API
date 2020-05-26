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
    public class MA_IMPRESORASController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_IMPRESORAS
        public IQueryable<MA_IMPRESORAS> GetMA_IMPRESORAS()
        {
            return db.MA_IMPRESORAS;
        }

        // GET: api/MA_IMPRESORAS/5
        [ResponseType(typeof(MA_IMPRESORAS))]
        public IHttpActionResult GetMA_IMPRESORAS(string id)
        {
            MA_IMPRESORAS mA_IMPRESORAS = db.MA_IMPRESORAS.Find(id);
            if (mA_IMPRESORAS == null)
            {
                return NotFound();
            }

            return Ok(mA_IMPRESORAS);
        }

        // PUT: api/MA_IMPRESORAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_IMPRESORAS(string id, MA_IMPRESORAS mA_IMPRESORAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_IMPRESORAS.cs_NUMERO)
            {
                return BadRequest();
            }

            db.Entry(mA_IMPRESORAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_IMPRESORASExists(id))
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

        // POST: api/MA_IMPRESORAS
        [ResponseType(typeof(MA_IMPRESORAS))]
        public IHttpActionResult PostMA_IMPRESORAS(MA_IMPRESORAS mA_IMPRESORAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_IMPRESORAS.Add(mA_IMPRESORAS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_IMPRESORASExists(mA_IMPRESORAS.cs_NUMERO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_IMPRESORAS.cs_NUMERO }, mA_IMPRESORAS);
        }

        // DELETE: api/MA_IMPRESORAS/5
        [ResponseType(typeof(MA_IMPRESORAS))]
        public IHttpActionResult DeleteMA_IMPRESORAS(string id)
        {
            MA_IMPRESORAS mA_IMPRESORAS = db.MA_IMPRESORAS.Find(id);
            if (mA_IMPRESORAS == null)
            {
                return NotFound();
            }

            db.MA_IMPRESORAS.Remove(mA_IMPRESORAS);
            db.SaveChanges();

            return Ok(mA_IMPRESORAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_IMPRESORASExists(string id)
        {
            return db.MA_IMPRESORAS.Count(e => e.cs_NUMERO == id) > 0;
        }
    }
}