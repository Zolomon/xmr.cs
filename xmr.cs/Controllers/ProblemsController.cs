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
    public class ProblemsController : ApiController
    {
        private XmrContext db = new XmrContext();

        // GET: api/Problems
        public IQueryable<Problem> GetProblems()
        {
            return db.Problems;
        }

        // GET: api/Problems/5
        [ResponseType(typeof(Problem))]
        public async Task<IHttpActionResult> GetProblem(int id)
        {
            Problem problem = await db.Problems.FindAsync(id);
            if (problem == null)
            {
                return NotFound();
            }

            return Ok(problem);
        }

        // PUT: api/Problems/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProblem(int id, Problem problem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != problem.ID)
            {
                return BadRequest();
            }

            db.Entry(problem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProblemExists(id))
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

        // POST: api/Problems
        [ResponseType(typeof(Problem))]
        public async Task<IHttpActionResult> PostProblem(Problem problem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Problems.Add(problem);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = problem.ID }, problem);
        }

        // DELETE: api/Problems/5
        [ResponseType(typeof(Problem))]
        public async Task<IHttpActionResult> DeleteProblem(int id)
        {
            Problem problem = await db.Problems.FindAsync(id);
            if (problem == null)
            {
                return NotFound();
            }

            db.Problems.Remove(problem);
            await db.SaveChangesAsync();

            return Ok(problem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProblemExists(int id)
        {
            return db.Problems.Count(e => e.ID == id) > 0;
        }
    }
}