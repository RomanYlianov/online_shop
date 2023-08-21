using onlineshop.Models;
using onlineshop.Services.DTO;

namespace onlineshop.Services.Mapper
{
    public interface IPaymentMethodMapper
    {
        PaymentMethod ToEntity(PaymentMethodDTO dto);

        PaymentMethod ToEntity(PaymentMethod entity, PaymentMethodDTO dto);

        PaymentMethodDTO ToDTO(PaymentMethod entity);
    }
}