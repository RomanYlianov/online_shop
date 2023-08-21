using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using System;

namespace onlineshop.Services.Mapper.Implimentation
{
    public class CommentMapperImpl : ICommentMapper
    {
        private readonly IProductMapper PMapper;

        private readonly IUserMapper UMapper;

        private readonly ILogger logger;

        public CommentMapperImpl(IProductMapper pMapper, IUserMapper uMapper)
        {
            this.PMapper = pMapper;
            this.UMapper = uMapper;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<CategoryMapperImpl>();
        }

        public Comment ToEntity(CommentDTO dto)
        {
            logger.LogInformation(GetType().Name + " : convert DTO to entity");

            Comment entity = new Comment();

            try
            {
                if (dto != null)
                {
                    if (dto.Id != null)
                    {
                        entity.Id = Guid.Parse(dto.Id);
                    }

                    if (dto.Title != null)
                    {
                        entity.Title = dto.Title;
                    }

                    if (dto.AuthorDTO != null)
                    {
                        entity.Author = UMapper.ToEntity(dto.AuthorDTO);
                    }

                    if (dto.AuthorDTOId != null)
                    {
                        entity.AuthorId = Guid.Parse(dto.AuthorDTOId);
                    }

                    if (dto.ProductDTO != null)
                    {
                        entity.Product = PMapper.ToEntity(dto.ProductDTO);
                    }

                    if (dto.ProductDTOId != null)
                    {
                        entity.ProductId = Guid.Parse(dto.ProductDTOId);
                    }

                    if (dto.Text != null)
                    {
                        entity.Text = dto.Text;
                    }

                    if (dto.CreationTime != null)
                    {
                        entity.CreationTime = dto.CreationTime;
                    }

                    if (dto.ModificationTime != null)
                    {
                        entity.ModificationTime = dto.ModificationTime.Value;
                    }
                }
            }
            catch (FormatException ex)
            {
                logger.LogError(GetType().Name + " : convert failed : " + ex.Message);
            }

            return entity;
        }

        public CommentDTO ToDTO(Comment entity)
        {
            logger.LogInformation(GetType().Name + " : create entity to DTO");

            CommentDTO dto = new CommentDTO();

            if (entity != null)
            {
                if (entity.Id != null)
                {
                    dto.Id = entity.Id.ToString();
                }

                if (entity.Title != null)
                {
                    dto.Title = entity.Title;
                }

                if (entity.Author != null)
                {
                    dto.AuthorDTO = UMapper.ToDTO(entity.Author);
                }

                if (entity.AuthorId != null)
                {
                    dto.AuthorDTOId = entity.AuthorId.Value.ToString();
                }

                if (entity.Product != null)
                {
                    dto.ProductDTO = PMapper.ToDTO(entity.Product);
                }

                if (entity.ProductId != null)
                {
                    dto.ProductDTOId = entity.ProductId.ToString();
                }

                if (entity.Text != null)
                {
                    dto.Text = entity.Text;
                }

                if (entity.CreationTime != null)
                {
                    dto.CreationTime = entity.CreationTime;
                }

                if (entity.ModificationTime != null)
                {
                    dto.ModificationTime = entity.ModificationTime.Value;
                }
            }

            return dto;
        }
    }
}