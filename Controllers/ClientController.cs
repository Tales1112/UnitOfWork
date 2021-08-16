using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Unity_Of_Work.Models;

namespace Unity_Of_Work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : MainController
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        /// <summary>
        /// Requsição para adicionar clientes na base
        /// </summary>
        /// <param name="clientViewModel"></param>
        /// <returns>retorna true or false</returns>
        [HttpPost]
        public async Task<IActionResult> AdicionarClient([FromBody] ClientViewModel clientViewModel)
        {
            var result = await _clientService.CreateClient(clientViewModel);
            return CustomResponse(result);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoverCliente(ClientViewModel clientViewModel)
        {
            var result = await _clientService.RemoveClient(clientViewModel);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCliente(ClientViewModel clientViewModel)
        {
            var result = await _clientService.UpdateCliente(clientViewModel);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetClienteById([FromQuery] int id)
        {
            var result = await _clientService.GetClientById(id);
            return CustomResponse(result);
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetClienteByName([FromQuery] string nome)
        {
            var result = await _clientService.GetClientByName(nome);
            return CustomResponse(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            var result = await _clientService.GetAllClients();
            return CustomResponse(result);
        }
    }
}
