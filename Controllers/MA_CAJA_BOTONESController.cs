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
    public class MA_CAJA_BOTONESController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_CAJA_BOTONES
        public IQueryable<MA_CAJA_BOTONES> GetMA_CAJA_BOTONES()
        {
            return db.MA_CAJA_BOTONES;
        }

        // GET: api/MA_CAJA_BOTONES/5
        [ResponseType(typeof(MA_CAJA_BOTONES))]
        public IHttpActionResult GetMA_CAJA_BOTONES(decimal id)
        {
            MA_CAJA_BOTONES mA_CAJA_BOTONES = db.MA_CAJA_BOTONES.Find(id);
            if (mA_CAJA_BOTONES == null)
            {
                return NotFound();
            }

            return Ok(mA_CAJA_BOTONES);
        }

        // PUT: api/MA_CAJA_BOTONES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_CAJA_BOTONES(decimal id, MA_CAJA_BOTONES mA_CAJA_BOTONES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_CAJA_BOTONES.ID)
            {
                return BadRequest();
            }

            db.Entry(mA_CAJA_BOTONES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_CAJA_BOTONESExists(id))
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

        // POST: api/MA_CAJA_BOTONES
        [ResponseType(typeof(MA_CAJA_BOTONES))]
        public IHttpActionResult PostMA_CAJA_BOTONES(MA_CAJA_BOTONES mA_CAJA_BOTONES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_CAJA_BOTONES.Add(mA_CAJA_BOTONES);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mA_CAJA_BOTONES.ID }, mA_CAJA_BOTONES);
        }

        // DELETE: api/MA_CAJA_BOTONES/5
        [ResponseType(typeof(MA_CAJA_BOTONES))]
        public IHttpActionResult DeleteMA_CAJA_BOTONES(decimal id)
        {
            MA_CAJA_BOTONES mA_CAJA_BOTONES = db.MA_CAJA_BOTONES.Find(id);
            if (mA_CAJA_BOTONES == null)
            {
                return NotFound();
            }

            db.MA_CAJA_BOTONES.Remove(mA_CAJA_BOTONES);
            db.SaveChanges();

            return Ok(mA_CAJA_BOTONES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_CAJA_BOTONESExists(decimal id)
        {
            return db.MA_CAJA_BOTONES.Count(e => e.ID == id) > 0;
        }
    }
}