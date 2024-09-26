using Restapi_PersonController.Data.VO;
using Restapi_PersonController.Model;

namespace Restapi_PersonController.Business
{
    public interface IBooksBusiness
    {
        BooksVO Create(BooksVO books);
        BooksVO FindById(int id);
        List<BooksVO> FindAll();
        BooksVO Update(BooksVO books);
        void Delete(int Id);
    }
}
