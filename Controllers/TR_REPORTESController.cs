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
    public class TR_REPORTESController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/TR_REPORTES
        public IQueryable<TR_REPORTES> GetTR_REPORTES()
        {
            return db.TR_REPORTES;
        }

        // GET: api/TR_REPORTES/5
        [ResponseType(typeof(TR_REPORTES))]
        public IHttpActionResult GetTR_REPORTES(string id)
        {
            TR_REPORTES tR_REPORTES = db.TR_REPORTES.Find(id);
            if (tR_REPORTES == null)
            {
                return NotFound();
            }

            return Ok(tR_REPORTES);
        }

        // PUT: api/TR_REPORTES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_REPORTES(string id, TR_REPORTES tR_REPORTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_REPORTES.cs_CODIGO_REPORTE)
            {
                return BadRequest();
            }

            db.Entry(tR_REPORTES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_REPORTESExists(id))
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

        // POST: api/TR_REPORTES
        [ResponseType(typeof(TR_REPORTES))]
        public IHttpActionResult PostTR_REPORTES(TR_REPORTES tR_REPORTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_REPORTES.Add(tR_REPORTES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_REPORTESExists(tR_REPORTES.cs_CODIGO_REPORTE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_REPORTES.cs_CODIGO_REPORTE }, tR_REPORTES);
        }

        // DELETE: api/TR_REPORTES/5
        [ResponseType(typeof(TR_REPORTES))]
        public IHttpActionResult DeleteTR_REPORTES(string id)
        {
            TR_REPORTES tR_REPORTES = db.TR_REPORTES.Find(id);
            if (tR_REPORTES == null)
            {
                return NotFound();
            }

            db.TR_REPORTES.Remove(tR_REPORTES);
            db.SaveChanges();

            return Ok(tR_REPORTES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_REPORTESExists(string id)
        {
            return db.TR_REPORTES.Count(e => e.cs_CODIGO_REPORTE == id) > 0;
        }
    }
}