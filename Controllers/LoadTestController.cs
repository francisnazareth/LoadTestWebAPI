using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoadTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadTestController : ControllerBase
    {
        private static int counter = 0;
        private readonly String fileName = "userRegistration_";

        // GET: api/<LoadTestController>
        [HttpGet]
        public string Get()
        {
            counter = (counter % 40) + 1;
            string csvName = fileName + counter + ".csv";
            Console.WriteLine("serving file name: " + csvName);
            return csvName;
        }

        // GET api/<LoadTestController>/5
        [HttpGet("{id}")]
        public void Get(int id)
        {
            if( (id > 0) && (id <= 40) )
                 counter = id - 1;
            else counter = 0;
        }

        [HttpPost]
        public void Post([FromBody] User user)
        {
            Console.WriteLine( user.name +  "," +  user.email + "," + user.nationality);
        }
    }
}