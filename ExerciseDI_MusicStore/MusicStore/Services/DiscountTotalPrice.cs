using MusicStore.Models;

namespace MusicStore.Services
{
    public class DiscountTotalPrice : IDiscountService
    {
        public DiscountTotalPrice()
        {

        }
        public int GetDiscount(List<CartItem> items)
        {
           var totalPrice = items.Sum(item => item.Album?.Price * item.Count);

            switch (totalPrice)
            {
                case >= 50:
                    return 10;
                case >= 25:
                    return 5;
                default:
                    return 0;
            }
        }
    }
}
