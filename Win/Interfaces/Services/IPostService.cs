using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win.Models;
using Win.ViewModels;

namespace Win.Interfaces.Services
{
    public interface IPostService
    {
        Post getPost(int idPost);
        List<Post> PostsPorUsuario(FeedViewModel model);
    }
}
