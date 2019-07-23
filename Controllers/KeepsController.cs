using System;
using System.Collections.Generic;
using keepr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using keepr.Repositories;
using System.Security.Claims;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class KeepsController : ControllerBase
    {
        private readonly KeepsRepository _repo;
        public KeepsController(KeepsRepository repo)
        {
            _repo = repo;
        }
      
        //In Cascading Order: 

        //Create One
        [Authorize]
        [HttpPost]
        public ActionResult<Keep> Post([FromBody] Keep value)
        {
            try
            {
                var id = HttpContext.User.FindFirstValue("Id");
                value.userId = id;
                return Ok(_repo.Create(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Get All
        [HttpGet]
        public ActionResult<IEnumerable<Keep>> Get()
        {   
            try
            {
                return Ok(_repo.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Get Keeps by User
        [Authorize]
        [HttpGet("user")]
        public ActionResult<IEnumerable<Keep>> FindKeepsByUserId()
        {
            try
            {
                var id = HttpContext.User.FindFirstValue("Id");
                return Ok(_repo.FindKeepsByUserId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Get One - by KeepID
        
        [HttpGet("{id}")]
        public ActionResult<Keep> Get(int id)
        {
            try
            {
                return Ok(_repo.FindById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Edit One
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Keep> Put(int id, [FromBody] Keep value)
        {
            try
            {
                value.userId = HttpContext.User.FindFirstValue("Id");
                return Ok(_repo.Update(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Delete one
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult <string> Delete(int id)
        {
           try
           {
                return Ok(_repo.Delete(id));
           }
           catch (Exception e)
           {
               return BadRequest(e.Message);
           }
        }
    }
}


        // Get Keeps by User - /keeps/user returns all keeps from user
        //Pull from the forced enumerable list and find the first value using FindFirst
        //ctrl . to generate method in KeepsRepository


    //   // Get One - usually by ID
    //     [HttpGet("{id}")]
    //     public ActionResult<Knight> Get(int id)
    //     {
    //         return Ok(_service.FindById(id));
    //     }

        //         [HttpDelete("{id}")]
        // public ActionResult Delete(int id)
        // {
        //     return Ok(_service.Delete(id));
        // }


        // Jake - Watch RealmCommander up to but not including Interfaces
        // Get All, Get One, Create One, Edit One, Delete One
        // private readonly UserRepository _repo;
        // public AccountController(UserRepository repo)
        // {
        //     _repo = repo;
        // }

                // // Get One - usually by ID
        // [Authorize]
        // [HttpGet("user/{userId}")]
        // public ActionResult<Keep> Get(string userId)
        // {
        //     try
        //     {
        //         return Ok(_repo.FindByUserId(userId));
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }
