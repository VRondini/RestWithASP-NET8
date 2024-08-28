using Restapi_PersonController.Model;
using Restapi_PersonController.Repository;

namespace Restapi_PersonController.Business.Implementations
{
    public class BooksBusinessImplementation : IBooksBusiness
    {
        private readonly IRepository<Books> _repository;

        public BooksBusinessImplementation(IRepository<Books> repository)
        {
            _repository = repository;
        }
        public List<Books> FindAll()
        {
            return _repository.FindAll();
        }

        public Books FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Books Create(Books books)
        {
            return _repository.Create(books);
        }
        public Books Update(Books books)
        {
            return _repository.Update(books);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
