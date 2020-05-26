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
    public class MA_DOCUMENTOS_FISCALController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_DOCUMENTOS_FISCAL
        public IQueryable<MA_DOCUMENTOS_FISCAL> GetMA_DOCUMENTOS_FISCAL()
        {
            return db.MA_DOCUMENTOS_FISCAL;
        }

        // GET: api/MA_DOCUMENTOS_FISCAL/5
        [ResponseType(typeof(MA_DOCUMENTOS_FISCAL))]
        public IHttpActionResult GetMA_DOCUMENTOS_FISCAL(string id)
        {
            MA_DOCUMENTOS_FISCAL mA_DOCUMENTOS_FISCAL = db.MA_DOCUMENTOS_FISCAL.Find(id);
            if (mA_DOCUMENTOS_FISCAL == null)
            {
                return NotFound();
            }

            return Ok(mA_DOCUMENTOS_FISCAL);
        }

        // PUT: api/MA_DOCUMENTOS_FISCAL/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_DOCUMENTOS_FISCAL(string id, MA_DOCUMENTOS_FISCAL mA_DOCUMENTOS_FISCAL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_DOCUMENTOS_FISCAL.cu_DocumentoStellar)
            {
                return BadRequest();
            }

            db.Entry(mA_DOCUMENTOS_FISCAL).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_DOCUMENTOS_FISCALExists(id))
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

        // POST: api/MA_DOCUMENTOS_FISCAL
        [ResponseType(typeof(MA_DOCUMENTOS_FISCAL))]
        public IHttpActionResult PostMA_DOCUMENTOS_FISCAL(MA_DOCUMENTOS_FISCAL mA_DOCUMENTOS_FISCAL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_DOCUMENTOS_FISCAL.Add(mA_DOCUMENTOS_FISCAL);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_DOCUMENTOS_FISCALExists(mA_DOCUMENTOS_FISCAL.cu_DocumentoStellar))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_DOCUMENTOS_FISCAL.cu_DocumentoStellar }, mA_DOCUMENTOS_FISCAL);
        }

        // DELETE: api/MA_DOCUMENTOS_FISCAL/5
        [ResponseType(typeof(MA_DOCUMENTOS_FISCAL))]
        public IHttpActionResult DeleteMA_DOCUMENTOS_FISCAL(string id)
        {
            MA_DOCUMENTOS_FISCAL mA_DOCUMENTOS_FISCAL = db.MA_DOCUMENTOS_FISCAL.Find(id);
            if (mA_DOCUMENTOS_FISCAL == null)
            {
                return NotFound();
            }

            db.MA_DOCUMENTOS_FISCAL.Remove(mA_DOCUMENTOS_FISCAL);
            db.SaveChanges();

            return Ok(mA_DOCUMENTOS_FISCAL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_DOCUMENTOS_FISCALExists(string id)
        {
            return db.MA_DOCUMENTOS_FISCAL.Count(e => e.cu_DocumentoStellar == id) > 0;
        }
    }
}