using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        //[Test]
        //public void foo()
        //{
        //    IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        //    GildedRose app = new GildedRose(Items);
        //    app.UpdateQuality();
        //    Assert.AreEqual("fixme", Items[0].Name);
        //}

        // Create an item that will store name, sellin, quality and will return UpdateQuality() function

        

        private Item CreateItemAndUpdateIt(string name, int sellIn, int quality)
        {
            IList<Item> items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            return items[0];
        }



        // 1. Test sellin + quality through time
        [Test]
        public void SellInQualitythroughtime()
        {
            Item item = CreateItemAndUpdateIt("Test",10,20);
            Assert.AreEqual(9, item.SellIn);
            Assert.AreEqual(19, item.Quality);
        }

        // 2. Test quality x2 when SellIn = 0
        [Test]
        public void SellIn0Qualitythroughtime()
        { 
            Item item = CreateItemAndUpdateIt("Test2", 0, 20);
            Assert.AreEqual(18, item.Quality);
        }

        // 3. Quality can't be negative
        [Test]
        public void QualityNegative()
        {
            Item item = CreateItemAndUpdateIt("Test3", 0, 0);
            Assert.AreEqual(0, item.Quality);
        }

        // 4. Test Aged Brie, quality that increase the more the time pass
        [Test]
        public void AgedBrieIncrease()
        {
            Item item = CreateItemAndUpdateIt("Aged Brie", 4, 12);
            Assert.AreEqual(13, item.Quality);
        }

        // 5. Test Quality cannot exceed 50
        [Test]
        public void AgedBrieexceed50()
        {
            Item item = CreateItemAndUpdateIt("Aged Brie", 4, 50);
            Assert.AreEqual(50, item.Quality);
        }

        // 6. Test Sulfuras that quality never decrease because it's a legendary item
        [Test]
        public void SulfurasQuality()
        {
            Item item = CreateItemAndUpdateIt("Sulfuras, Hand of Ragnaros", 4, 80);
            Assert.AreEqual(80, item.Quality);
        }

        // 7. Test Backstages Passes, Quality increase by two if 5>sellin<=10
        [Test]
        public void BackstageQuality2()
        {
            Item item = CreateItemAndUpdateIt("Backstage passes to a TAFKAL80ETC concert", 9, 23);
            Assert.AreEqual(25, item.Quality);
        }

        // 8. Test Backstages Passes, Quality increase by two if 5>=sellin
        [Test]
        public void BackstageQuality3()
        {
            Item item = CreateItemAndUpdateIt("Backstage passes to a TAFKAL80ETC concert", 5, 23);
            Assert.AreEqual(26, item.Quality);
        }

        // 9. Test Backstages Passes, Quality drops to 0 after concert
        [Test]
        public void BackstageQuality0concert()
        {
            Item item = CreateItemAndUpdateIt("Backstage passes to a TAFKAL80ETC concert", 0, 23);
            Assert.AreEqual(0, item.Quality);
        }

        // 10. Test Sulfuras expiration
        [Test]
        public void SulfurasExpiration()
        {
            Item item = CreateItemAndUpdateIt("Sulfuras, Hand of Ragnaros", 1, 80);
            Assert.AreEqual(1, item.SellIn);
        }


    }
}
