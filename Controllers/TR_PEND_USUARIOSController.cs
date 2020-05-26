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
    public class TR_PEND_USUARIOSController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/TR_PEND_USUARIOS
        public IQueryable<TR_PEND_USUARIOS> GetTR_PEND_USUARIOS()
        {
            return db.TR_PEND_USUARIOS;
        }

        // GET: api/TR_PEND_USUARIOS/5
        [ResponseType(typeof(TR_PEND_USUARIOS))]
        public IHttpActionResult GetTR_PEND_USUARIOS(string id)
        {
            TR_PEND_USUARIOS tR_PEND_USUARIOS = db.TR_PEND_USUARIOS.Find(id);
            if (tR_PEND_USUARIOS == null)
            {
                return NotFound();
            }

            return Ok(tR_PEND_USUARIOS);
        }

        // PUT: api/TR_PEND_USUARIOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTR_PEND_USUARIOS(string id, TR_PEND_USUARIOS tR_PEND_USUARIOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tR_PEND_USUARIOS.CODUSUARIO)
            {
                return BadRequest();
            }

            db.Entry(tR_PEND_USUARIOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR_PEND_USUARIOSExists(id))
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

        // POST: api/TR_PEND_USUARIOS
        [ResponseType(typeof(TR_PEND_USUARIOS))]
        public IHttpActionResult PostTR_PEND_USUARIOS(TR_PEND_USUARIOS tR_PEND_USUARIOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TR_PEND_USUARIOS.Add(tR_PEND_USUARIOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TR_PEND_USUARIOSExists(tR_PEND_USUARIOS.CODUSUARIO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tR_PEND_USUARIOS.CODUSUARIO }, tR_PEND_USUARIOS);
        }

        // DELETE: api/TR_PEND_USUARIOS/5
        [ResponseType(typeof(TR_PEND_USUARIOS))]
        public IHttpActionResult DeleteTR_PEND_USUARIOS(string id)
        {
            TR_PEND_USUARIOS tR_PEND_USUARIOS = db.TR_PEND_USUARIOS.Find(id);
            if (tR_PEND_USUARIOS == null)
            {
                return NotFound();
            }

            db.TR_PEND_USUARIOS.Remove(tR_PEND_USUARIOS);
            db.SaveChanges();

            return Ok(tR_PEND_USUARIOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TR_PEND_USUARIOSExists(string id)
        {
            return db.TR_PEND_USUARIOS.Count(e => e.CODUSUARIO == id) > 0;
        }
    }
}