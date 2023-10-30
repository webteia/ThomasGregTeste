using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using ThomasGreg.Business;
using ThomasGreg.Business.Interfaces;
using ThomasGregTeste.Business.Models;

namespace ThomasGregTeste.Controllers
{
    public class LogradouroController : Controller
    {
        public readonly ILogradouroService _logradouroService;
        public LogradouroController(ILogradouroService logradouroService)
        {
            _logradouroService = logradouroService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var novoLogradouro = new LogradouroViewModel();
            return View(novoLogradouro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LogradouroViewModel logradouroNovo)
        {

            if (ModelState.IsValid)
            {
                var msgRetorno = "Erro";
                var clienteId = Regex.Match(Request.Path, @"\d+").Value;
                int id;

                var pode = int.TryParse(clienteId, out id);
                if (pode)
                {
                    logradouroNovo.ClienteId = id;
                    await _logradouroService.InserirComProcedure(logradouroNovo);
                }
                if (logradouroNovo.Validacoes == null)
                {
                    TempData["Message"] = "Cadastro de logradouro efetuado";

                    return RedirectToAction(nameof(Index), "Cliente");
                }
                else
                {
                    ViewBag.Message = $"Cadastro de logradouro não efetuado, o seguinte problema ocorreu: ${logradouroNovo.Validacoes.Errors[0].ErrorMessage}";
                }
            }

            return View(logradouroNovo);
        }
    }
}
