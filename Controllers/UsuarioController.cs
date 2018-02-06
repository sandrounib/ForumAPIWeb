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

        /// <summary>
        /// 
        /// Retorna lista de usuários
        /// </summary>
        /// <returns>Lista de usuários</returns>
        /// <response code="200">Retorna o tipo do campo da tabela usuário.</response>
        /// <response code="400">Ocorreu um erro</response>

        [HttpGet]
        [ProducesResponseType(typeof(List<Usuario>),200)]
        [ProducesResponseType(typeof(string),400)]
        public IEnumerable<Usuario> Listar(){
           return dusuario.ListarUsuario();          
        }

        /* 
        [HttpGet("{id}")]
        public Usuario Listar(int id){ //para buscar um unico usuário em específio
            return dusuario.ListarUsuario().Where(x => x.Id == id).FirstOrDefault();
            //se ele realmente encontrar o dado ele vai me retornar verdadeiro
        }*/
        /// <summary>
        /// Busca um usuário pelo seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um usuário</returns>
        /// <response code="200">Retorna um usuário</response>
        /// <response code="400">Ocorreu um erro</response>
        /// <response code="404">Usuário não encontrado</response>
        [HttpGet("{id}")] //serve para retornar algo quando eu não pasar nada na url
        [ProducesResponseType(typeof(Usuario),200)]
        [ProducesResponseType(typeof(string),400)]
        [ProducesResponseType(typeof(string),404)]
        public IActionResult Listar(int id){ 
            var rs =new JsonResult(dusuario.ListarUsuario().Where(x => x.Id == id).FirstOrDefault());
            rs.ContentType ="application/json";
            if(rs.Value==null){
            rs.StatusCode = 404;
            rs.Value = $"Resultado para id: {id} não retornou dados";
            return NotFound(Json(rs));
            }
            else{
                rs.StatusCode = 200;
            }
            return Ok(Json(rs));
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">Novo usuário para registro</param>
        /// <remarks>
        /// Modelo de dados que deve ser enviado para cadastrar o usuário request:
        /// 
        ///     POST /Usuario
        ///     {
        ///         "nome" : "nome do usuario"
        ///     }    
        /// </remarks>
        /// <response code="200">Retorna o usuario cadastrado</response>
        /// <response code="400">Ocorreu um erro</response>

        [HttpPost]
        [ProducesResponseType(typeof(Usuario),200)]
        [ProducesResponseType(typeof(string),400)]
        public void Adicionar([FromBody] Usuario usuario){
            dusuario.Cadastro(usuario);
        }
        
    }
}