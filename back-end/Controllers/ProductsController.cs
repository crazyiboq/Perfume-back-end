using Microsoft.AspNetCore.Mvc;

using back_end.Services.Interfaces;

using back_end.DTOs.ProductDtos;
using back_end.Helpers;
using PerfumeShopApi.Services.Interfaces;

namespace back_end.Controllers

{

    [ApiController]

    [Route("api/[controller]")]

    public class ProductController : ControllerBase

    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)

        {

            _productService = productService;

        }

        // GET: api/product

        [HttpGet]

        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)

        {

            var qp = new ProductQueryParams

            {

                Page = page,

                PageSize = pageSize

            };

            var result = await _productService.GetAllAsync(qp);

            return Ok(result);

        }

        // GET: api/product/1

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)

        {

            var result = await _productService.GetByIdAsync(id);

            if (result == null) return NotFound();

            return Ok(result);

        }

        // POST: api/product

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)

        {

            try

            {

                var created = await _productService.CreateAsync(dto);

                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);

            }

            catch (ArgumentException ex)

            {

                return BadRequest(new { message = ex.Message });

            }

        }

        // PUT: api/product/1

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDto dto)

        {

            try

            {

                var updated = await _productService.UpdateAsync(id, dto);

                if (updated == null) return NotFound();

                return Ok(updated);

            }

            catch (ArgumentException ex)

            {

                return BadRequest(new { message = ex.Message });

            }

        }

        // DELETE: api/product/1

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)

        {

            var success = await _productService.DeleteAsync(id);

            if (!success) return NotFound();

            return NoContent();

        }

    }

}

