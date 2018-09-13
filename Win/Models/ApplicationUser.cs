using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Win.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MinLength(3)]
        public string Nome { get; set; }
        [Required]
        [MinLength(3)]
        public string Sobrenome { get; set; }
        public List<Post> MeusPosts { get; set; }
        public List<ImagemPerfil> ImagemPerfil { get; set; }

    }
}
