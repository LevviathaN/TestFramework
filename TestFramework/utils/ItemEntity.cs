using System;
using System.IO;
using Newtonsoft.Json;

namespace TestFramework.utils
{
    public class ItemEntity
    {
        string title;
        float price;
        string size;
        string type;
        int qty;

        public ItemEntity( string title, float price, int qty, string size, string type)
        {
            this.title = title;
            this.price = price;
            this.qty = qty;
            this.type = type;
            this.size = size;
        }

        public ItemEntity(){}

        public static ItemEntity getItem(string dataFile)
        {
            return JsonConvert.DeserializeObject<ItemEntity>(File.ReadAllText(@"/data/item.json"));
        }
    }
}
