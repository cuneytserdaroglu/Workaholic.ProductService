using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Workaholic.ProductService.Domain;
using Workaholic.ProductService.Repository;

namespace Workaholic.ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly HttpClient _httpClient;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://host.docker.internal:1454/");
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

        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
           var maxRetries = 5;
var retryDelay = TimeSpan.FromSeconds(5);

for (int i = 0; i < maxRetries; i++)
{
    try
    {
        var response = await _httpClient.GetAsync("api/Category");
        if (response.IsSuccessStatusCode)
        {
            var categoryDataStringAsync = await response.Content.ReadAsStringAsync();
            var categoryData = JsonConvert.DeserializeObject<List<Category>>(categoryDataStringAsync);
            return Ok(categoryData);
        }
    }
    catch (HttpRequestException)
    {
        // Log the error or use a more sophisticated retry strategy
        await Task.Delay(retryDelay);
    }
}

return Ok("Failed after multiple retries");
        }
    }
}