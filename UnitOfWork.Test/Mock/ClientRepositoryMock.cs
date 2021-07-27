using Unity_Of_Work.Models;
using Unity_Of_Work.Repositories;
using Unity_Of_Work.Repositories.Repositories;

namespace UnitOfWork.Test.Mock
{
    public class ClientRepositoryMock : BaseRepositoryMock<Repository<Client>,Client>
    {

        public ClientRepositoryMock(ApplicationDbContext context) : base(context)
        {

        }
    }
}
