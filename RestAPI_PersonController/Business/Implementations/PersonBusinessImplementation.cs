using Restapi_PersonController.Model;
using Restapi_PersonController.Repository;

namespace Restapi_PersonController.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
        }
        public List<Person> FindAll()
        {            
            return _repository.FindAll();
        }

        public Person FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
