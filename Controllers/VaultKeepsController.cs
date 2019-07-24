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

        [HttpGet("{vaultId}")]
        public ActionResult<IEnumerable<Keep>> Get(int vaultId)
        {
            try
            {
                var userId = HttpContext.User.FindFirstValue("Id");
                return Ok(_repo.FindById(vaultId, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult<string> Put([FromBody] VaultKeeps value)
        {
                try
                {
                var userId = HttpContext.User.FindFirstValue("Id");
                value.UserId = userId;
                return Ok(_repo.Del(value));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
          
        }

   
   
   
//  public ActionResult<IEnumerable<Keep>> FindKeepsByUserId()
//         {
//             try
//             {
//                 var id = HttpContext.User.FindFirstValue("Id");
//                 return Ok(_repo.FindKeepsByUserId(id));
//             }

    // public class VaultKeeps 
    // {
    //     public int Id { get; set; }
    //     public int VaultId { get; set; }
    //     public int KeepId { get; set; }
    //     public string UserId { get; set; }
    // }
       
        // [HttpPut("{id}")]
        // public ActionResult<string> Put([FromBody] VaultKeeps value)
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
