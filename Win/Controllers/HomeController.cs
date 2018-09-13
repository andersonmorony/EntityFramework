using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Win.Interfaces.Services;
using Win.Models;
using Win.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Web;
using System;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Win.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IFeedService _feedService;

        public HomeController(IFeedService feedService)
        {
            _feedService = feedService;
        }
        public IActionResult Index()
        {

            var feed = MontarViewModel();
            
            return View(feed);
        }


        [HttpPost]
        public async Task<IActionResult> Postar(FeedViewModel modal , IFormFile file )
        {
            var idUsuario = User.Identity.GetUserId();


            if (file != null)
            {
                
                modal.SendPost.Imagem = UploadArquivo(file).ToString();
            }

            modal.SendPost.ApplicationUserId = idUsuario;
            _feedService.PublicarPost(modal.SendPost, idUsuario);

            

            var feed = MontarViewModel();
            return View("Index", feed);

            //return Json(new { mensagem = "Cadastrado com Sucesso!", Code = 204 });

        }

        [HttpGet]
        [Route("/Home/AtualizarComentario/{id}")]
        public PartialViewResult  AtualizarComentario(string id)
        {
            var idPost = Convert.ToInt32(id);

            var retorno = _feedService.RetornarPost(idPost);
            
            
            var newRetorno = Mapper.Map<PostViewModel>(retorno);
                                    
            return PartialView("../Home/_Partrial/_ComentarioPartialView", newRetorno);
        }

        [HttpGet]
        public IActionResult QuantidadeComentarioAtualizar(string id)
        {
            var idPost = Convert.ToInt32(id);

            var retorno = _feedService.RetornarPost(idPost);

            var quantidade = retorno.Comentarios.Count();

            return Ok(quantidade);
        }

        [HttpPost]
        public IActionResult Comentar(PostViewModel model)
        {

            var idUsuario = User.Identity.GetUserId();
            model.ApplicationUserId = idUsuario;

            var newModel = Mapper.Map<Post>(model);

            try
            {
                _feedService.ComentarPost(newModel);
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            
            

            return AtualizarComentario(newModel.PostId.ToString());

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private FeedViewModel MontarViewModel()
        {
            var idUsuario = User.Identity.GetUserId();

            var model = new FeedViewModel();

            var post = _feedService.getAllPost(model);
            var meusPosts = _feedService.MeusPost(idUsuario);
            var newPost = Mapper.Map<List<PostViewModel>>(post);
            
            foreach(var item in newPost)
            {
                item.QuantidadeComentario = item.Comentarios.Count();
                item.QuantidadeCurtida = item.Curtida.Count();
            }

            
            var feed = new FeedViewModel()
            {
                
                QuantidadePosts = meusPosts.Count(),
                QuantidadeSeguidores = 100,
                QuantidadeSeguindo = 329,
                Posts = newPost
            };

            return feed;
            
        }

        private async Task<string>UploadArquivo(IFormFile file)
        {
            var tempoAtual = DateTime.Now;
            var saltImg = String.Format("{0:yyyyMMdd-HHmmssfff}", DateTime.Now);
            var fileName = string.Concat(saltImg, file.FileName);
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/uploads/imagens/posts",
                        fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;

        }

        [HttpPost]
        public IActionResult Curtir(string id)
        {
            int idPost = Convert.ToInt32(id);

            var curtida = new Curtida()
            {
                applicationUserId = User.Identity.GetUserId(),
                postId = idPost
            };

            try
            {
                _feedService.Curtir(curtida);

            }catch(Exception e)
            {
                return StatusCode(404, e.Message);
            }

            var retorno = _feedService.RetornarCurtidas(idPost);
            var quantidade = retorno.Curtida.Count();
            return Ok(quantidade);
        }

        [HttpGet]
        public IActionResult CarregarFeed(FeedViewModel model)
        {
                      
            var posts = _feedService.getAllPost(model);

            if (posts.Count() == 0)
            {
                return BadRequest("no posts");
            }

            var newPosts = Mapper.Map<List<PostViewModel>>(posts);

            var newRotorno = new FeedViewModel()
            {
                Posts = newPosts,

            };

            foreach (var item in newRotorno.Posts)
            {
                item.QuantidadeComentario = item.Comentarios.Count();
                item.QuantidadeCurtida = item.Curtida.Count();
            }

            return PartialView("../Home/_Partrial/_RecarregarPostPartialView", newRotorno);
            
        }


    }
}
