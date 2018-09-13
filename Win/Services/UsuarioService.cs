using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win.Interfaces.Repository;
using Win.Interfaces.Services;
using Win.Models;

namespace Win.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task<ImagemPerfil> GetImagemPerfil(int id)
        {
            return _usuarioRepository.GetImagemPerfil(id);
        }

        public ApplicationUser GetUser(string id)
        {
            return _usuarioRepository.getUser(id);
        }

        public void saveChanges()
        {
            _usuarioRepository.saveChangesAsync();
        }

        public bool UpdateUser(ApplicationUser user)
        {
            try
            {
                _usuarioRepository.UpdateUser(user);

            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }

        public void UploadImagem(ImagemPerfil img)
        {
            _usuarioRepository.UploadImagem(img);
        }
    }
}
