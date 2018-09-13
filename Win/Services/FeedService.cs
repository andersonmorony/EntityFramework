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
    public class FeedService : IFeedService
    {
        private IPostRepository _postRepository;

        public FeedService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void ComentarPost(Post post)
        {
            try
            {
                post.isComentario = true;

                _postRepository.Comentar(post);
                _postRepository.SaveDbContext();
            }catch(Exception e)
            {
                throw new Exception("Erro, "+ e.Message);
            }
        }

        public void Curtir(Curtida curtida)
        {
            try
            {
                _postRepository.Curtir(curtida);
                _postRepository.SaveDbContext();

            }catch(Exception e)
            {
                throw new Exception("Erro ao Curtir");
            }
        }

        public List<Post> getAllPost(FeedViewModel model)
        {
            return _postRepository.RetornaTodosPosts(model);
        }

        public List<Post> MeusPost(string idUser)
        {
            return _postRepository.RetornarMyPost(idUser);
        }

        public void PublicarPost(Post post, string idUser)
        {
            try
            {
                _postRepository.CriarPost(post);
                _postRepository.SaveDbContext();
            }catch(Exception e)
            {
                throw new Exception("Erro ao Cadastrar Post");
            }
        }

        public Post RetornarCurtidas(int idPost)
        {
            return _postRepository.RetornarCurtidas(idPost);
        }

        public Post RetornarPost(int idPost)
        {
            return _postRepository.RetornarPost(idPost);
        }
        
    }
}
