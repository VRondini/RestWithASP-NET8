using Restapi_WorkingWithFiles.Data.Converter.Implementations;
using Restapi_WorkingWithFiles.Data.VO;
using Restapi_WorkingWithFiles.Model;
using Restapi_WorkingWithFiles.Repository;

namespace Restapi_WorkingWithFiles.Business.Implementations
{
    public class BooksBusinessImplementation : IBooksBusiness
    {
        private readonly IRepository<Books> _repository;
        private readonly BooksConverter _converter;

        public BooksBusinessImplementation(IRepository<Books> repository)
        {
            _repository = repository;
            _converter = new BooksConverter();
        }
        public List<BooksVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BooksVO FindById(int id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BooksVO Create(BooksVO books)
        {
            var booksEntity = _converter.Parse(books);
            booksEntity = _repository.Create(booksEntity);
            return _converter.Parse(booksEntity);
        }
        public BooksVO Update(BooksVO books)
        {
            var booksEntity = _converter.Parse(books);
            booksEntity = _repository.Update(booksEntity);
            return _converter.Parse(booksEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
