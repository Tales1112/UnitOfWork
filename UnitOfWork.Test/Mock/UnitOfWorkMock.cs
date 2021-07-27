using Moq;
using Unity_Of_Work.Models;
using Unity_Of_Work.Repositories;
using Unity_Of_Work.Repositories.Interfaces;
using Unity_Of_Work.Repositories.Repositories;

namespace UnitOfWork.Test.Mock
{
    public class UnitOfWorkMock<TRepository,T> where TRepository : Repository<T>
                                               where T : class
    {
        public readonly Mock<UnityOfWork> _UnitOfWorkMock;

        public UnitOfWorkMock(ApplicationDbContext applicationDbContext, Repository<T> clientRepository)
        {
            _UnitOfWorkMock = new Mock<UnityOfWork>(applicationDbContext, clientRepository) { CallBase = true };
        }
        public IUnitOfWork GetMock() => _UnitOfWorkMock.Object;
    }
}
