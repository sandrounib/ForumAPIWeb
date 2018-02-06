using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ForumApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();            

            //Metodo para usar a documentação Swagger
            // para mostrar de o dotnet run e abra o browser com
            //http://localhost:5000/swagger/
            services.AddSwaggerGen(c =>{
                c.SwaggerDoc("V1",new Info{
                    Version = "V1",
                    Title = "ApiForumApi",
                    Description = "Documentação da Api do Forum Api",
                    TermsOfService = "None",
                    Contact =  new Contact {
                    Name = "Sandro Reis",
                    Email = "sandrounib@hotmail.com",
                    Url = "http://www.corujasdev.com.br"
                    } 
                }); 

                //codigo para usar a documentação da api que foi colocado ///
                var caminhoBase = AppContext.BaseDirectory;
                var caminhoXml =  Path.Combine(caminhoBase,"ApiForumApi.xml");

                c.IncludeXmlComments(caminhoXml);           
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Usado para documentação swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>{
                c.SwaggerEndpoint("/swagger/V1/swagger.json","ApidoForumApi");
            });
            
            app.UseMvc();

            
        }
    }
}
