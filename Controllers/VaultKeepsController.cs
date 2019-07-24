using System;
using System.Collections.Generic;
using System.Security.Claims;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace keepr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsRepository _repo;
        public VaultKeepsController(VaultKeepsRepository repo)
        {
            _repo = repo;
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult<VaultKeeps> Post([FromBody] VaultKeeps value)
        {
            try
            {
                var id = HttpContext.User.FindFirstValue("Id");
                value.UserId = id;
                return Ok(_repo.Create(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<VaultKeeps>> Get(int id)
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

        // [Authorize]
        // [HttpPut("{id}")]
        // public ActionResult<VaultKeeps> Put(int id, [FromBody] VaultKeeps value)
        // {
        //     try
        //     {
        //         value.UserId = HttpContext.User.FindFirstValue("Id");
        //         return Ok(_repo.Delete(value));
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }


    }
}