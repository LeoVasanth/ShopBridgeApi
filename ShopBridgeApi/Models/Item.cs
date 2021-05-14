using System;
using System.Collections.Generic;

#nullable disable

namespace ShopBridgeApi.Models
{
    public partial class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? Stock { get; set; }
    }
}
