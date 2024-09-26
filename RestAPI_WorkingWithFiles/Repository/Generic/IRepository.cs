using Restapi_WorkingWithFiles.Model;
using Restapi_WorkingWithFiles.Model.Base;

namespace Restapi_WorkingWithFiles.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(int id);
        List<T> FindAll();
        T Update(T item);
        void Delete(int Id);
        bool Exists(int id);
    }
}
