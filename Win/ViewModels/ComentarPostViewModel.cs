using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win.Models;

namespace Win.ViewModels
{
    public class ComentarPostViewModel
    {
        public int IdPost { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        public string Video { get; set; }
        public int Curtida { get; set; }
        public int Discurtida { get; set; }
        public DateTime DataPublicacao { get; set; } = DateTime.Now;
        public List<Tag> Tags { get; set; }
    }
}
