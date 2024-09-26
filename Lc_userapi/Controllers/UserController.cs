using Azure.Messaging;
using Lc_userapi.Models;
using Lc_userapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lc_userapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRespository _repository;
        public UserController(IUserRespository respository)
        {
            _repository = respository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<userClass>>> GetAll()
        {

            try
            {
                var user = await _repository.GetallAsync();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

          
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<userClass>> GetById(int id)
        {

            try
            {
                var user = await _repository.GetbyIdAsync(id);
                if (user == null) return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

           
        }


        [HttpPost]
        public async Task<ActionResult> Add(userClass uC)
        {
            try
            {

                await _repository.AddAsync(uC);
                return CreatedAtAction(nameof(GetById), new { id = uC.userId }, uC);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
               
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> update(int id, userClass uC)
        {

            try
            {
                if (id != uC.userId) return BadRequest();
                var existinguser = await _repository.GetbyIdAsync(id);
                if (existinguser == null) return BadRequest();

                await _repository.UpdateAsync(uC);
                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

          

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                var user = await _repository.GetbyIdAsync(id);
                if (user == null) return NotFound();

                await _repository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

        }
    }
}
