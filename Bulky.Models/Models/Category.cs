﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;

namespace Bulky.Models.Models
{
    public class Category
    {
        [Key]   // will be pk by default
        public int Id { get; set; }
        [Required]
        [MaxLength(30 , ErrorMessage ="Max Length f the Name is 30 letter")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
