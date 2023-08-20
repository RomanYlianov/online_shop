using System.Security.Policy;

namespace onlineshop.Services.DTO
{
    public class ProductSearchDTO
    {
        //main parameter
        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string SupplerFirmName { get; set; }

        public double? LowestPrice { get; set; }

        public double? HigestPrice { get; set; }

        public double? LowestRating { get; set; }

        public double? HigestRating { get; set; }


        public bool? IsHot { get; set; }
    }
}
