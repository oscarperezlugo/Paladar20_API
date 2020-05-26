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
    public class MA_DENOMINACIONESController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_DENOMINACIONES
        public IQueryable<MA_DENOMINACIONES> GetMA_DENOMINACIONES()
        {
            return db.MA_DENOMINACIONES;
        }

        // GET: api/MA_DENOMINACIONES/5
        [ResponseType(typeof(MA_DENOMINACIONES))]
        public IHttpActionResult GetMA_DENOMINACIONES(string id)
        {
            MA_DENOMINACIONES mA_DENOMINACIONES = db.MA_DENOMINACIONES.Find(id);
            if (mA_DENOMINACIONES == null)
            {
                return NotFound();
            }

            return Ok(mA_DENOMINACIONES);
        }

        // PUT: api/MA_DENOMINACIONES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_DENOMINACIONES(string id, MA_DENOMINACIONES mA_DENOMINACIONES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_DENOMINACIONES.c_codmoneda)
            {
                return BadRequest();
            }

            db.Entry(mA_DENOMINACIONES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_DENOMINACIONESExists(id))
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

        // POST: api/MA_DENOMINACIONES
        [ResponseType(typeof(MA_DENOMINACIONES))]
        public IHttpActionResult PostMA_DENOMINACIONES(MA_DENOMINACIONES mA_DENOMINACIONES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_DENOMINACIONES.Add(mA_DENOMINACIONES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_DENOMINACIONESExists(mA_DENOMINACIONES.c_codmoneda))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_DENOMINACIONES.c_codmoneda }, mA_DENOMINACIONES);
        }

        // DELETE: api/MA_DENOMINACIONES/5
        [ResponseType(typeof(MA_DENOMINACIONES))]
        public IHttpActionResult DeleteMA_DENOMINACIONES(string id)
        {
            MA_DENOMINACIONES mA_DENOMINACIONES = db.MA_DENOMINACIONES.Find(id);
            if (mA_DENOMINACIONES == null)
            {
                return NotFound();
            }

            db.MA_DENOMINACIONES.Remove(mA_DENOMINACIONES);
            db.SaveChanges();

            return Ok(mA_DENOMINACIONES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_DENOMINACIONESExists(string id)
        {
            return db.MA_DENOMINACIONES.Count(e => e.c_codmoneda == id) > 0;
        }
    }
}