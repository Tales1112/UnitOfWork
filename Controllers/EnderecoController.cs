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
    public class EnderecoController : MainController
    {
        private readonly IEnderecoService _enderecoService;
        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Notificator)),
         SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(UnityOfWorkErrors))]
        public async Task<IActionResult> AdicionarEndereco(EnderecoViewModel enderecoViewModel)
        {
            var result = await _enderecoService.AddEndereco(enderecoViewModel);
            return CustomResponse(result);
        }

        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Notificator)),
        SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(UnityOfWorkErrors))]
        public async Task<IActionResult> DeletarEndereco(EnderecoViewModel enderecoViewModel)
        {
            var result = await _enderecoService.AddEndereco(enderecoViewModel);
            return CustomResponse(result);
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Notificator)),
        SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(UnityOfWorkErrors))]
        public async Task<IActionResult> AtualizarEndereco(EnderecoViewModel enderecoViewModel)
        {
            var result = await _enderecoService.AddEndereco(enderecoViewModel);
            return CustomResponse(result);
        }
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Notificator)),
         SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(UnityOfWorkErrors))]
        public async Task<IActionResult> GetAllEnderecos()
        {
            var result = await _enderecoService.GetAllEnderecos();
            return CustomResponse(result);
        }

        [HttpGet("{GetEnderecoById}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Notificator)),
         SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(UnityOfWorkErrors))]
        public async Task<IActionResult> GetEnderecoById(int id)
        {
            var result = await _enderecoService.GetEnderecoById(id);
            return CustomResponse(result);
        }
        [HttpGet("{GetEnderecoByClientId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Notificator)),
         SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(UnityOfWorkErrors))]
        public async Task<IActionResult> GetEnderecoByClientId(int clientId)
        {
            var result = await _enderecoService.GetEnderecoById(clientId);
            return CustomResponse(result);
        }
    }
}
