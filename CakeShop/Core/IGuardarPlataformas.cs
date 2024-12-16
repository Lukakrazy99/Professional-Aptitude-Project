using System.Collections.Generic;
using System.Threading.Tasks;

namespace CakeShop.Core.Models
{
    public interface IGuardarPlataformas
    {
     
        Task<IEnumerable<Plataforma>> GetPlataforma();
    }
}
