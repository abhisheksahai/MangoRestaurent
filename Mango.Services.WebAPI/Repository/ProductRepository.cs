using AutoMapper;
using Mango.Services.WebAPI.DbContexts;
using Mango.Services.WebAPI.Models;
using Mango.Services.WebAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.WebAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(product => product.ProductId == id);
            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
            }
            return false;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            Product Product = await _db.Products.FirstOrDefaultAsync(product => product.ProductId == id);
            return _mapper.Map<ProductDto>(Product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> products = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}