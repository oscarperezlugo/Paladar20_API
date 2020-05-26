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
    public class MA_DISPOSITIVOSController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_DISPOSITIVOS
        public IQueryable<MA_DISPOSITIVOS> GetMA_DISPOSITIVOS()
        {
            return db.MA_DISPOSITIVOS;
        }

        // GET: api/MA_DISPOSITIVOS/5
        [ResponseType(typeof(MA_DISPOSITIVOS))]
        public IHttpActionResult GetMA_DISPOSITIVOS(string id)
        {
            MA_DISPOSITIVOS mA_DISPOSITIVOS = db.MA_DISPOSITIVOS.Find(id);
            if (mA_DISPOSITIVOS == null)
            {
                return NotFound();
            }

            return Ok(mA_DISPOSITIVOS);
        }

        // PUT: api/MA_DISPOSITIVOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_DISPOSITIVOS(string id, MA_DISPOSITIVOS mA_DISPOSITIVOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_DISPOSITIVOS.cs_CODIGO)
            {
                return BadRequest();
            }

            db.Entry(mA_DISPOSITIVOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_DISPOSITIVOSExists(id))
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

        // POST: api/MA_DISPOSITIVOS
        [ResponseType(typeof(MA_DISPOSITIVOS))]
        public IHttpActionResult PostMA_DISPOSITIVOS(MA_DISPOSITIVOS mA_DISPOSITIVOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_DISPOSITIVOS.Add(mA_DISPOSITIVOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_DISPOSITIVOSExists(mA_DISPOSITIVOS.cs_CODIGO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_DISPOSITIVOS.cs_CODIGO }, mA_DISPOSITIVOS);
        }

        // DELETE: api/MA_DISPOSITIVOS/5
        [ResponseType(typeof(MA_DISPOSITIVOS))]
        public IHttpActionResult DeleteMA_DISPOSITIVOS(string id)
        {
            MA_DISPOSITIVOS mA_DISPOSITIVOS = db.MA_DISPOSITIVOS.Find(id);
            if (mA_DISPOSITIVOS == null)
            {
                return NotFound();
            }

            db.MA_DISPOSITIVOS.Remove(mA_DISPOSITIVOS);
            db.SaveChanges();

            return Ok(mA_DISPOSITIVOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_DISPOSITIVOSExists(string id)
        {
            return db.MA_DISPOSITIVOS.Count(e => e.cs_CODIGO == id) > 0;
        }
    }
}