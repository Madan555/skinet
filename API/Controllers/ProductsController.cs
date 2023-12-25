using API.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IGenericRepository<ProductType> _productType;
        private readonly IGenericRepository<Product> _product;
        private readonly IGenericRepository<ProductBrand> _productBrand;
        public ProductsController(IGenericRepository<Product> product,
        IGenericRepository<ProductBrand> productBrand,
        IGenericRepository<ProductType> productType)
        {
            _productBrand = productBrand;
            _product = product;
            _productType = productType;
        }

        [HttpGet]
         public async Task<ActionResult<List<Product>>> GetProducts(){
            var allProducts = await  _product.ListAllAsync();
            return Ok(allProducts);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){

            return await _product.GetByIdAsync(id);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands(){
            return Ok(await _productBrand.ListAllAsync());
        }
         [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes(){
            return Ok(await _productType.ListAllAsync());
        }
    }
}