using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CreditaNelas.Models;
using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;

namespace CreditaNelas.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly Context db = new();

        public static string GerarHash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = md5.ComputeHash(bytes);
            StringBuilder result = new();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X"));
            }
            return result.ToString();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuarios model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (db.Usuario.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("Email", "Esse login já está em uso");
                return View(model);
            }

            model.Senha = GerarHash(model.Senha);
            model.ConfirmacaoSenha = GerarHash(model.ConfirmacaoSenha);

            db.Usuario.Add(model);
            db.SaveChanges();

            TempData["Mensagem"] = "Cadastro realizado com sucesso. Efetue login.";

            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuarios viewmodel)
        {

            // Usuário passa a senha e é comparada a hash no Banco de Dados
            viewmodel.Senha = GerarHash(viewmodel.Senha);            

            bool exists = db.Usuario.Any(u => u.Email == viewmodel.Email && u.Senha == viewmodel.Senha);

            // Verifica se a senha e o email no BD e se nenhum campo ficou nul
            if (exists && (viewmodel.Email != null || viewmodel.Senha != null))
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, viewmodel.Email),
                    new Claim("UserName", viewmodel.Email),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties()
                {
                    //AllowRefresh = <bool>,
                };

                await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "E-mail e/ou senha inválidos";
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}