using System.Collections.Generic;
using System.Threading.Tasks;

namespace CakeShop.Core.Models
{
    public interface IGuardarReview
    {
   
        void UpdateReview(Review review);
        Task AddReviewAsync(Review review);
        //void DeleteJogo(int id);
    }
}
