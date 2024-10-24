using Microsoft.AspNetCore.Mvc;
using SistemaTesteSoftware.Models;

namespace SistemaTesteSoftware.Controllers
{
    public class AccountController : Controller
    {
        // Exibir a página de login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Processar login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Email == "teste@teste.com.br" && model.Password == "@Teste2024")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Email ou senha inválidos.";
                }
            }

            return View(model);
        }

        // Exibir a página de cadastro
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Processar cadastro
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Simulação de registro no banco de dados ou outro serviço
                // Lógica de salvar os dados do usuário aqui

                // Definir a mensagem de sucesso usando TempData
                TempData["SuccessMessage"] = "Usuário cadastrado com sucesso! Agora você pode fazer login.";

                return RedirectToAction("Login");
            }

            return View(model);
        }
    }

}
