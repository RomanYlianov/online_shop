using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace onlineshop.Services.DTO
{
    public enum LoginType
    {
        [Display(Name = "nickname")]
        UserName,
        [Display(Name = "email")]
        Email,
        [Display(Name = "phone")]
        PhoneNumber
    }
}
