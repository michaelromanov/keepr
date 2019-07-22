using System;
using System.Collections.Generic;
using keepr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using keepr.Repositories;
using System.Security.Claims;

namespace keepr.Controllers
{
    [Route("api/controller")]
    [ApiController]

    public class KeepsController : ControllerBase
    {
        private readonly KeepsRepository _repo;
        public KeepsController(KeepsRepository repo)
        {
            _repo = repo;
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
                return BadRequest(e);
            }
        }

        // Get One - usually by ID
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Keep> Get(string id)
        {
            try
            {
                return Ok(_repo.FindById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //Create One
        [Authorize]
        [HttpPost]
        public ActionResult<Keep> Post([FromBody] Keep value)
        {
            try
            {
                return Ok(_repo.Create(value));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //Edit One
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Keep> Put( [FromBody] Keep value)
        {
            try
            {
                var id = HttpContext.User.FindFirstValue("Id");
                value.UserId = id;
                return Ok(_repo.FindById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
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
               return BadRequest(e);
           }
        }

        //Update One
        [Authorize]


    }

}




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