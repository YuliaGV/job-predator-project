using JobPredator.Models;
using JobPredator.Services;
using JobPredator.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPredator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {

        IJobService _jobService;

        public JobsController(IJobService service)
        {
            _jobService = service;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var jobs = await _jobService.Get();
            return Ok(jobs);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var job = await  _jobService.GetById(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }


        [HttpPost]
        public async Task<IActionResult> SaveJob([FromBody] Job job)
        {
            if (job == null)
            {
                return BadRequest("Job cannot be null");
            }

            bool result = await _jobService.Save(job);
            if (!result)
            {
                return Conflict("A job with the same URL, title, and location already exists.");
            }

            return CreatedAtAction(nameof(GetById), new { id = job.Id }, job);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            bool result = await _jobService.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }






    }
}
