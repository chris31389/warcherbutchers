using System.Threading.Tasks;
using WArcherButchers.ServerApp.Infrastructure;

namespace WArcherButchers.ServerApp.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetRandom();
    }
}