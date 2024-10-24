using Microsoft.AspNetCore.Mvc;
using SistemaTesteSoftware.Models;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Aqui você deve substituir pelos valores reais
        var viewModel = new UserViewModel
        {
            Username = "Usuário Teste", // ou obter o nome do usuário logado
            TotalUsers = 150,           // substituir pelo total real de usuários
            TotalSales = 20000          // substituir pelo total real de vendas
        };

        return View(viewModel);
    }
}
