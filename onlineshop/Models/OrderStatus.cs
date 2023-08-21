using System.ComponentModel.DataAnnotations;

namespace onlineshop.Models
{
    public enum OrderStatus
    {
        [Display(Name = "in queue")]
        IN_QUEUE,

        [Display(Name = "moved to delivery")]
        MOVED_TO_DELIVERY,

        [Display(Name = "received")]
        RECEIVED
    }
}