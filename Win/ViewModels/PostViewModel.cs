﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win.Models;

namespace Win.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        public string Video { get; set; }
        public ICollection<Curtida> Curtida { get; set; }
        public ICollection<Descurtida> Descurtidas { get; set; }
        public DateTime DataPublicacao { get; set; } = DateTime.Now;
        public List<Tag> Tags { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser applicationUser { get; set; }

        public int? PostId { get; set; }
        [ForeignKey("PostId")]
        public List<Post> Comentarios { get; set; }



        public int QuantidadeCurtida { get; set; }
        public int QuantidadeComentario { get; set; }
    }
}
