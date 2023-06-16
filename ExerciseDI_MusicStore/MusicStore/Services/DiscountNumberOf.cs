using MusicStore.Models;

namespace MusicStore.Services
{
    public class DiscountNumberOf : IDiscountService
    {
        public DiscountNumberOf() { }
        public int GetDiscount(List<CartItem> items)
        {
            var amount = items.Sum(i => i.Count);

            switch (amount)
            {
                case >= 10:
                    return 10;
                case >= 5:
                    return 5;
                default: 
                    return 0;
            }
        }
    }
}
