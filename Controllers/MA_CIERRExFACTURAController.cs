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
    public class MA_CIERRExFACTURAController : ApiController
    {
        private VAD20Entities db = new VAD20Entities();

        // GET: api/MA_CIERRExFACTURA
        public IQueryable<MA_CIERRExFACTURA> GetMA_CIERRExFACTURA()
        {
            return db.MA_CIERRExFACTURA;
        }

        // GET: api/MA_CIERRExFACTURA/5
        [ResponseType(typeof(MA_CIERRExFACTURA))]
        public IHttpActionResult GetMA_CIERRExFACTURA(string id)
        {
            MA_CIERRExFACTURA mA_CIERRExFACTURA = db.MA_CIERRExFACTURA.Find(id);
            if (mA_CIERRExFACTURA == null)
            {
                return NotFound();
            }

            return Ok(mA_CIERRExFACTURA);
        }

        // PUT: api/MA_CIERRExFACTURA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMA_CIERRExFACTURA(string id, MA_CIERRExFACTURA mA_CIERRExFACTURA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mA_CIERRExFACTURA.CU_CODCAJA)
            {
                return BadRequest();
            }

            db.Entry(mA_CIERRExFACTURA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MA_CIERRExFACTURAExists(id))
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

        // POST: api/MA_CIERRExFACTURA
        [ResponseType(typeof(MA_CIERRExFACTURA))]
        public IHttpActionResult PostMA_CIERRExFACTURA(MA_CIERRExFACTURA mA_CIERRExFACTURA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MA_CIERRExFACTURA.Add(mA_CIERRExFACTURA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MA_CIERRExFACTURAExists(mA_CIERRExFACTURA.CU_CODCAJA))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mA_CIERRExFACTURA.CU_CODCAJA }, mA_CIERRExFACTURA);
        }

        // DELETE: api/MA_CIERRExFACTURA/5
        [ResponseType(typeof(MA_CIERRExFACTURA))]
        public IHttpActionResult DeleteMA_CIERRExFACTURA(string id)
        {
            MA_CIERRExFACTURA mA_CIERRExFACTURA = db.MA_CIERRExFACTURA.Find(id);
            if (mA_CIERRExFACTURA == null)
            {
                return NotFound();
            }

            db.MA_CIERRExFACTURA.Remove(mA_CIERRExFACTURA);
            db.SaveChanges();

            return Ok(mA_CIERRExFACTURA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MA_CIERRExFACTURAExists(string id)
        {
            return db.MA_CIERRExFACTURA.Count(e => e.CU_CODCAJA == id) > 0;
        }
    }
}