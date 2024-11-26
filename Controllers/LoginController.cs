using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bibliotec.Contexts;
using Bibliotec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bibliotec.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        Context context=> new Context();

        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        
        public IActionResult Logar(IFormCollection form){
            string? emailInformado = form["Email"];
            string? senhaInformada = form["Senha"];
            
            //Busca no Banco de Dados
            Usuario usuarioBuscar = context.Usuario.FirstOrDefault(usuario => usuario.Email == emailInformado && usuario.Senha == senhaInformada)!;

            // De outra forma: 
            //Criei uma lista de Usuario
            List<Usuario> listaUsuario = context.Usuario.ToList();

            // foreach(Usuario usuario_ in listaUsuario){
            //     if(usuario_.Email == emailInformado && usuario_.Senha == senhaInformada) {
            //         //Usuario logado
            //     }else{
            //         //Usuario nao encontrado
            //     }
            // }

            //se meu usuario for igual a nulo
            if(usuarioBuscar == null){
                Console.WriteLine($"Dasos inválidos!😭");
                return LocalRedirect("~/Login");
                
            }else{
                Console.WriteLine($"Eba você entrou!👍");
                HttpContext.Session.SetString("UsuarioID", usuarioBuscar.UsuarioID.ToString());
                HttpContext.Session.SetString("Admin", usuarioBuscar.Admin.ToString());
                return LocalRedirect("~/Livro");
                
            }

        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}