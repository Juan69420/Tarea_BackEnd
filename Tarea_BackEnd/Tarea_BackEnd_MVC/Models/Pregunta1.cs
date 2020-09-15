using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tarea_BackEnd_MVC.Models
{
    public enum Lista
    {
        Universidad = 10,
        Plaza = 20,
        Cine = 30,
        Colegio = 40,
        Hogar = 50
    }
    public class Gianella
    {
        [Key]
        public int gianellaID { get; set; }
        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(24, MinimumLength = 2)]
        public string Friendofgianella { get; set; }
        [Required]
        public Lista Place { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email no valido")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
    }
}