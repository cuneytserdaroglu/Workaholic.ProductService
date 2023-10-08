using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workaholic.ProductService.Domain;
using Workaholic.ProductService.Repository;

namespace Workaholic.ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productList = await _productRepository.GetAll();
            return Ok(productList);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            await _productRepository.Add(product);
            return Ok();
        }
    }
}