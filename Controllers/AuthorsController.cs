using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Bookstore.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Api.Controllers
{
    [Route("api/Authors")]

    public class AuthorsController : Controller
    {
        private readonly BookstoreContext db;

        public AuthorsController(BookstoreContext db)
        {
            this.db = db;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(db.Authors);
        }

        [HttpGet("{id}", Name="GetAuthor")]

        public IActionResult GetById(int id)
        {
            var author = db.Authors.Find(id);
            
            if(author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]

        public IActionResult Post([FromBody]Author author)
        {
            if(author == null)
            {
                return BadRequest();
            }

            this.db.Authors.Add(author);
            this.db.SaveChanges();

            return CreatedAtRoute("GetAuthor", new { id = author.AuthorId}, author);
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody]Author newAuthor)
        {
            if(newAuthor == null || newAuthor.AuthorId != id)
            {
                return BadRequest();
            }

            var currentAuthor = this.db.Authors.FirstOrDefault(x => x.AuthorId == id);
            
            currentAuthor.Name = newAuthor.Name;

            this.db.Authors.Update(currentAuthor);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var author = this.db.Authors.FirstOrDefault(x => x.AuthorId == id);

            if(author == null)
            {
                return NotFound();
            }

            this.db.Authors.Remove(author);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}