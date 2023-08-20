using onlineshop.Services.DTO;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop.Services
{
    public interface IEvaluationQueueService 
    {

        Task<List<EvaluationQueueDTO>> GetAll(ClaimsPrincipal currentUser);

        Task<EvaluationQueueDTO> GetById(ClaimsPrincipal currentUser, string id);

    }
}
