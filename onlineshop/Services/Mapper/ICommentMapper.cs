using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using onlineshop.Services.Mapper.Implimentation;

namespace onlineshop.Services.Mapper
{
    public interface ICommentMapper
    {

        CommentDTO ToDTO(Comment entity);

        Comment ToEntity(CommentDTO dto);

    }
}
