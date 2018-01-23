using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ForumApi.Models
{
    public class DaoUsuario : Conexao
    {
        public bool Cadastro(Usuario usuario){
            bool retorno = false;
            try{
                con = new SqlConnection();
                cmd = new SqlCommand();
                string inserir = "insert into usuario(nome,login,senha)"+
                    "values(@n,@l,@s)";
                cmd.Parameters.AddWithValue("@n",usuario.Nome);
                cmd.Parameters.AddWithValue("@l",usuario.Login);
                cmd.Parameters.AddWithValue("@s",usuario.Senha);
                //data de cadastro é automático não precisa
                
                con.ConnectionString=Caminho();
                con.Open();
                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = inserir;

                int rs = cmd.ExecuteNonQuery();

                if(rs > 0 )
                    retorno = true;  
                
            }
            catch(SqlException se){
                throw new Exception("Erro ao tentar cadastrar ->"+se.Message);

            }
            catch(Exception e){
                throw new Exception("Erro inesperado -> "+e.Message);
                
            }
            finally{
            con.Close();
        }
        return retorno;            
        } 


            public bool Atualizar(Usuario usuario){
            bool retorno = false;
            try{
                con = new SqlConnection();
                cmd = new SqlCommand();
                string atualizar = "update usuario set nome=@n,login=@l,senha=@s,"+
                    "dataCadastro=@d where id=@id";
                cmd.Parameters.AddWithValue("@n",usuario.Nome);
                cmd.Parameters.AddWithValue("@l",usuario.Login);
                cmd.Parameters.AddWithValue("@s",usuario.Senha);
                cmd.Parameters.AddWithValue("@d",DateTime.Now);//note que aqui eu acrescentei a data
                //lá em cima no cadastro eu não coloquei
                //pois quero saber a data e hora toda vez que eu atualizar. Parando no datetime.now 
                //fica iguar ao do banco
                cmd.Parameters.AddWithValue("@id",usuario.Id); //acrescentei tambem o id
                
                con.ConnectionString=Caminho();
                con.Open();
                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = atualizar;

                int rs = cmd.ExecuteNonQuery();

                if(rs > 0 )
                    retorno = true;  
                
            }
            catch(SqlException se){
                throw new Exception("Erro ao tentar atualizar ->"+se.Message);

            }
            catch(Exception e){
                throw new Exception("Erro inesperado -> "+e.Message);
                
            }
            finally{
            con.Close();
        }
        return retorno;            
        }  


         public bool Apagar(int id){ // para apagar eu não preciso do objeto inteiro só int id
            bool retorno = false;
            try{
                con = new SqlConnection();
                cmd = new SqlCommand();
                string apagar = "delete from usuario where id=@id";                
                cmd.Parameters.AddWithValue("@id",id); //SÓ PRECISO DE UM PARAMETRO
                
                con.ConnectionString=Caminho();
                con.Open();
                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = apagar;

                int rs = cmd.ExecuteNonQuery();

                if(rs > 0 )
                    retorno = true;  
                
            }
            catch(SqlException se){
                throw new Exception("Erro ao tentar apagar ->"+se.Message);

            }
            catch(Exception e){
                throw new Exception("Erro inesperado -> "+e.Message);
                
            }
            finally{
            con.Close();
        }
        return retorno;            
        }  

        public List<Usuario> ListarUsuario(){
            List<Usuario> LstUsuario = new List<Usuario>();            

            try{
                con = new SqlConnection(Caminho());
                con.Open();
                cmd= new SqlCommand("Select * from usuario",con);
                sdr = cmd.ExecuteReader();

                while(sdr.Read()){
                    LstUsuario.Add(new Usuario(){
                        Id = sdr.GetInt32(0),
                        Nome = sdr.GetString(1),
                        Login= sdr.GetString(2),
                        Senha = sdr.GetString(3),
                        DataCadastro =sdr.GetDateTime(4)
                    });//fim do Add
                }//Fim do While
            }//Chave do Try
            catch(SqlException se){
                throw new Exception("Erro ao tentar ler a tabela usuário ->"+se.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado ->"+ex.Message);
            }
            finally{
                con.Close();
            }
            return LstUsuario;
        }   
    
    }
}