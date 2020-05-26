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
    public class MA_ACTUALIZACION_INVENTARIO_PENDIENTEController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_ACTUALIZACION_INVENTARIO_PENDIENTE
        public IQueryable<MA_ACTUALIZACION_INVENTARIO_PENDIENTE> GetMA_ACTUALIZACION_INVENTARIO_PENDIENTE()
        {
            return db.MA_ACTUALIZACION_INVENTARIO_PENDIENTE;
        }

        // GET: api/MA_ACTUALIZACION_INVENTARIO_PENDIENTE/5
        [ResponseType(typeof(MA_ACTUALIZACION_INVENTARIO_PENDIENTE))]
        public IHttpActionResult GetMA_ACTUALIZACION_INVENTARIO_PENDIENTE(string id)
        {
            MA_ACTUALIZACION_INVENTARIO_PENDIENTE mA_ACTUALIZACION_INVENTARIO_PENDIENTE = db.MA_ACTUALIZACION_INVENTARIO_PENDIENTE.Find(id);
            if (mA_ACTUALIZACION_INVENTARIO_PENDIENTE == null)
            {
                return NotFound();
            }

            return Ok(mA_ACTUALIZACION_INVENTARIO_PENDIENTE);
        }

        // PUT: api/MA_ACTUALIZACION_INVENTARIO_PENDIENTE/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_ACTUALIZACION_INVENTARIO_PENDIENTE(string id, MA_ACTUALIZACION_INVENTARIO_PENDIENTE mA_ACTUALIZACION_INVENTARIO_PENDIENTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_ACTUALIZACION_INVENTARIO_PENDIENTE.cs_codcaja)
            {
                return BadRequest();
            }

            db.Entry(mA_ACTUALIZACION_INVENTARIO_PENDIENTE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_ACTUALIZACION_INVENTARIO_PENDIENTEExists(id))
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

        // POST: api/MA_ACTUALIZACION_INVENTARIO_PENDIENTE
        [ResponseType(typeof(MA_ACTUALIZACION_INVENTARIO_PENDIENTE))]
        public IHttpActionResult PostMA_ACTUALIZACION_INVENTARIO_PENDIENTE(MA_ACTUALIZACION_INVENTARIO_PENDIENTE mA_ACTUALIZACION_INVENTARIO_PENDIENTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_ACTUALIZACION_INVENTARIO_PENDIENTE.Add(mA_ACTUALIZACION_INVENTARIO_PENDIENTE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_ACTUALIZACION_INVENTARIO_PENDIENTEExists(mA_ACTUALIZACION_INVENTARIO_PENDIENTE.cs_codcaja))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_ACTUALIZACION_INVENTARIO_PENDIENTE.cs_codcaja }, mA_ACTUALIZACION_INVENTARIO_PENDIENTE);
        }

        // DELETE: api/MA_ACTUALIZACION_INVENTARIO_PENDIENTE/5
        [ResponseType(typeof(MA_ACTUALIZACION_INVENTARIO_PENDIENTE))]
        public IHttpActionResult DeleteMA_ACTUALIZACION_INVENTARIO_PENDIENTE(string id)
        {
            MA_ACTUALIZACION_INVENTARIO_PENDIENTE mA_ACTUALIZACION_INVENTARIO_PENDIENTE = db.MA_ACTUALIZACION_INVENTARIO_PENDIENTE.Find(id);
            if (mA_ACTUALIZACION_INVENTARIO_PENDIENTE == null)
            {
                return NotFound();
            }

            db.MA_ACTUALIZACION_INVENTARIO_PENDIENTE.Remove(mA_ACTUALIZACION_INVENTARIO_PENDIENTE);
            db.SaveChanges();

            return Ok(mA_ACTUALIZACION_INVENTARIO_PENDIENTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_ACTUALIZACION_INVENTARIO_PENDIENTEExists(string id)
        {
            return db.MA_ACTUALIZACION_INVENTARIO_PENDIENTE.Count(e => e.cs_codcaja == id) > 0;
        }
    }
}