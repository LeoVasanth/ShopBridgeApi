using System;
using System.Collections.Generic;

#nullable disable

namespace ShopBridgeApi.Models
{
    public partial class Tblitem
    {
        public decimal ItemId { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? Stock { get; set; }
    }
}
