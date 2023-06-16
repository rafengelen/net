using Moq;
using MusicStore.Models;
using MusicStore.Services;

namespace Unittests
{
    [TestClass]
    public class DiscountTotalPriceUnitTest
    {
       
        [TestMethod]
        public void GetDiscount_ArticlesPrice10_Returns0()
        {
            // ARRANGE 
            DiscountTotalPrice discountTotalPrice= new DiscountTotalPrice();
            List<CartItem> cartItems= new List<CartItem>();

            cartItems.Add(new CartItem
            {
                Album = new Album
                {
                    AlbumID = 1,
                    AlbumArtUrl = "url",
                    ArtistID = 1,
                    GenreID = 1,
                    Price = 3,
                    Title= "title" ,
                },
                AlbumID= 1,
                CartItemID= 1,
                CartKey = "cartKey",
                Count = 3
            });
            cartItems.Add(new CartItem
            {
                Album = new Album
                {
                    AlbumID = 2,
                    AlbumArtUrl = "url",
                    ArtistID = 2,
                    GenreID = 2,
                    Price = 1,
                    Title = "title",
                },
                AlbumID = 2,
                CartItemID = 2,
                CartKey = "othercartkey",
                Count = 1
            });
            //ACT
            var totalDiscount = discountTotalPrice.GetDiscount(cartItems);
            //ASSERT
            Assert.AreEqual(0, totalDiscount);

        }
        [TestMethod]
        public void GetDiscount_ArticlesPrice30_Returns5()
        {
            // ARRANGE 
            DiscountTotalPrice discountTotalPrice = new DiscountTotalPrice();
            List<CartItem> cartItems = new List<CartItem>();

            cartItems.Add(new CartItem
            {
                Album = new Album
                {
                    AlbumID = 1,
                    AlbumArtUrl = "url",
                    ArtistID = 1,
                    GenreID = 1,
                    Price = 7,
                    Title = "title",
                },
                AlbumID = 1,
                CartItemID = 1,
                CartKey = "cartKey",
                Count = 3
            });
            cartItems.Add(new CartItem
            {
                Album = new Album
                {
                    AlbumID = 2,
                    AlbumArtUrl = "url",
                    ArtistID = 2,
                    GenreID = 2,
                    Price = 3,
                    Title = "title",
                },
                AlbumID = 2,
                CartItemID = 2,
                CartKey = "othercartkey",
                Count = 3
            });
            //ACT
            var totalDiscount = discountTotalPrice.GetDiscount(cartItems);
            //ASSERT
            Assert.AreEqual(5, totalDiscount);
        }
        [TestMethod]
        public void GetDiscount_ArticlesPrice60_Returns10()
        {
            // ARRANGE 
            DiscountTotalPrice discountTotalPrice = new DiscountTotalPrice();
            List<CartItem> cartItems = new List<CartItem>();

            cartItems.Add(new CartItem
            {
                Album = new Album
                {
                    AlbumID = 1,
                    AlbumArtUrl = "url",
                    ArtistID = 1,
                    GenreID = 1,
                    Price = 20,
                    Title = "title",
                },
                AlbumID = 1,
                CartItemID = 1,
                CartKey = "cartKey",
                Count = 2
            });
            cartItems.Add(new CartItem
            {
                Album = new Album
                {
                    AlbumID = 2,
                    AlbumArtUrl = "url",
                    ArtistID = 2,
                    GenreID = 2,
                    Price = 10,
                    Title = "title",
                },
                AlbumID = 2,
                CartItemID = 2,
                CartKey = "othercartkey",
                Count = 2
            });
            //ACT
            var totalDiscount = discountTotalPrice.GetDiscount(cartItems);
            //ASSERT
            Assert.AreEqual(10, totalDiscount);
        }

    }
}