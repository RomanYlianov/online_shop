using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using onlineshop.Models;
using onlineshop.Services.DTO;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop.Services
{
    public interface IEventService : ICrud<EventDTO, string>
    {        

    }
}
