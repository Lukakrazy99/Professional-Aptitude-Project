using System.Collections.Generic;
using System.Threading.Tasks;

namespace CakeShop.Core.Models
{
	public interface ICarroComprasService
	{
		string Id { get; set; }
		IEnumerable<CarroComprasItem> CarroComprasItems { get; set; }

		Task<int> AddToCarroAsync(Jogo jogos, int qnt = 1);
		Task ClearCarroAsync();
		Task<IEnumerable<CarroComprasItem>> GetCarroComprasItemsAsync();
		Task<int> RemoveFromCarroAsync(Jogo jogos);
		Task<(int ItemCount, decimal TotalAmmount)> GetCarroCountAndTotalAmmountAsync();
	}
}