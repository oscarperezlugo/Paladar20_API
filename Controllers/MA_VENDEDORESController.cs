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
    public class MA_VENDEDORESController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_VENDEDORES
        public IQueryable<MA_VENDEDORES> GetMA_VENDEDORES()
        {
            return db.MA_VENDEDORES;
        }

        // GET: api/MA_VENDEDORES/5
        [ResponseType(typeof(MA_VENDEDORES))]
        public IHttpActionResult GetMA_VENDEDORES(string id)
        {
            MA_VENDEDORES mA_VENDEDORES = db.MA_VENDEDORES.Find(id);
            if (mA_VENDEDORES == null)
            {
                return NotFound();
            }

            return Ok(mA_VENDEDORES);
        }

        // PUT: api/MA_VENDEDORES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_VENDEDORES(string id, MA_VENDEDORES mA_VENDEDORES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_VENDEDORES.CU_VENDEDOR_COD)
            {
                return BadRequest();
            }

            db.Entry(mA_VENDEDORES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_VENDEDORESExists(id))
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

        // POST: api/MA_VENDEDORES
        [ResponseType(typeof(MA_VENDEDORES))]
        public IHttpActionResult PostMA_VENDEDORES(MA_VENDEDORES mA_VENDEDORES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_VENDEDORES.Add(mA_VENDEDORES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_VENDEDORESExists(mA_VENDEDORES.CU_VENDEDOR_COD))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_VENDEDORES.CU_VENDEDOR_COD }, mA_VENDEDORES);
        }

        // DELETE: api/MA_VENDEDORES/5
        [ResponseType(typeof(MA_VENDEDORES))]
        public IHttpActionResult DeleteMA_VENDEDORES(string id)
        {
            MA_VENDEDORES mA_VENDEDORES = db.MA_VENDEDORES.Find(id);
            if (mA_VENDEDORES == null)
            {
                return NotFound();
            }

            db.MA_VENDEDORES.Remove(mA_VENDEDORES);
            db.SaveChanges();

            return Ok(mA_VENDEDORES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_VENDEDORESExists(string id)
        {
            return db.MA_VENDEDORES.Count(e => e.CU_VENDEDOR_COD == id) > 0;
        }
    }
}