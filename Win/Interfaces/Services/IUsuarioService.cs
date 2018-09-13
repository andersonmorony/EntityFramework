using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win.Models;

namespace Win.Interfaces.Services
{
    public interface IUsuarioService
    {
        ApplicationUser GetUser(string id);
        bool UpdateUser(ApplicationUser user);
        void UploadImagem(ImagemPerfil img);
        Task<ImagemPerfil> GetImagemPerfil(int id);
        void saveChanges();
    }
}
