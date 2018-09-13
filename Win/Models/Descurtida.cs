using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win.Models
{
    public class Descurtida
    {
        public int Id { get; set; }
        public DateTime DataCurtida { get; set; }
        public string applicationUserId { get; set; }
        [ForeignKey("applicationUserId")]
        public ApplicationUser applicationUser { get; set; }

        public int? postId { get; set; }
        [ForeignKey("postId")]
        public Post Post { get; set; }
    }
}
