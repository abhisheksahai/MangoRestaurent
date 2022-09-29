using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private const string productRoute = "/api/products/";
        public ProductService(IHttpClientFactory httpClient) : base(httpClient)
        {
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await SendAsync<T>(new ApiRequest
            {
                AccessToken = "",
                Url = $"{SD.ProductAPIBase}{productRoute}",
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await SendAsync<T>(new ApiRequest
            {
                AccessToken = "",
                Url = $"{SD.ProductAPIBase}{productRoute}{id}",
            });
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await SendAsync<T>(new ApiRequest
            {
                AccessToken = "",
                Url = $"{SD.ProductAPIBase}{productRoute}",
                ApiType = SD.ApiType.POST,
                Data = productDto
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await SendAsync<T>(new ApiRequest
            {
                AccessToken = "",
                Url = $"{SD.ProductAPIBase}{productRoute}",
                ApiType = SD.ApiType.PUT,
                Data = productDto
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await SendAsync<T>(new ApiRequest
            {
                AccessToken = "",
                Url = $"{SD.ProductAPIBase}{productRoute}",
                ApiType = SD.ApiType.DELETE
            });
        }
    }
}
