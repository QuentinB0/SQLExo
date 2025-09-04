using System;
using System.ComponentModel.DataAnnotations;

namespace SQL_Exo.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "Le contenu est obligatoire")]
        [StringLength(500, ErrorMessage = "Le contenu ne peut pas dépasser {1} caractères")]
        [Display(Name = "Contenu du post")]
        public string Contenu { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le titre est obligatoire")]
        [StringLength(100, ErrorMessage = "Le titre ne peut pas dépasser {1} caractères")]
        [Display(Name = "Titre")]
        public string Titre { get; set; } = string.Empty;

        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; } = DateTime.Now;

        [Display(Name = "Auteur")]
        [StringLength(50, ErrorMessage = "Le nom d'auteur ne peut pas dépasser {1} caractères")]
        public string? Auteur { get; set; }
    }
}