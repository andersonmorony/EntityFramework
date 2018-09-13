using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win.Interfaces.Services;
using Win.Models;

namespace Win.Controllers
{
    [Authorize]
    public class PerfilController: Controller
    {
        private IPostService _postService;

        public PerfilController(IPostService postService)
        {
            _postService = postService;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
