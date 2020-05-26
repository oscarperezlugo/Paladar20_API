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
    public class MA_ETIQUETASController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_ETIQUETAS
        public IQueryable<MA_ETIQUETAS> GetMA_ETIQUETAS()
        {
            return db.MA_ETIQUETAS;
        }

        // GET: api/MA_ETIQUETAS/5
        [ResponseType(typeof(MA_ETIQUETAS))]
        public IHttpActionResult GetMA_ETIQUETAS(string id)
        {
            MA_ETIQUETAS mA_ETIQUETAS = db.MA_ETIQUETAS.Find(id);
            if (mA_ETIQUETAS == null)
            {
                return NotFound();
            }

            return Ok(mA_ETIQUETAS);
        }

        // PUT: api/MA_ETIQUETAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_ETIQUETAS(string id, MA_ETIQUETAS mA_ETIQUETAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_ETIQUETAS.C_CODIGO)
            {
                return BadRequest();
            }

            db.Entry(mA_ETIQUETAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_ETIQUETASExists(id))
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

        // POST: api/MA_ETIQUETAS
        [ResponseType(typeof(MA_ETIQUETAS))]
        public IHttpActionResult PostMA_ETIQUETAS(MA_ETIQUETAS mA_ETIQUETAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_ETIQUETAS.Add(mA_ETIQUETAS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_ETIQUETASExists(mA_ETIQUETAS.C_CODIGO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_ETIQUETAS.C_CODIGO }, mA_ETIQUETAS);
        }

        // DELETE: api/MA_ETIQUETAS/5
        [ResponseType(typeof(MA_ETIQUETAS))]
        public IHttpActionResult DeleteMA_ETIQUETAS(string id)
        {
            MA_ETIQUETAS mA_ETIQUETAS = db.MA_ETIQUETAS.Find(id);
            if (mA_ETIQUETAS == null)
            {
                return NotFound();
            }

            db.MA_ETIQUETAS.Remove(mA_ETIQUETAS);
            db.SaveChanges();

            return Ok(mA_ETIQUETAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_ETIQUETASExists(string id)
        {
            return db.MA_ETIQUETAS.Count(e => e.C_CODIGO == id) > 0;
        }
    }
}