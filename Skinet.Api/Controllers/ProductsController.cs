using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Skinet.Api.Dto;
using Skinet.Api.Errors;
using Skinet.Api.Helper;
using Skinet.Model;
using Skinet.Service.Interfaces;

namespace Skinet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _rep;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository rep, IMapper mapper)
        {
            _mapper = mapper;
            _rep = rep;
        }

        [HttpGet("{index}/{length}/{sort}")]
        public async Task<IActionResult> GetAll(int index, int length, string sort = null)
        {
            var products = _mapper.Map<IEnumerable<ProductToReturnDto>>(await _rep.GetProducts(sort));

            var result = new PaginationResponse<ProductToReturnDto>(products, index, length);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = _mapper.Map<ProductToReturnDto>(await _rep.GetProductById(id));

            if (product == null) return NotFound(new ApiResponse(404));

            return Ok(product);
        }

        [HttpGet("name/{name}/{index}/{length}")]
        public async Task<IActionResult> GetByName(string name, int index, int length)
        {
            name = name.ToLower();

            name = Char.ToUpperInvariant(name[0]) + name.Substring(1);

            var products = _mapper.Map<IEnumerable<ProductToReturnDto>>(await _rep.GetProductByName(name));

            var result = new PaginationResponse<ProductToReturnDto>(products, index, length);

            return Ok(result);
        }

        [HttpGet("productbrand/{brandId}/{index}/{length}")]
        public async Task<IActionResult> GetProductsByBrand(int brandId, int index, int length, string sort = null)
        {
            var products = _mapper.Map<IEnumerable<ProductToReturnDto>>(await _rep.GetProductsByBrand(brandId, sort));

            var result = new PaginationResponse<ProductToReturnDto>(products, index, length);

            return Ok(result);
        }

        [HttpGet("producttype/{typeId}/{index}/{length}")]
        public async Task<IActionResult> GetProductsByType(int typeId, int index, int length, string sort = null)
        {
            var products = _mapper.Map<IEnumerable<ProductToReturnDto>>(await _rep.GetProductsByType(typeId, sort));

            var result = new PaginationResponse<ProductToReturnDto>(products, index, length);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductToCreateOrUpdateDto productToCreateOrUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiResponse(400));

            var product = _mapper.Map<Product>(productToCreateOrUpdateDto);

            await _rep.Create(product);

            return Ok(_mapper.Map<ProductToReturnDto>(product));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductToCreateOrUpdateDto productToCreateOrUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiResponse(400));

            var product = _mapper.Map<Product>(productToCreateOrUpdateDto);

            await _rep.Update(product);

            return Ok(_mapper.Map<ProductToReturnDto>(product));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _rep.GetById(id);

            await _rep.Delete(product);

            return Ok();
        }
    }
}