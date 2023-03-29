using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace module.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class moduleController : ControllerBase
    {
        [HttpGet("zavd1")]
        public async Task<ActionResult<Tuple<double, double>>> Get(float diagonal)
        {   
            if (diagonal < 0) 
            {
                return BadRequest(400);
            }
            double side = diagonal / Math.Sqrt(2.0);
            double P = 4 * side;
            double S = Math.Pow(side, 2.0);
            return Ok(Tuple.Create(P, S));
        }

        [HttpGet("zavd2")]
        public async Task<ActionResult<double>> Get(float a, int n)
        {
            if (n < 1)
            {
                return BadRequest(400);
            }
            double Sum = 0;
            for ( int i = 0; i < n; i++ )
            {
                Sum += Math.Pow(a + i, 2.0);
            }
            return Ok(Sum);
        }
    }
}
