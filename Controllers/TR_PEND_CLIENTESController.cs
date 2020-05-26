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
    public class TR_PEND_CLIENTESController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/TR_PEND_CLIENTES
        public IQueryable<TR_PEND_CLIENTES> GetTR_PEND_CLIENTES()
        {
            return db.TR_PEND_CLIENTES;
        }

        // GET: api/TR_PEND_CLIENTES/5
        [ResponseType(typeof(TR_PEND_CLIENTES))]
        public IHttpActionResult GetTR_PEND_CLIENTES(string id)
        {
            TR_PEND_CLIENTES tR_PEND_CLIENTES = db.TR_PEND_CLIENTES.Find(id);
            if (tR_PEND_CLIENTES == null)
            {
                return NotFound();
            }

            return Ok(tR_PEND_CLIENTES);
        }

        // PUT: api/TR_PEND_CLIENTES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_PEND_CLIENTES(string id, TR_PEND_CLIENTES tR_PEND_CLIENTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_PEND_CLIENTES.c_CODCLIENTE)
            {
                return BadRequest();
            }

            db.Entry(tR_PEND_CLIENTES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_PEND_CLIENTESExists(id))
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

        // POST: api/TR_PEND_CLIENTES
        [ResponseType(typeof(TR_PEND_CLIENTES))]
        public IHttpActionResult PostTR_PEND_CLIENTES(TR_PEND_CLIENTES tR_PEND_CLIENTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_PEND_CLIENTES.Add(tR_PEND_CLIENTES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_PEND_CLIENTESExists(tR_PEND_CLIENTES.c_CODCLIENTE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_PEND_CLIENTES.c_CODCLIENTE }, tR_PEND_CLIENTES);
        }

        // DELETE: api/TR_PEND_CLIENTES/5
        [ResponseType(typeof(TR_PEND_CLIENTES))]
        public IHttpActionResult DeleteTR_PEND_CLIENTES(string id)
        {
            TR_PEND_CLIENTES tR_PEND_CLIENTES = db.TR_PEND_CLIENTES.Find(id);
            if (tR_PEND_CLIENTES == null)
            {
                return NotFound();
            }

            db.TR_PEND_CLIENTES.Remove(tR_PEND_CLIENTES);
            db.SaveChanges();

            return Ok(tR_PEND_CLIENTES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_PEND_CLIENTESExists(string id)
        {
            return db.TR_PEND_CLIENTES.Count(e => e.c_CODCLIENTE == id) > 0;
        }
    }
}