using System.Collections.Generic;
using GildedRose;
using NUnit.Framework;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Test]
        public void Foo()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new GildedRose.GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual("foo", items[0].Name);
        }

        [Test]
        public void UpdateQuality_BackstagePass()
        {
            AssertBackstagePassQuality(22, 10, 20);
            AssertBackstagePassQuality(23, 4, 20);
            AssertBackstagePassQuality(0, -1, 20);
        }

        [Test]
        public void UpdateQuality_Generic()
        {
            AssertGenericQuality(58, -1, 60);
        }

        [Test]
        public void UpdateQuality_AgedBrie()
        {
            AssertAgedBrieQuality(22, -1, 20);
        }

        private void AssertBackstagePassQuality(int expected, int sellIn, int quality)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = sellIn,
                    Quality = quality
                }
            };

            var app = new GildedRose.GildedRose(items);
            app.UpdateQuality();


            Assert.AreEqual(expected, items[0].Quality);
        }

        private void AssertGenericQuality(int expected, int sellIn, int quality)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Generic",
                    SellIn = sellIn,
                    Quality = quality
                }
            };

            var app = new GildedRose.GildedRose(items);
            app.UpdateQuality();


            Assert.AreEqual(expected, items[0].Quality);
        }

        private void AssertAgedBrieQuality(int expected, int sellIn, int quality)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = sellIn,
                    Quality = quality
                }
            };

            var app = new GildedRose.GildedRose(items);
            app.UpdateQuality();


            Assert.AreEqual(expected, items[0].Quality);
        }

        private void AssertSulfurasQuality(int expected, int sellIn, int quality)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = sellIn,
                    Quality = quality
                }
            };

            var app = new GildedRose.GildedRose(items);
            app.UpdateQuality();


            Assert.AreEqual(expected, items[0].Quality);
        }
    }
}
