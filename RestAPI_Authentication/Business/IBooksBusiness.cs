using Restapi_WorkingWithFiles.Model;
using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNETUdemy.Business
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
