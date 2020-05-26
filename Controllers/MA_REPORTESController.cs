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
    public class MA_REPORTESController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_REPORTES
        public IQueryable<MA_REPORTES> GetMA_REPORTES()
        {
            return db.MA_REPORTES;
        }

        // GET: api/MA_REPORTES/5
        [ResponseType(typeof(MA_REPORTES))]
        public IHttpActionResult GetMA_REPORTES(string id)
        {
            MA_REPORTES mA_REPORTES = db.MA_REPORTES.Find(id);
            if (mA_REPORTES == null)
            {
                return NotFound();
            }

            return Ok(mA_REPORTES);
        }

        // PUT: api/MA_REPORTES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_REPORTES(string id, MA_REPORTES mA_REPORTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_REPORTES.cs_CODIGO_REPORTE)
            {
                return BadRequest();
            }

            db.Entry(mA_REPORTES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_REPORTESExists(id))
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

        // POST: api/MA_REPORTES
        [ResponseType(typeof(MA_REPORTES))]
        public IHttpActionResult PostMA_REPORTES(MA_REPORTES mA_REPORTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_REPORTES.Add(mA_REPORTES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_REPORTESExists(mA_REPORTES.cs_CODIGO_REPORTE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_REPORTES.cs_CODIGO_REPORTE }, mA_REPORTES);
        }

        // DELETE: api/MA_REPORTES/5
        [ResponseType(typeof(MA_REPORTES))]
        public IHttpActionResult DeleteMA_REPORTES(string id)
        {
            MA_REPORTES mA_REPORTES = db.MA_REPORTES.Find(id);
            if (mA_REPORTES == null)
            {
                return NotFound();
            }

            db.MA_REPORTES.Remove(mA_REPORTES);
            db.SaveChanges();

            return Ok(mA_REPORTES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_REPORTESExists(string id)
        {
            return db.MA_REPORTES.Count(e => e.cs_CODIGO_REPORTE == id) > 0;
        }
    }
}