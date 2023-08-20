﻿using Microsoft.Extensions.Logging;
using onlineshop.Models;
using onlineshop.Services.DTO;
using System;
using System.Security.Cryptography.Xml;

namespace onlineshop.Services.Mapper.Implimentation
{
    public class ProductMapperImpl : IProductMapper
    {

        private readonly ICategoryMapper CtMapper;

        private readonly ISupperFirmMapper SFMapper;

        private readonly ILogger logger;

        public ProductMapperImpl(ICategoryMapper CtMapper, ISupperFirmMapper SFMapper)
        {
            this.CtMapper = CtMapper;
            this.SFMapper = SFMapper;

            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<ProductMapperImpl>();
        }

        public ProductDTO ToDTO(Product entity)
        {
           
            logger.LogInformation(GetType().Name + " : convert entity to DTO");

            ProductDTO dto = new ProductDTO();

            if (entity != null)
            {

                if (entity.Id != null)
                {
                    dto.Id = entity.Id.ToString();
                }

                if (entity.Cipher != null)
                {
                    dto.Cipher = entity.Cipher;
                }

                if (entity.Name != null)
                {
                    dto.Name = entity.Name;
                }

                if (entity.Category != null)
                {
                    dto.CategoryDTO = CtMapper.ToDTO(entity.Category);
                }

                if (entity.CategoryId != null)
                {
                    dto.CategoryDTOId = entity.CategoryId.ToString();
                }

                if (entity.SupplerFirm != null)
                {
                    dto.SupplerFirmDTO = SFMapper.ToDTO(entity.SupplerFirm);
                }

                if (entity.SupplerFirmId != null)
                {
                    dto.SupplerFirmDTOId = entity.SupplerFirmId.ToString();
                }

                if (entity.CountAll > 0)
                {
                    dto.CountAll = entity.CountAll;
                }

                if (entity.CountThis > 0)
                {
                    dto.CountThis = entity.CountThis;
                }

                if (entity.Price > 0)
                {
                    dto.Price = entity.Price;
                }
                
                if (entity.Rating > 0 && entity.Rating <= 10)
                {
                    dto.Rating = entity.Rating;
                }

                dto.IsHot = entity.IsHot;

                if (entity.Description!=null)
                {
                    dto.Description = entity.Description;
                }

            }

            return dto;
        }

        public Product ToEntity(ProductDTO dto)
        {
         
            logger.LogInformation(GetType().Name + " : convert DTO to entity");

            Product entity = new Product();

            try
            {
                if (dto != null)
                {

                    if (dto.Id != null)
                    {
                        entity.Id = Guid.Parse(dto.Id);
                    }

                    if (dto.Cipher != null)
                    {
                        entity.Cipher = dto.Cipher;
                    }

                    if (dto.Name != null)
                    {
                        entity.Name = dto.Name;
                    }

                    if (dto.CategoryDTO != null)
                    {
                        entity.Category = CtMapper.ToEntity(dto.CategoryDTO);
                    }

                    if (dto.CategoryDTOId != null)
                    {
                        entity.CategoryId = Guid.Parse(dto.CategoryDTOId);
                    }

                    if (dto.SupplerFirmDTO != null)
                    {
                        entity.SupplerFirm = SFMapper.ToEntity(dto.SupplerFirmDTO);
                    }

                    if (dto.SupplerFirmDTOId != null)
                    {
                        entity.SupplerFirmId = Guid.Parse(dto.SupplerFirmDTOId);
                    }

                    if (dto.CountAll > 0)
                    {
                        entity.CountAll = dto.CountAll;
                    }

                    if (dto.CountThis > 0)
                    {
                        entity.CountThis = dto.CountThis;
                    }

                    if (dto.Price > 0)
                    {
                        entity.Price = dto.Price;
                    }

                    if (dto.Rating > 0 && dto.Rating <= 10)
                    {
                        entity.Rating = dto.Rating;
                    }

                    entity.IsHot = dto.IsHot;

                    if (dto.Description != null)
                    {
                        entity.Description = dto.Description;
                    }

                }
            }
            catch (FormatException ex)
            {
                logger.LogError(GetType().Name + " : convert failed : " + ex.Message);
            }

            return entity;
        }
    }
}
