using MusicStore.Models;
using MusicStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unittests
{
    [TestClass]
    public class DiscountNumberOfUnitTest
    {
        [TestMethod]
        public void GetDiscount_ArticlesAmount4_Returns0()
        {
            // ARRANGE 
            DiscountNumberOf discountNumberof= new DiscountNumberOf();
            List<CartItem> cartItems = new List<CartItem>();

            cartItems.Add(new CartItem
            {
                Album = new Album
                {
                    AlbumID = 1,
                    AlbumArtUrl = "url",
                    ArtistID = 1,
                    GenreID = 1,
                    Price = 3,
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
                    Price = 1,
                    Title = "title",
                },
                AlbumID = 2,
                CartItemID = 2,
                CartKey = "othercartkey",
                Count = 1
            });
            //ACT
            var totalDiscount = discountNumberof.GetDiscount(cartItems);
            //ASSERT
            Assert.AreEqual(0, totalDiscount);

        }


        [TestMethod]
        public void GetDiscount_ArticlesAmount5_Returns5()
        {
            // ARRANGE 
            DiscountNumberOf discountNumberof = new DiscountNumberOf();
            List<CartItem> cartItems = new List<CartItem>();

            cartItems.Add(new CartItem
            {
                Album = new Album
                {
                    AlbumID = 1,
                    AlbumArtUrl = "url",
                    ArtistID = 1,
                    GenreID = 1,
                    Price = 3,
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
                    Price = 1,
                    Title = "title",
                },
                AlbumID = 2,
                CartItemID = 2,
                CartKey = "othercartkey",
                Count = 2
            });
            //ACT
            var totalDiscount = discountNumberof.GetDiscount(cartItems);
            //ASSERT
            Assert.AreEqual(5, totalDiscount);

        }

        [TestMethod]
        public void GetDiscount_ArticlesAmount10_Returns10()
        {
            // ARRANGE 
            DiscountNumberOf discountNumberof = new DiscountNumberOf();
            List<CartItem> cartItems = new List<CartItem>();

            cartItems.Add(new CartItem
            {
                Album = new Album
                {
                    AlbumID = 1,
                    AlbumArtUrl = "url",
                    ArtistID = 1,
                    GenreID = 1,
                    Price = 3,
                    Title = "title",
                },
                AlbumID = 1,
                CartItemID = 1,
                CartKey = "cartKey",
                Count = 9
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
            var totalDiscount = discountNumberof.GetDiscount(cartItems);
            //ASSERT
            Assert.AreEqual(10, totalDiscount);

        }
    }
}
