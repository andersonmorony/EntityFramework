using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win.Models;
using Win.ViewModels;

namespace Win.Interfaces.Services
{
    public interface IFeedService
    {
        List<Post> getAllPost(FeedViewModel model);
        List<Post> MeusPost(string idUser);
        Post RetornarPost(int idPost);
        Post RetornarCurtidas(int idPost);
        void PublicarPost(Post post, string idUser);
        void ComentarPost(Post post);
        void Curtir(Curtida curtida);
    }
}
