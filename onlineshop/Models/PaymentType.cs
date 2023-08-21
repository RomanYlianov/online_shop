using System.ComponentModel.DataAnnotations;

namespace onlineshop.Models
{
    public enum PaymentType
    {
        [Display(Name = "bank card")]
        BANK_CARD,

        [Display(Name = "qiwi")]
        QIWI,

        [Display(Name = "webmoney")]
        WEBMONEY
    }
}