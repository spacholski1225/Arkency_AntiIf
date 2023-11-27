using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                if (IsSulfuras(i))
                {
                }
                else if (IsGeneric(i))
                {
                    HandleGeneric(i);
                }
                else if (IsAgedBrie(i))
                {
                    HandleAgedBrie(i);
                }
                else if (IsBackstagePass(i))
                {
                    HandleBackstagePass(i);
                }
            }
        }

        private void HandleGeneric(int i)
        {
            if (_items[i].Quality > 0)
            {
                DecreaseQuality(i);
            }

            DecreaseSellIn(i);

            if (_items[i].SellIn < 0)
            {
                if (_items[i].Quality > 0)
                {
                    DecreaseQuality(i);
                }
            }
        }

        private void HandleAgedBrie(int i)
        {
            if (IsQualityLessThan50(i))
            {
                IncreaseQuality(i);
            }

            DecreaseSellIn(i);

            if (_items[i].SellIn < 0)
            {
                if (IsQualityLessThan50(i))
                {
                    IncreaseQuality(i);
                }
            }
        }

        private void HandleBackstagePass(int i)
        {
            if (IsQualityLessThan50(i))
            {
                IncreaseQuality(i);
                if (_items[i].SellIn < 11)
                {
                    if (IsQualityLessThan50(i))
                    {
                        IncreaseQuality(i);
                    }
                }

                if (_items[i].SellIn < 6)
                {
                    if (IsQualityLessThan50(i))
                    {
                        IncreaseQuality(i);
                    }
                }
            }

            DecreaseSellIn(i);

            if (_items[i].SellIn < 0)
            {
                _items[i].Quality = _items[i].Quality - _items[i].Quality;
            }
        }

        private bool IsGeneric(int i)
        {
            return !(IsSulfuras(i) || IsBackstagePass(i) || IsAgedBrie(i));
        }

        private bool IsSulfuras(int i)
        {
            return _items[i].Name == "Sulfuras, Hand of Ragnaros";
        }

        private bool IsBackstagePass(int i)
        {
            return _items[i].Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool IsAgedBrie(int i)
        {
            return _items[i].Name == "Aged Brie";
        }

        private bool IsQualityLessThan50(int i)
        {
            return _items[i].Quality < 50;
        }

        private void DecreaseSellIn(int i)
        {
            _items[i].SellIn = _items[i].SellIn - 1;
        }

        private void IncreaseQuality(int i)
        {
            _items[i].Quality = _items[i].Quality + 1;
        }

        private void DecreaseQuality(int i)
        {
            _items[i].Quality = _items[i].Quality - 1;
        }
    }
}
