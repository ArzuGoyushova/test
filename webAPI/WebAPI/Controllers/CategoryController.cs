using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DAL;
using WebAPI.DTOs.Category;
using WebAPI.DTOs.Product;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public CategoryController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var category = _appDbContext.Categories
                .Include(c=>c.Products)
                .FirstOrDefault(p => p.Id == id && !p.IsDeleted);

            if (category == null) NotFound();

            var categoryReturnDto = _mapper.Map<CategoryReturnDto>(category);

           
            return Ok(categoryReturnDto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var query = _appDbContext.Categories.Where(p => !p.IsDeleted).ToList();
            return Ok(query);
        }

        [HttpPost]
        public IActionResult Create([FromForm]CategoryCreateDto category)
        {
            if (_appDbContext.Categories.Any(c => c.Name.ToLower() == category.Name.ToLower()))
            {
                return BadRequest();
            }
            _appDbContext.Categories.Add(new Category { Name = category.Name, ImageUrl="lorem.jpg"});
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult Update(int id, CategoryUpdateDto category)
        {
            var existCategory = _appDbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (existCategory == null) return NotFound();
            if (_appDbContext.Categories.Any(c => c.Name.ToLower() == category.Name.ToLower() && c.Id!=existCategory.Id))
            {
                return BadRequest();
            }
            _appDbContext.SaveChanges();
            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var existCategory = _appDbContext.Categories.FirstOrDefault(p => p.Id == id);
            if (existCategory == null) return NotFound();
            _appDbContext.Categories.Remove(existCategory);
            _appDbContext.SaveChanges();
            return NoContent();
        }
    }
}
