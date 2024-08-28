using Restapi_PersonController.Model;

namespace Restapi_PersonController.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(int id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(int Id);
    }
}
