using onlineshop.Models;
using onlineshop.Services.DTO;

namespace onlineshop.Services.Mapper
{
    public interface IEvaluationQueueMapper
    {
        EvaluationQueue ToEntity(EvaluationQueueDTO dto);

        EvaluationQueueDTO ToDTO(EvaluationQueue entity);
    }
}