using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Threading.Tasks;
using Unity_Of_Work.Models;
using Unity_Of_Work.Services;
using Unity_Of_Work.Services.Errors;

namespace Unity_Of_Work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : MainController
    {
        private readonly ITelefoneService _telefoneService;
        public TelefoneController(ITelefoneService telefoneService)
        {
            _telefoneService = telefoneService;
        }
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Notificator)),
         SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(UnityOfWorkErrors))]
        public async Task<IActionResult> AdicionarTelefone(TelefoneViewModel enderecoViewModel)
        {
            var result = await _telefoneService.AdicionarTelefone(enderecoViewModel);
            return CustomResponse(result);
        }

        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Notificator)),
        SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(UnityOfWorkErrors))]
        public async Task<IActionResult> DeletarTelefone(TelefoneViewModel enderecoViewModel)
        {
            var result = await _telefoneService.RemoveTelefone(enderecoViewModel);
            return CustomResponse(result);
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Notificator)),
        SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(UnityOfWorkErrors))]
        public async Task<IActionResult> AtualizarEndereco(TelefoneViewModel enderecoViewModel)
        {
            var result = await _telefoneService.AdicionarTelefone(enderecoViewModel);
            return CustomResponse(result);
        }
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Notificator)),
         SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(UnityOfWorkErrors))]
        public async Task<IActionResult> GetAllEnderecos()
        {
            var result = await _telefoneService.GetAllTelefones();
            return CustomResponse(result);
        }

        [HttpGet("{GetEnderecoById}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Notificator)),
         SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(UnityOfWorkErrors))]
        public async Task<IActionResult> GetEnderecoById(int id)
        {
            var result = await _telefoneService.GetTelefoneById(id);
            return CustomResponse(result);
        }
        [HttpGet("{GetEnderecoByClientId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Notificator)),
         SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(UnityOfWorkErrors))]
        public async Task<IActionResult> GetEnderecoByClientId(int clientId)
        {
            var result = await _telefoneService.GetTelefoneByClient(clientId);
            return CustomResponse(result);
        }
    }
}
