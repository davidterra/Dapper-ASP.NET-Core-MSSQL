using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dummy.Repositories;
using Dummy.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productRepository.GetAll());
        }

        [HttpGet("categories")]
        [HttpGet("categories/{categoryID}")]
        public async Task<IActionResult> GetCategory(int? categoryID)
        {
            var result = await _productRepository.GetGroupByCategory(categoryID);

            if(categoryID.HasValue && result == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<GroupByCategoryViewModel>>(result));
        }
    }
}