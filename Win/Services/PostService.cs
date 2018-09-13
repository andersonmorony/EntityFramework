using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win.Interfaces.Repository;
using Win.Interfaces.Services;
using Win.Models;
using Win.ViewModels;

namespace Win.Services
{
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public Post getPost(int idPost)
        {
            return _postRepository.RetornarPost(idPost);
        }

        public List<Post> PostsPorUsuario(FeedViewModel model)
        {
            return _postRepository.RetornaTodosPosts(model);
        }
    }
}
