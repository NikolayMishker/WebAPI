using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        public Task<IReadOnlyList<Product>> GetProductAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
