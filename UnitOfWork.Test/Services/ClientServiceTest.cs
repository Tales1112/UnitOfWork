using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using UnitOfWork.Test.Mock;
using Unity_Of_Work;
using Unity_Of_Work.Models;
using Unity_Of_Work.Repositories;
using Unity_Of_Work.Repositories.Repositories;

namespace UnitOfWork.Test.Services
{
    [TestClass]
    public class ClientServiceTest
    {
        private readonly IClientService _clientService;
        private readonly ClientRepositoryMock _clientRepositoryMock;
        private readonly UnitOfWorkMock<Repository<Client>, Client> _unitOfWorkMock;
        public ClientServiceTest()
        {
            Mock<ApplicationDbContext> _context = new Mock<ApplicationDbContext>();
            _clientRepositoryMock = new ClientRepositoryMock(_context.Object);
            _unitOfWorkMock = new UnitOfWorkMock<Repository<Client>, Client>(_context.Object, _clientRepositoryMock.GetMock());
            _clientService = new ClientService(_unitOfWorkMock.GetMock());
        }

        [TestMethod]
        public async Task CreateCliente_ReturnsSuccess()
        {
            //Arrange
            ClientViewModel client = new ClientViewModel("Tales", "testando123123@gmail.com");
            Client entity = new Client(client);
            _clientRepositoryMock.MockAdd();
            _clientRepositoryMock.AddReturn(entity);

            //Act
            var result = await _clientService.CreateClient(client);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
