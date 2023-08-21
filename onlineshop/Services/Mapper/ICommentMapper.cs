using onlineshop.Models;
using onlineshop.Services.DTO;

namespace onlineshop.Services.Mapper
{
    public interface ICommentMapper
    {
        CommentDTO ToDTO(Comment entity);

        Comment ToEntity(CommentDTO dto);
    }
}