using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCrud.Models;
using SimpleCrud.Repository.UserRepository;
using SimpleCrud.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleCrud.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserController( UserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            try
            {
                var fetch = _userRepository.GetAll();
                return fetch;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var fetch = _userRepository.GetById(id);
            if (fetch == null)
            {
                return NotFound();
            }
            return fetch;
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user== null)
            {
               return BadRequest();
            }
            try
            {
                _unitOfWork.GetRepository<User>().Insert(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User model)
        {
            if (id!=model.Id)
            {
               return BadRequest();
            }
            try
            {
                var user = _userRepository.GetById(id);
                if (user==null)
                {
                   return NotFound();
                }
                _userRepository.Remove(user);
                _unitOfWork.GetRepository<User>().Insert(model);
            }
            catch (DbUpdateConcurrencyException )
            {
                if (!UserExist(id))
                {
                   return NotFound();
                }
                else
                    throw;
            }
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _userRepository.GetById(id);
                _unitOfWork.GetRepository<User>().Remove(user);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return Ok();
        }

        private bool UserExist(int id)
        {
            var user = _userRepository.GetById(id);
            if (user.Id == id)
            {
                return true;
            }
            else
                return false;
        }
    }
}
