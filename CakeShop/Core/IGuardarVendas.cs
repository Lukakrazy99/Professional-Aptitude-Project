using CakeShop.Core.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CakeShop.Core.Models
{
    public interface IGuardarVendas
    {
        Task CreateVendasAsync(Order order);
        Task<IEnumerable<MinhasVendasViewModel>> GetAllVendasAsync();
        Task<IEnumerable<MinhasVendasViewModel>> GetAllVendasAsync(string userId);
    }
}