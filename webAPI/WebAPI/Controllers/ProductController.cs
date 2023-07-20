using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DAL;
using WebAPI.DTOs.Product;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public ProductController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var product = _appDbContext.Products
                .Include(p=>p.Category)
                .ThenInclude(c=>c.Products)
                .FirstOrDefault(p => p.Id == id&&!p.IsDeleted);
            if (product == null) NotFound();

            var returnProduct = _mapper.Map<ProductReturnDto>(product);

            return StatusCode(200, returnProduct);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var query = _appDbContext.Products.Where(p=>!p.IsDeleted);

            var productListDto = new ProductListDto
            {
                TotalCount = query.Count(),
                Items = query.Select(p => new ProductListItemDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    CostPrice = p.CostPrice,
                    SalePrice = p.SalePrice
                }).ToList()
            };

            return StatusCode(StatusCodes.Status200OK,productListDto);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateDto productCreateDto)
        {
            var newProduct = new Product();
            newProduct.Name = productCreateDto.Name;
            newProduct.SalePrice = productCreateDto.SalePrice;
            newProduct.CostPrice = productCreateDto.CostPrice;
            newProduct.CategoryId = productCreateDto.CategoryId;
            _appDbContext.Products.Add(newProduct);
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult Update(int id, ProductUpdateDto productUpdateDto)
        {
            var existProduct = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return NotFound();

            existProduct.Name = productUpdateDto.Name;
            existProduct.SalePrice = productUpdateDto.SalePrice;
            existProduct.CostPrice = productUpdateDto.CostPrice;
            existProduct.CategoryId = productUpdateDto.CategoryId;
            _appDbContext.SaveChanges();
            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var existProduct = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return NotFound();
            _appDbContext.Products.Remove(existProduct);
            _appDbContext.SaveChanges();
            return NoContent();
        }

        [Route("{id}")]
        [HttpPatch]
        public IActionResult IsDelete(int id, bool isDelete)
        {
            var existProduct = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return NotFound();
            existProduct.IsDeleted = isDelete;
            _appDbContext.SaveChanges();
            return NoContent();
        }
    }
}
