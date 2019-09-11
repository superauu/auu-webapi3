namespace Auu.Models.View
{
    public class UserItemsResponse
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string SKU { get; set; }
        public string BrandName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string MPN { get; set; }
        public string EAN { get; set; }
        public string UPC { get; set; }
        public string ISBN { get; set; }
        public int Quantity { get; set; }
        public string RRP { get; set; }
        public decimal StandardCost { get; set; }
        public decimal SellingPrice { get; set; }
    }
}