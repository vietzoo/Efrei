using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Refactoring

namespace csharp
{
    public class GildedRose2
    {
        public IList<Item> Items;

        public GildedRose2(IList<Item> items)
        {
            Items = items;
        }

        public const string AgedBrie = "Aged Brie";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
        public const string ConjuredManaCake = "Conjured Mana Cake";

        public const int QualityMax = 50;
        public const int Day10 = 11;
        public const int Day5 = 6;


        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];
                // Conjured implementation
                if (item.Name == ConjuredManaCake)
                {
                    item.SellIn--;

                    if (item.SellIn > 0)
                    {
                        item.Quality = item.Quality - 1; //-2
                    }
                    else
                    {
                        item.Quality = item.Quality - 2; //-4
                    }

                    if (item.Quality < 0)
                    {
                        item.Quality = 0;
                    }
                }
                if (item.Name != AgedBrie && item.Name != Backstage)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != Sulfuras)
                        {
                            item.Quality--;
                        }
                    }
                }
                else
                {
                    if (item.Quality < QualityMax)
                    {
                        item.Quality++;

                        if (item.Name == Backstage)
                        {
                            if (item.SellIn < Day10)
                            {
                                if (item.Quality < QualityMax)
                                {
                                    item.Quality++;
                                }
                            }

                            if (item.SellIn < Day5)
                            {
                                if (item.Quality < QualityMax)
                                {
                                    item.Quality++;
                                }
                            }
                        }
                    }
                }

                if (item.Name != Sulfuras)
                {
                    item.SellIn--;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != AgedBrie)
                    {
                        if (item.Name != Backstage)
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != Sulfuras)
                                {
                                    item.Quality--;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        if (item.Quality < QualityMax)
                        {
                            item.Quality++;
                        }
                    }
                }
            }
        }
    }
}