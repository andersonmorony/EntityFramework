using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Win.Models
{
    public class Curtida
    {
        public static object DataTime { get; private set; }
        public int Id { get; set; }
        public DateTime DataCurtida { get; set; } = DateTime.Now;
        public string applicationUserId { get; set; }
        [ForeignKey("applicationUserId")]
        public ApplicationUser applicationUser { get; set; }

        public int postId { get; set; }
        [ForeignKey("postId")]
        public Post Post { get; set; }
    }
}
