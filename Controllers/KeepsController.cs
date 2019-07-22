namespace keepr.Controllers
{
    [Route("api/controller")]
    [ApiController]

    public class KeepsController : ControllerBase
    {


        private readonly KeepRepository _repo;
        public KeepsController(KeepRepository repo)
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
        [HttpGet("{id}")]
        public ActionResult<Keep> Get(int id)
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
        [HttpPut("{id}")]
        public ActionResult<Keep> Put(int id, [FromBody] Keep value)
        {
            try
            {
                value.Id = id;
                return Ok(_repo.FindById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //Delete one
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