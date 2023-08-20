using onlineshop.Models;
using onlineshop.Services.DTO;

namespace onlineshop.Services.Mapper
{
    public interface IPaymentMethodMapper
    {

        PaymentMethodDTO ToDTO(PaymentMethod entity);

        PaymentMethod ToEntity(PaymentMethodDTO dto);

        PaymentMethod ToEntity(PaymentMethod entity, PaymentMethodDTO dto);

    }
}
