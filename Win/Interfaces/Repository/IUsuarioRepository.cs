using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win.Models;

namespace Win.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        ApplicationUser getUser(string id);
        void UpdateUser(ApplicationUser user);
        bool VerificarEmailExistente(ApplicationUser user);
        void UploadImagem(ImagemPerfil img);
        Task<ImagemPerfil> GetImagemPerfil(int id);
        Task saveChangesAsync();
    }
}
