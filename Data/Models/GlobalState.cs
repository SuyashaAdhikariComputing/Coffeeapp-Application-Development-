
namespace Coffeeapp.Data.Models
{
    // this is the model for globalstate and its attributes are below
    public class GlobalState
    {

        public User CurrentUser { get; set; }

        public List<OrderContent> OrderContent { get; set; } = new();


    }
}
