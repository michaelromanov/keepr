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

    public class VaultsController : ControllerBase
    {
       private readonly VaultsRepository _repo;
        public VaultsController(VaultsRepository repo)
        {
            _repo = repo;
        }

        //In Cascading Order: 
        [Authorize]
        [HttpPost]
        public ActionResult<Vault> Post([FromBody] Vault value)
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
        
        [HttpGet]
        public ActionResult<IEnumerable<Vault>> Get()
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

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Vault> Get(int id)
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