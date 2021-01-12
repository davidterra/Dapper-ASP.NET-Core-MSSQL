using Microsoft.AspNetCore.Mvc;
using Dummy.Repositories;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Dummy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository _salesrRepository;
        public SalesController(ISalesRepository sellerRepository)
        {
            _salesrRepository = sellerRepository;
        }


        [HttpGet("topseller")]
        [HttpGet("topseller/{top:int}")]
        public async Task<IActionResult> GetTopSeller(int top = 5)
        {
            var result = await _salesrRepository.GetTopSeller(top);

            var grandTotal = result.Sum(s => s.Subtotal);

            result.ForEach(r => r.Percentage = (float)(r.Subtotal/grandTotal)*100);

            return Ok(result);
        }

        [HttpGet("year")]
        public async Task<IActionResult> GetOrdersTotalByYear()
        {
            var result = await _salesrRepository.GetOrdersTotalByYear();
            return Ok(result);
        }


    }
}