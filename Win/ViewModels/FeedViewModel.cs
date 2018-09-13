using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win.Models;

namespace Win.ViewModels
{
    public class FeedViewModel
    {
        public int QuantidadePosts { get; set; }
        public int QuantidadeSeguidores { get; set; }
        public int QuantidadeSeguindo { get; set; }
        public List<PostViewModel> Posts { get; set; }

        public Post SendPost { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser applicationUser { get; set; }

        public string Limit { get; set; } = "1";
        public string Offset { get; set; } = "0";
    }
}
