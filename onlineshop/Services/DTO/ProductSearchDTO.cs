namespace onlineshop.Services.DTO
{
    public class ProductSearchDTO
    {
   
        public string Name { get; set; }

        public string CategoryId { get; set; }

        public string[] SupplerFirmIds { get; set; }

        public double? LowestPrice { get; set; }

        public double? HigestPrice { get; set; }

        public double? LowestRating { get; set; }

        public double? HigestRating { get; set; }

        public bool? IsHot { get; set; }
    }
}