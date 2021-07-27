using Moq;
using Moq.Language.Flow;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity_Of_Work.Repositories;
using Unity_Of_Work.Repositories.Interfaces;
using Unity_Of_Work.Repositories.Repositories;
namespace UnitOfWork.Test.Mock
{
    public class BaseRepositoryMock<TRepository, TEntity> where TRepository : Repository<TEntity>
                                                          where TEntity : class
    {
        public readonly Mock<TRepository> _repositoryMock;
        private readonly List<TEntity> results;

        public BaseRepositoryMock(ApplicationDbContext applicationDbContext)
        {
            _repositoryMock = new Mock<TRepository>(applicationDbContext) { CallBase = true };
            results = new List<TEntity>();
        }

        public IReturnsResult<TRepository> MockAdd() =>
            _repositoryMock.Setup(x => x.Add(It.IsAny<TEntity>()))
            .Returns<TEntity>(x => Task.FromResult(CreateAsyncAction(x)));

        //public IReturnsResult<TRepository> MockRemove() =>
        //    _repositoryMock.Setup(x => x.Delete(It.IsAny<TEntity>()))
        //    .Returns<TEntity>(x => results.Remove(x));

        public virtual TEntity CreateAsyncAction(TEntity entity)
        {
            AddReturn(entity);
            return entity;
        }
        public void AddReturn(TEntity result) => results.Add(result);
        public TRepository GetMock() => _repositoryMock.Object;
    }
}
