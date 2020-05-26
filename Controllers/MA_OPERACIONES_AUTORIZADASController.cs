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
    public class MA_OPERACIONES_AUTORIZADASController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_OPERACIONES_AUTORIZADAS
        public IQueryable<MA_OPERACIONES_AUTORIZADAS> GetMA_OPERACIONES_AUTORIZADAS()
        {
            return db.MA_OPERACIONES_AUTORIZADAS;
        }

        // GET: api/MA_OPERACIONES_AUTORIZADAS/5
        [ResponseType(typeof(MA_OPERACIONES_AUTORIZADAS))]
        public IHttpActionResult GetMA_OPERACIONES_AUTORIZADAS(string id)
        {
            MA_OPERACIONES_AUTORIZADAS mA_OPERACIONES_AUTORIZADAS = db.MA_OPERACIONES_AUTORIZADAS.Find(id);
            if (mA_OPERACIONES_AUTORIZADAS == null)
            {
                return NotFound();
            }

            return Ok(mA_OPERACIONES_AUTORIZADAS);
        }

        // PUT: api/MA_OPERACIONES_AUTORIZADAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_OPERACIONES_AUTORIZADAS(string id, MA_OPERACIONES_AUTORIZADAS mA_OPERACIONES_AUTORIZADAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_OPERACIONES_AUTORIZADAS.Codigo)
            {
                return BadRequest();
            }

            db.Entry(mA_OPERACIONES_AUTORIZADAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_OPERACIONES_AUTORIZADASExists(id))
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

        // POST: api/MA_OPERACIONES_AUTORIZADAS
        [ResponseType(typeof(MA_OPERACIONES_AUTORIZADAS))]
        public IHttpActionResult PostMA_OPERACIONES_AUTORIZADAS(MA_OPERACIONES_AUTORIZADAS mA_OPERACIONES_AUTORIZADAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_OPERACIONES_AUTORIZADAS.Add(mA_OPERACIONES_AUTORIZADAS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_OPERACIONES_AUTORIZADASExists(mA_OPERACIONES_AUTORIZADAS.Codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_OPERACIONES_AUTORIZADAS.Codigo }, mA_OPERACIONES_AUTORIZADAS);
        }

        // DELETE: api/MA_OPERACIONES_AUTORIZADAS/5
        [ResponseType(typeof(MA_OPERACIONES_AUTORIZADAS))]
        public IHttpActionResult DeleteMA_OPERACIONES_AUTORIZADAS(string id)
        {
            MA_OPERACIONES_AUTORIZADAS mA_OPERACIONES_AUTORIZADAS = db.MA_OPERACIONES_AUTORIZADAS.Find(id);
            if (mA_OPERACIONES_AUTORIZADAS == null)
            {
                return NotFound();
            }

            db.MA_OPERACIONES_AUTORIZADAS.Remove(mA_OPERACIONES_AUTORIZADAS);
            db.SaveChanges();

            return Ok(mA_OPERACIONES_AUTORIZADAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_OPERACIONES_AUTORIZADASExists(string id)
        {
            return db.MA_OPERACIONES_AUTORIZADAS.Count(e => e.Codigo == id) > 0;
        }
    }
}