using System.Collections.Generic;
using System.Linq;
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

        /* 
        [HttpGet("{id}")]
        public Usuario Listar(int id){ //para buscar um unico usuário em específio
            return dusuario.ListarUsuario().Where(x => x.Id == id).FirstOrDefault();
            //se ele realmente encontrar o dado ele vai me retornar verdadeiro
        }*/
        [HttpGet("{id}")] //serve para retornar algo quando eu não pasar nada na url
        public IActionResult Listar(int id){ 
            var rs =new JsonResult(dusuario.ListarUsuario().Where(x => x.Id == id).FirstOrDefault());
            rs.ContentType ="application/json";
            if(rs.Value==null){
            rs.StatusCode = 204;
            rs.Value = $"Resultado para id: {id} não retornou dados";
            }
            else{
                rs.StatusCode = 200;
            }
            return Json(rs);
        }

        [HttpPost]
        public void Adicionar([FromBody] Usuario usuario){
            dusuario.Cadastro(usuario);
        }
        
    }
}