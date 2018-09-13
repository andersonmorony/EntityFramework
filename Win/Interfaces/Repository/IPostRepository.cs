using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win.Models;
using Win.ViewModels;

namespace Win.Interfaces.Repository
{
    public interface IPostRepository
    {
        List<Post> RetornaTodosPosts(FeedViewModel model);
        List<Post> RetornarMyPost(string idUser);
        Post RetornarPost(int idPost);
        Post RetornarCurtidas(int idPost);
        void Curtir(Curtida curtida);
        void Comentar(Post post);
        void CriarPost(Post post);
        void SaveDbContext();


    }
}
