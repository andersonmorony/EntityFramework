using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win.Data;
using Win.Interfaces.Repository;
using Win.Models;
using Win.ViewModels;

namespace Win.Repository
{
    public class PostRepository : IPostRepository
    {
        private ApplicationDbContext _dbContext;

        public PostRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public void CriarPost(Post post)
        {
            _dbContext.Posts.Add(post);
        }

        public Post RetornarPost(int idPost)
        {
            var post =  _dbContext.Posts
                .Include(c => c.Comentarios)
                    .ThenInclude(c => c.applicationUser)
                .Include(c => c.Comentarios)
                    .ThenInclude(c => c.Comentarios)
                .Include(c => c.Comentarios)
                    .ThenInclude(c => c.Curtida)
                .Include(c => c.Curtida)
                .Include(u => u.applicationUser)
                .FirstOrDefault(p => p.Id == idPost);

            return post;
        }

        public List<Post> RetornarMyPost(string idUser)
        {
            return _dbContext.Posts
                .Include(c => c.Comentarios)
                    .ThenInclude(c => c.applicationUser)
                .Include(u => u.applicationUser)
                .Where(p => p.ApplicationUserId == idUser)
                .OrderByDescending(p => p.DataPublicacao).ToList();
        }

        public List<Post> RetornaTodosPosts(FeedViewModel model)
        {
            var quantidadePosts = _dbContext.Posts.Where(p => p.isComentario == false).Count();
            var pageSize = 10;

            var page = Convert.ToInt32(model.Limit);

            var skip = pageSize * (page - 1);

            var canPage = skip < quantidadePosts;
            if (canPage)
            {
                if(model.ApplicationUserId != null)
                {
                    return _dbContext.Posts
                    .Include(c => c.Comentarios)
                        .ThenInclude(c => c.applicationUser)
                    .Include(curtida => curtida.Curtida)
                    .Include(u => u.applicationUser)
                    .OrderByDescending(p => p.DataPublicacao)
                    .Where(c => c.isComentario == false && c.ApplicationUserId == model.ApplicationUserId)
                    .Skip(skip)
                    .Take(pageSize)
                    .ToList();
                }
                else
                {
                    return _dbContext.Posts
                    .Include(c => c.Comentarios)
                        .ThenInclude(c => c.applicationUser)
                    .Include(curtida => curtida.Curtida)
                    .Include(u => u.applicationUser)
                    .OrderByDescending(p => p.DataPublicacao)
                    .Where(c => c.isComentario == false)
                    .Skip(skip)
                    .Take(pageSize)
                    .ToList();
                }
            }
            return new List<Post>();

        }
        public void SaveDbContext()
        {
            _dbContext.SaveChanges();
        }

        public void Comentar(Post post)
        {
            var postRelacionado = _dbContext.Posts.FirstOrDefault(p => p.Id == post.PostId);

            if(postRelacionado != null)
            {
                CriarPost(post);
            }
        }

        public Post RetornarCurtidas(int idPost)
        {
            return _dbContext.Posts
                .Include(curtida => curtida.Curtida)
                    .ThenInclude(c => c.applicationUser)
                .FirstOrDefault(p => p.Id == idPost);
        }

        public void Curtir(Curtida curtida)
        {
            var postRelacionado = _dbContext.Posts.FirstOrDefault(p => p.Id == curtida.postId);
            if(postRelacionado != null)
            {
                var curtidaRelacionada = _dbContext.Curtidas.FirstOrDefault(c => c.postId == curtida.postId && c.applicationUserId == curtida.applicationUserId);

                if (curtidaRelacionada == null)
                {
                    _dbContext.Curtidas.Add(curtida);

                }
                else
                {
                    _dbContext.Curtidas.Remove(curtidaRelacionada);
                }
            }



        }
    }
    
}
