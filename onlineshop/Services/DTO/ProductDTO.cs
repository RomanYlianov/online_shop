﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace onlineshop.Services.DTO
{
    public class ProductDTO
    {
        public string Id { get; set; }

        public string Cipher { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Name must be between 10 and 100")]
        public string Name { get; set; }

        [Display(Name = "category")]
        [Required(ErrorMessage = "CategoryDTO is requres")]
        public CategoryDTO CategoryDTO { get; set; }


        [Required(ErrorMessage = "CategoryDTOId is required")]
        //[Range(1, int.MaxValue, ErrorMessage = "CategoryDTOId must be positive")]
        public string CategoryDTOId { get; set; }

        [Display(Name = "suppler firm")]
        [Required(ErrorMessage = "SupplerFirmDTO is required")]
        public SupplerFirmDTO SupplerFirmDTO { get; set; }

        [Required(ErrorMessage = "SupperFirmDTOId is required")]
        //[Range(1, int.MaxValue, ErrorMessage = "SupplerFirmDTOId must be positive")]
        public string SupplerFirmDTOId { get; set; }

        [Required(ErrorMessage = "CountAll is required")]
        [Range(0, int.MaxValue, ErrorMessage = "CountAll must be positive or zero")]
        public int CountAll { get; set; }

        [Required(ErrorMessage = "CountThis is required")]
        [Range(0, int.MaxValue, ErrorMessage = "CountThis must be positive or zero")]
        public int CountThis { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be positive or zero")]
        public double Price { get; set; }

        //[Required(ErrorMessage = "Rating is required")]
        //[Range(0, 10, ErrorMessage = "Rating must be positive or zero")]
        public double Rating { get; set; }

        [Required(ErrorMessage = "IsHot is required")]
        public bool IsHot { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 100")]
        public string Description { get; set; }

        public List<OrderDTO> OrderDTOs { get; set; }

    }
}
