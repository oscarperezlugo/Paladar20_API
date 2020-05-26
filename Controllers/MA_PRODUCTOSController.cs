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
    public class MA_PRODUCTOSController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_PRODUCTOS
        public IQueryable<MA_PRODUCTOS> GetMA_PRODUCTOS()
        {
            return db.MA_PRODUCTOS;
        }

        // GET: api/MA_PRODUCTOS/5
        [ResponseType(typeof(MA_PRODUCTOS))]
        public IHttpActionResult GetMA_PRODUCTOS(string id)
        {
            MA_PRODUCTOS mA_PRODUCTOS = db.MA_PRODUCTOS.Find(id);
            if (mA_PRODUCTOS == null)
            {
                return NotFound();
            }

            return Ok(mA_PRODUCTOS);
        }

        // PUT: api/MA_PRODUCTOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_PRODUCTOS(string id, MA_PRODUCTOS mA_PRODUCTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_PRODUCTOS.c_Codigo)
            {
                return BadRequest();
            }

            db.Entry(mA_PRODUCTOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_PRODUCTOSExists(id))
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

        // POST: api/MA_PRODUCTOS
        [ResponseType(typeof(MA_PRODUCTOS))]
        public IHttpActionResult PostMA_PRODUCTOS(MA_PRODUCTOS mA_PRODUCTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_PRODUCTOS.Add(mA_PRODUCTOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_PRODUCTOSExists(mA_PRODUCTOS.c_Codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_PRODUCTOS.c_Codigo }, mA_PRODUCTOS);
        }

        // DELETE: api/MA_PRODUCTOS/5
        [ResponseType(typeof(MA_PRODUCTOS))]
        public IHttpActionResult DeleteMA_PRODUCTOS(string id)
        {
            MA_PRODUCTOS mA_PRODUCTOS = db.MA_PRODUCTOS.Find(id);
            if (mA_PRODUCTOS == null)
            {
                return NotFound();
            }

            db.MA_PRODUCTOS.Remove(mA_PRODUCTOS);
            db.SaveChanges();

            return Ok(mA_PRODUCTOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_PRODUCTOSExists(string id)
        {
            return db.MA_PRODUCTOS.Count(e => e.c_Codigo == id) > 0;
        }
    }
}