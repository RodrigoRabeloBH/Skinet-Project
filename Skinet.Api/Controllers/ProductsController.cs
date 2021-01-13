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

        [HttpGet("all")]
        public async Task<IActionResult> GetAll(int index, int length, string sort, int? brandId, int? typeId)
        {
            brandId = brandId == 0 ? null : brandId;
            typeId = typeId == 0 ? null : typeId;
            
            var products = _mapper.Map<IEnumerable<ProductToReturnDto>>(await _rep.GetProductsByBrandAndTypes(brandId, typeId, sort));

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

        [HttpGet("search")]
        public async Task<IActionResult> GetByName(int index, int length, string search)
        {
            search = search.ToLower();

            search = Char.ToUpperInvariant(search[0]) + search.Substring(1);

            var products = _mapper.Map<IEnumerable<ProductToReturnDto>>(await _rep.GetProductByName(search));

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