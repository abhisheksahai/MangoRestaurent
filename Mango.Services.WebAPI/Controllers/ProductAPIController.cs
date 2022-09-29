using Mango.Services.WebAPI.Models.Dtos;
using Mango.Services.WebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/products")]
    public class ProductAPIController : ControllerBase
    {
        IProductRepository _pr;

        public ProductAPIController(IProductRepository pr)
        {
            _pr = pr;
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            ResponseDto responseDto = new ResponseDto();
            try
            {
                IEnumerable<ProductDto> productDtos = await _pr.GetProducts();
                responseDto.Result = productDtos;
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessage = new List<string> { ex.ToString() };
            }
            return responseDto;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto> Get(int id)
        {
            ResponseDto responseDto = new();
            try
            {
                ProductDto productDto = await _pr.GetProductById(id);
                responseDto.Result = productDto;
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessage = new List<string> { ex.ToString() };
            }
            return responseDto;
        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] ProductDto productDto)
        {
            ResponseDto responseDto = new();
            try
            {
                ProductDto model = await _pr.CreateUpdateProduct(productDto);
                responseDto.Result = model;
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessage = new List<string> { ex.ToString() };
            }
            return responseDto;
        }

        [HttpPut]
        public async Task<ResponseDto> Put([FromBody] ProductDto productDto)
        {
            ResponseDto responseDto = new();
            try
            {
                ProductDto model = await _pr.CreateUpdateProduct(productDto);
                responseDto.Result = model;
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessage = new List<string> { ex.ToString() };
            }
            return responseDto;
        }

        [HttpDelete]
        public async Task<ResponseDto> Delete(int id)
        {
            ResponseDto responseDto = new();
            try
            {
                bool model = await _pr.DeleteProduct(id);
                responseDto.Result = model;
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessage = new List<string> { ex.ToString() };
            }
            return responseDto;
        }

    }
}
