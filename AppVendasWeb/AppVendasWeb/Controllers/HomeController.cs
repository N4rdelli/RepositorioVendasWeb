using AppVendasWeb.Data;
using AppVendasWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace AppVendasWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppVendasContext _context;

        public HomeController(ILogger<HomeController> logger, AppVendasContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IniciarVenda()
        {
            List<Cliente> listaClientes = _context.Cliente.ToList();
            List<Produto> listaProdutos = _context.Produtos.ToList();
            ViewData["ListaClientes"] = listaClientes;
            ViewData["ListaProdutos"] = listaProdutos;
            ViewData["ClienteSelecionado"] = "Nenhum cliente selecionado";
            ViewData["IdSelecionado"] = "Nenhum cliente selecionado";
            return View();
        }

        public IActionResult SelecionaCliente(Guid? id)
        {
            List<Cliente> listaClientes = _context.Cliente.Where(c => c.CadastroAtivo == true).ToList();
            List<Produto> listaProdutos = _context.Produtos.OrderBy(p => p.Descricao).ToList();
            ViewData["ListaClientes"] = listaClientes;
            ViewData["ListaProdutos"] = listaProdutos;
            Cliente cliente = _context.Cliente.FirstOrDefault(c => c.ClienteId == id);
            if (cliente != null)
            {
                ViewData["ClienteSelecionado"] = cliente.ClienteNome;
                ViewData["IdSelecionado"] = cliente.ClienteId;
            }
            return View("IniciarVenda");
        }

        public IActionResult SelecionaProduto(Guid? id)
        {
            List<Cliente> listaClientes = _context.Cliente.Where(c => c.CadastroAtivo == true).ToList();
            List<Produto> listaProdutos = _context.Produtos.OrderBy(p => p.Descricao).ToList();
            ViewData["ListaClientes"] = listaClientes;
            ViewData["ListaProdutos"] = listaProdutos;
            Produto produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto != null)
            {
                ViewData["ProdutoSelecionado"] = produto;
            }
            return View("IniciarVenda");
        }

        [HttpPost]
        public async Task<IActionResult> IniciarVenda([Bind("NovaVendaId,NotaFiscal,DataVenda,ClienteId,TotalProdutos,TotalDesconto,PercentualDesconto,TotalFinal")] NovaVenda novaVenda)
        {
            List<Cliente> listaClientes = _context.Cliente.Where(c => c.CadastroAtivo == true).ToList();
            List<Produto> listaProdutos = _context.Produtos.OrderBy(p => p.Descricao).ToList();
            ViewData["ListaClientes"] = listaClientes;
            ViewData["ListaProdutos"] = listaProdutos;

            if (novaVenda.ClienteId.ToString() == "00000000-0000-0000-0000-000000000000")
            {
                return View("IniciarVenda");
            }

            novaVenda.NovaVendaId = Guid.NewGuid();
            novaVenda.Cliente = _context.Cliente.FirstOrDefault(c => c.ClienteId == novaVenda.ClienteId);
            var ultimaNotaFiscal = _context.NovaVendas.Max(v => v.NotaFiscal);
            if (ultimaNotaFiscal == null)
            {
                ultimaNotaFiscal = 0;
            }
            novaVenda.NotaFiscal = ultimaNotaFiscal + 1;
            _context.Add(novaVenda);
            await _context.SaveChangesAsync();

            return View("IniciarVenda");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //    [HttpPost]
        //    public IActionResult SelecionarCliente(int clienteId)
        //    {
        //        Cliente cliente = _context.Cliente.FirstOrDefault(c => c.Id == clienteId);
        //        if (cliente != null)
        //        {
        //            // Lógica para selecionar o cliente
        //            // Aqui você pode adicionar o código para manipular o cliente selecionado
        //            // Por exemplo, você pode armazenar o cliente selecionado em uma variável de sessão ou em um cookie
        //            // Ou você pode redirecionar para outra página com os detalhes do cliente selecionado
        //        }
        //        return RedirectToAction("IniciarVenda");
        //    }

        //    [HttpPost]
        //    public IActionResult SelecionarProduto(int produtoId)
        //    {
        //        Produto produto = _context.Produtos.FirstOrDefault(p => p.Id == produtoId);
        //        if (produto != null)
        //        {
        //            // Lógica para selecionar o produto
        //        }
        //        return RedirectToAction("IniciarVenda");
        //    }
        //}
    }
}
