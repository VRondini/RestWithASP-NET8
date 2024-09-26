using Restapi_WorkingWithFiles.Data.VO;

namespace Restapi_WorkingWithFiles.Business
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
