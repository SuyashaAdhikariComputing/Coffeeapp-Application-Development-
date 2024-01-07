
namespace Coffeeapp.Data.Models
{
    
    public class GlobalState
    {
        public User CurrentUser { get; set; }

        public List<OrderContent> OrderContent { get; set; } = new();


    }
}
