using System.Data.SqlClient;

namespace ForumApi.Models
{
    public abstract class Conexao
    {
        /// <summary>
        /// Objeto utilizado para estabelecer a conexão com o servidor
        /// de banco de dados SQLExpress
        /// </summary>
        protected SqlConnection con = null;
        /// <summary>
        /// Objeto utilizado para executar comandos de SQL, tais como:
        /// select, Udate, Delete,Insert e outros...
        /// </summary>
        protected SqlCommand cmd = null;
        /// <summary>
        /// Objeto utilizado para guardar os retornos do select realizados 
        /// nas tabelas do banco de dados
        /// </summary>
        protected SqlDataReader sdr = null;  

        /// <summary>
        /// o método caminho retorna o local do banco de dados.
        /// </summary>
        /// <returns>Retorna uma string de conexão com o banco</returns>
                
        protected static string Caminho(){  //Caminho pois ele dá o caminho do banco

            //Nome do meu banco de dados é RelCidades. Do professor é Forum
            return @"Data Source=.\sqlExpress;initial catalog=RelCidades;user id=sa;password=senai@123";

        }
        
    }
}