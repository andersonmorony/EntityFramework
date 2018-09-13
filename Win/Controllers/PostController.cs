using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win.Interfaces.Services;
using Win.ViewModels;

namespace Win.Controllers
{
    public class PostController: Controller
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult VisualizarPost(string id)
        {
            var idPost = Convert.ToInt32(id);

            var post = _postService.getPost(idPost);

            PostViewModel newPost = Mapper.Map<PostViewModel>(post);

            newPost.QuantidadeComentario = newPost.Comentarios.Count();
            newPost.QuantidadeCurtida = newPost.Curtida.Count();

            return PartialView("../Home/_Partrial/_RetornarPostPartialView", newPost);


        }
    }
}
