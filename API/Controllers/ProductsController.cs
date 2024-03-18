using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ProductType> _productType;
        private readonly IGenericRepository<Product> _product;
        private readonly IGenericRepository<ProductBrand> _productBrand;
        public ProductsController(IGenericRepository<Product> product,
        IGenericRepository<ProductBrand> productBrand,
        IGenericRepository<ProductType> productType,IProductRepository repo, IMapper mapper )
        {
            _productBrand = productBrand;
            _product = product;
            _productType = productType;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("ProductsGeneric")]
         public async Task<ActionResult<List<Product>>> GetProducts(){
            var spec= new ProductsWithBrandAndTypeSpec();
            var allProducts = await  _product.ListAsync(spec);
            return Ok(allProducts);
        }

        [HttpGet("allProducts")]
         public async Task<ActionResult<List<ProductsToReturn>>> GetProductsNav(){
            var allProducts = await  _repo.GetProductsAsync();
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductsToReturn>>(allProducts));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            var spec= new ProductsWithBrandAndTypeSpec(id);
            return await _product.GetEntityWithSpec(spec);
        }
        [HttpGet("GetProduct/{id}")]
        public async Task<ActionResult<ProductsToReturn>> GetProductsById(int id){

            var product = await _repo.GetProductByIdAsync(id);
            return _mapper.Map<Product,ProductsToReturn>(product);
        }
        [HttpGet("GetProductBrandById/{id}")]
        public async Task<ActionResult<ProductBrand>> GetProductBrandById(int id){

            return await _productBrand.GetByIdAsync(id);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands(){
            return Ok(await _productBrand.ListAllAsync());
        }
        [HttpGet("brandsByRepo")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrandsByRepo(){
            return Ok(await _repo.GetProductsBrandAsync());
        }
         [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes(){
            return Ok(await _productType.ListAllAsync());
        }
    }
}