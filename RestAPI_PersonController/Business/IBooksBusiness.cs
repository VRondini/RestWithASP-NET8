using Restapi_PersonController.Model;

namespace Restapi_PersonController.Business
{
    public interface IBooksBusiness
    {
        Books Create(Books books);
        Books FindById(int id);
        List<Books> FindAll();
        Books Update(Books books);
        void Delete(int Id);
    }
}
