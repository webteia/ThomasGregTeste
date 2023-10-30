using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using ThomasGreg.Business.Interfaces;
using ThomasGreg.Business.ViewModels;
using ThomasGregTeste.Business.Models;
using ThomasGregTeste.Models;

namespace ThomasGregTeste.Controllers
{
    public class ClienteController : Controller
    {
        public readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;   
        }
        public IActionResult Index()
        {
            //GridModelList glm = new GridModelList();
            //List<GridModel> gl = new List<GridModel>();
            //GridModel gm;
            var todosOsClientes = _clienteService.CarregarTodosOsClientes();
            //todosOsClientes.ForEach(x => {
            //    gm = new GridModel();
            //    gm.Id = x.Id;
            //    gm.Nome = x.Nome;
            //    gm.Email = x.Email;
            //    gl.Add(gm);
            //});
            //glm.GridData = gl;

            return View(todosOsClientes);
        }
        public IActionResult Create()
        {
            var novoCliente = new ClienteViewModel();
            return View(novoCliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteNovo)
        {

            if (ModelState.IsValid)
            {
                var msgRetorno = "Erro";

                if (clienteNovo.FormFile != null && clienteNovo.FormFile.Length > 0)
                {
                    var guidName = Guid.NewGuid().ToString();
                    var fileName = guidName + Path.GetFileName(clienteNovo.FormFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/logos", fileName);
                    clienteNovo.Logotipo = filePath;

                    using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                    {
                        await clienteNovo.FormFile.CopyToAsync(fileSrteam);
                    }
                }
                else
                {
                    clienteNovo.Logotipo = "";
                }

                await _clienteService.CriarCliente(clienteNovo);
                if (clienteNovo.Validacoes.Errors.Count == 0)
                {
                    TempData["Message"] = "Cadastro de cliente efetuado";

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = $"Cadastro de cliente não efetuado, o seguinte problema ocorreu: ${clienteNovo.Validacoes.Errors[0].ErrorMessage}";
                }
            }

            return View(clienteNovo);
        }


        public async Task<IActionResult> Update(ClienteViewModel cliente)
        {
            var todosOsClientes = _clienteService.CarregarTodosOsClientes();
            return View(todosOsClientes);
        }

        public async Task<IActionResult> Details()
        {
            ClienteViewModel cliente = new ClienteViewModel();
            var clienteId = Regex.Match(Request.Path, @"\d+").Value;
            int id;

            var pode =  int.TryParse(clienteId, out id);
            if (pode)
            {
                cliente = _clienteService.ObterPorId(id);
                cliente.Logotipo = cliente.Logotipo.Substring(cliente.Logotipo.IndexOf('/')).Replace("\\", "/");
            }
            return View(cliente);
        }

        public async Task<IActionResult> Delete(int clienteId)
        {
            var todosOsClientes = _clienteService.CarregarTodosOsClientes();
            return View(todosOsClientes);
        }
    }
}
