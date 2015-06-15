using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using xmr.cs.Models;

namespace xmr.cs.Controllers
{
    public class TagLinksController : ApiController
    {
        private XmrContext db = new XmrContext();

        // GET: api/TagLinks
        public IQueryable<TagLink> GetTagLinks()
        {
            return db.TagLinks;
        }

        // GET: api/TagLinks/5
        [ResponseType(typeof(TagLink))]
        public async Task<IHttpActionResult> GetTagLink(int id)
        {
            TagLink tagLink = await db.TagLinks.FindAsync(id);
            if (tagLink == null)
            {
                return NotFound();
            }

            return Ok(tagLink);
        }

        // PUT: api/TagLinks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTagLink(int id, TagLink tagLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tagLink.ID)
            {
                return BadRequest();
            }

            db.Entry(tagLink).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagLinkExists(id))
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

        // POST: api/TagLinks
        [ResponseType(typeof(TagLink))]
        public async Task<IHttpActionResult> PostTagLink(TagLink tagLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TagLinks.Add(tagLink);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tagLink.ID }, tagLink);
        }

        // DELETE: api/TagLinks/5
        [ResponseType(typeof(TagLink))]
        public async Task<IHttpActionResult> DeleteTagLink(int id)
        {
            TagLink tagLink = await db.TagLinks.FindAsync(id);
            if (tagLink == null)
            {
                return NotFound();
            }

            db.TagLinks.Remove(tagLink);
            await db.SaveChangesAsync();

            return Ok(tagLink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TagLinkExists(int id)
        {
            return db.TagLinks.Count(e => e.ID == id) > 0;
        }
    }
}