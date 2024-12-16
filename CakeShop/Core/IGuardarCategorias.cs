using System.Collections.Generic;
using System.Threading.Tasks;

namespace CakeShop.Core.Models
{
    public interface IGuardarCategorias
    {
     
        Task<IEnumerable<Categoria>> GetCategories();
    }
}
