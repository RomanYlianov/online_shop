using onlineshop.Models;
using onlineshop.Services.DTO;

namespace onlineshop.Services.Mapper
{
    public interface IEvaluationQueueMapper
    {

        EvaluationQueueDTO ToDTO(EvaluationQueue entity);
        
        EvaluationQueue ToEntity(EvaluationQueueDTO dto);

    }
}
