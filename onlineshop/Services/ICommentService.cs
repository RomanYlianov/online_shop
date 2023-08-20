using onlineshop.Services.DTO;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop.Services
{
    public interface ICommentService
    {

        Task<List<CommentDTO>> GetAll(string productId);

        Task<CommentDTO> GetById(string id);

        Task<CommentDTO> Inicialize(ClaimsPrincipal currentUser, string eqId);

        Task<CommentDTO> Add(ClaimsPrincipal currentUser, string eqId, CommentDTO item);

        Task<CommentDTO> Update(ClaimsPrincipal currentUser, CommentDTO item);

        Task Delete(ClaimsPrincipal currentUser, string id);

    }
}
