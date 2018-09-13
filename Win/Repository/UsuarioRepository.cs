using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win.Data;
using Win.Interfaces.Repository;
using Win.Models;

namespace Win.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private ApplicationDbContext _dbContext;

        public UsuarioRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ImagemPerfil> GetImagemPerfil(int id)
        {
            return _dbContext.ImagemPerfils.FirstOrDefault(i => i.Id == id);
        }

        public ApplicationUser getUser(string id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public async Task saveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void UpdateUser(ApplicationUser user)
        {
            if(VerificarEmailExistente(user))
            {
                throw new Exception("Falha, Email indisponivel");
            }

            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public void UploadImagem(ImagemPerfil img)
        {
            _dbContext.ImagemPerfils.Add(img);
            _dbContext.SaveChanges();
        }

        public bool VerificarEmailExistente(ApplicationUser user)
        {
            var usuario = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);

            if(usuario != null)
            {
                return true;
            }

            return false;
        }
    }
}
