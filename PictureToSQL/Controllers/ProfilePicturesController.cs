using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PictureToSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilePicturesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly PictureToSQLDbContext dbContext;

        public ProfilePicturesController(IMapper mapper, PictureToSQLDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        // GET: api/<ProfilePicturesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dtos.ProfilePictureResult>>> Get()
        {
            var results = await dbContext.ProfilePictures.Select(c => mapper.Map<Dtos.ProfilePictureResult>(c)).ToListAsync();

            return Ok(results);
        }

        // GET api/<ProfilePicturesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dtos.ProfilePictureResult>> Get(int id)
        {
            var profilePicture = await dbContext.ProfilePictures.FirstOrDefaultAsync(c => c.Id == id);

            if (profilePicture is null)
                return NotFound(id);

            var result = mapper.Map<Dtos.ProfilePictureResult>(profilePicture);

            return Ok(result);
        }

        // POST api/<ProfilePi cturesController>
        [HttpPost]
        public async Task<ActionResult<Dtos.ProfilePictureResult>> Post(Dtos.ProfilePictureEntry profilePictureEntry)
        {
            var profilePicture = mapper.Map<Models.ProfilePicture>(profilePictureEntry);

            dbContext.ProfilePictures.Add(profilePicture);

            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = profilePicture.Id }, mapper.Map<Dtos.ProfilePictureResult>(profilePicture));
        }

        // PUT api/<ProfilePicturesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Dtos.ProfilePictureResult>> Put(int id, Dtos.ProfilePictureEntry profilePictureEntry)
        {
            var profilePicture = await dbContext.ProfilePictures.FirstOrDefaultAsync(c => c.Id == id);

            if (profilePicture is null)
                return NotFound(profilePicture);

            mapper.Map<Dtos.ProfilePictureEntry, Models.ProfilePicture>(profilePictureEntry, profilePicture);

            await dbContext.SaveChangesAsync();

            var result = mapper.Map<Dtos.ProfilePictureResult>(profilePicture);

            return Ok(result);
        }

        // DELETE api/<ProfilePicturesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var profilePicture = await dbContext.ProfilePictures.FirstOrDefaultAsync(c => c.Id == id);

            if (profilePicture is null)
                return NotFound(id);

            dbContext.Remove(profilePicture);

            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
