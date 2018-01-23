using System.Collections.Generic;
using ForumApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApi.Controllers
{
    [Route("usuario")]
    public class UsuarioController: Controller    
    {

        DaoUsuario dusuario = new DaoUsuario();

        [HttpGet]
        public IEnumerable<Usuario> Listar(){
           return dusuario.ListarUsuario();          
        }

        [HttpPost]
        public void Adicionar([FromBody] Usuario usuario){
            dusuario.Cadastro(usuario);
        }
        
    }
}