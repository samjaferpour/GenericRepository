using GenericRepository.Contract.Dtos;
using GenericRepository.Contract.Interfaces.ApplicationServices;
using GenericRepository.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepository.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IAddProductService _addProductService;

        public ProductController(IAddProductService addProductService)
        {
            this._addProductService = addProductService;
        }
        //[HttpGet]
        //public async Task<IActionResult<List<ProductRespone>>> GetAllProducts()
        //{
        //    var products = 
        //}
        [HttpPost]
        public async Task<ActionResult<AddProductRequest>> AddProduct(AddProductRequest request)
        {
            await _addProductService.Execute(request);
            return Ok(request);
        } 
    }
}
